using UnityEngine;
using System.Collections;

public class NoCamera : MonoBehaviour {

    private Transition transitionScript;

	void Start()
	{
		transitionScript = GameObject.FindGameObjectWithTag ("TransitionScript").GetComponent<Transition> ();
	}

	public void FinishAnimation()
    {
		transitionScript.cameraAnimationIsFinish = true;
		transitionScript.DestroyElevatorDoor();
        transitionScript.DestroySpawnEnemies();
    }
}
