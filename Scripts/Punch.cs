using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Punch : MonoBehaviour {

	private Animator anim;
	private int selectAnimation;
	private bool auxTime;
	private float animationTime;
	private int levelPunch;
	
	void Start ()
	{
		levelPunch = 1;
		anim = GetComponent<Animator> ();	
	}
	
	void Update ()
	{
		if (levelPunch == 1)
		{
			PunchLevelOne ();
		}

		else if (levelPunch == 2)
		{
			PunchLevelTwo ();
		}

	}

	void PunchLevelOne()
	{
		if (Input.GetButtonDown ("Fire1")) 
		{
			auxTime = true;
			selectAnimation +=1;

			if (selectAnimation == 1) 
			{
				anim.SetTrigger("punch One");
			} 
			else if (selectAnimation == 2)
			{
				anim.SetTrigger("punch Two");
			}
		}
		PunchCoolDown (0.8f);
    }

	void PunchLevelTwo()
	{
		if (Input.GetButtonDown ("Fire1")) 
		{
			auxTime = true;
			selectAnimation +=1;
			
			if (selectAnimation == 1) 
			{
				anim.SetTrigger("punch One");
			} 
			else if (selectAnimation == 2) 
			{
				anim.SetTrigger("punch One");
			} 
			else if (selectAnimation == 3) 
			{
				anim.SetTrigger("punch One");
			} 
			else if (selectAnimation == 4)
			{
				anim.SetTrigger("punch Two");
			}
		}
		PunchCoolDown (0.8f);
	}

	void PunchCoolDown(float coolDownTime)
	{
		if (auxTime)
		{
			animationTime += Time.deltaTime;
			if (animationTime > coolDownTime)
			{
				animationTime = 0;
				auxTime = false;

				selectAnimation = 0;
			
			}
		}
	}

}
