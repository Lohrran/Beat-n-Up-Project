using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SpawnEnemy : MonoBehaviour {

    [SerializeField]
    private List <GameObject> enemiesPrefab = new List<GameObject>();

    [SerializeField]
    private float spawnStart;
    [SerializeField]
    private float spawnRate;

    private int maxEnemies = 5;

	[HideInInspector]
	public int deadEnemies = 0;
	[HideInInspector]
    public int countEnemies;

	private List<GameObject> enemies = new List<GameObject>();

    private Transition transitionScript;
    
    [SerializeField]
    private List<Transform> spawnEnemyPosition = new List<Transform>();

	void Start()
	{
		transitionScript = GameObject.FindGameObjectWithTag ("TransitionScript").GetComponent<Transition> ();
		InvokeRepeating ("Spawn", spawnStart, spawnRate); 
	}

	private void Spawn()
	{
        if (countEnemies < maxEnemies)
		{
            countEnemies++;
            //Vector3 spawnPosition = transform.position;

            int i = Random.Range(0, 2);
            int j = Random.Range(0, 2);

            GameObject enemyObject = Instantiate(enemiesPrefab[j], spawnEnemyPosition[i].position, Quaternion.identity) as GameObject;

            EnemyAI enemyScript = enemyObject.GetComponent<EnemyAI>();
            enemyScript.id = enemies.Count;
            enemyScript.spawnScript = this;

            enemies.Add(enemyObject);

         
            if (enemies.Count == 1)
            {
                enemyScript.Attack();
            }
		}
	}

    public void RemoveAtList(GameObject gameObject)
    {
        enemies.Remove(gameObject);
        deadEnemies++;

        if (enemies.Count > 0)
        {
            EnemyAI enemyScript = enemies.First().GetComponent<EnemyAI>();

            enemyScript.Attack();
        }

        if (deadEnemies == maxEnemies)
        {
           transitionScript.canActive = true;
        }
    }
}
