using UnityEngine;
using System.Collections;

public class HealthEnemy : Health {

    int health;
    private Animator anim;
    private EnemyAI enemyScript;

    void Start()
    {
        enemyScript = GetComponent<EnemyAI>();
        health = gameObject.GetComponent<Status>().health;
        anim = GetComponent<Animator>();
    }
    
    override public void TakeDamage(int damage)
    {
        enemyScript.TakePunch();
        health -= damage;

        if (health <= 0)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            EnemyAI enemyAiScript = gameObject.GetComponent<EnemyAI>();
            gameObject.GetComponent<EnemyAI>().enabled = false;

            anim.SetBool("death", true);
            enemyAiScript.Dead();
        }
    }
}
