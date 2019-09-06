using UnityEngine;
using System.Collections;

public class SpecialEffect : MonoBehaviour {

	public static SpecialEffect Instance;
	
	public GameObject punchEffect;

	void Awake()
	{
		if (Instance != null)
		{
			Debug.LogError("Existem Multiplas Instancia dos Script SpecialEffect");
		}
		
		Instance = this;
	}
	
	public void Punch(Vector3 position)
	{
		InstatiateEffect (punchEffect, position);
	}
	
	private GameObject InstatiateEffect(GameObject prefab, Vector3 position)
	{
		GameObject newAnimation = Instantiate (prefab, position, Quaternion.identity) as GameObject;
		
		Destroy (newAnimation, 0.78f);

		return newAnimation;
	}
}
