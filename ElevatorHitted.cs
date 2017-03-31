using UnityEngine;
using System.Collections;

public class ElevatorHitted : MonoBehaviour {

	private Transition transitionScript;

	void Start()
	{
		transitionScript = GameObject.FindGameObjectWithTag ("TransitionScript").GetComponent<Transition> ();
	}

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y - 0.02f);
    }

	void OnTriggerEnter2D(Collider2D OtherObjectCollider)
	{
		if (OtherObjectCollider.gameObject.tag == "Player")
		{
			transitionScript.actived = true;
		}
	}
}
