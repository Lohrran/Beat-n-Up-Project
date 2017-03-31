using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {
	
	private int damage;
	public string objectTag;

	void Start()
	{
		damage = gameObject.GetComponentInParent<Status> ().damage;
	}
	
	void OnTriggerEnter2D (Collider2D OtherObjectCollider)
	{
		if (OtherObjectCollider.gameObject.tag == objectTag)
		{
			Health health = OtherObjectCollider.gameObject.GetComponent<Health>();
			health.TakeDamage(damage);
			SpecialEffect.Instance.Punch(new Vector3 (transform.position.x, transform.position.y, transform.position.z - 1));
			SoundEffect.Instance.MakePlayerPunchSound();
		} 
	}
}
