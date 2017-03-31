using UnityEngine;
using System.Collections;

public class TouchControl : MonoBehaviour
{
    public Renderer joystickRenderer;
	public Renderer punchButtonRenderer;
    private Touch firstTouch;
    private PlayerTouchController playerMovement;

	private Animator anim;
	private int selectAnimation;
	private bool auxTime;
	private float animationTime;

    void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTouchController>();   
		anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();	
    }

    void Update()
    {
		MoveTouchControl ();
    }

	void MoveTouchControl()
	{
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
			Vector2 position = Camera.main.ScreenToWorldPoint(touch.position);
			
			bool clicked = Mathf.Abs(position.x - joystickRenderer.transform.position.x) <= joystickRenderer.bounds.size.x &&
				Mathf.Abs(position.y - joystickRenderer.transform.position.y) <= joystickRenderer.bounds.size.y;
			
			if (clicked)
			{
				if (touch.phase == TouchPhase.Began)
				{
					firstTouch = touch;
					
					// touchZone = new Rect(touch.position.x, Screen.height - touch.position.y, 100, 100);
				}

				else if (touch.phase == TouchPhase.Moved)
				{
					if (touch.position.x > firstTouch.position.x)
					{
						//RIGHT
						playerMovement.Right();
					}
					else if (touch.position.x < firstTouch.position.x)
					{
						//LEFT
						playerMovement.Left();
					}
					
					if (touch.position.y > firstTouch.position.y)
					{
						//UP
						playerMovement.Up();
					}
					else if (touch.position.y < firstTouch.position.y)
					{
						//DOWN
						playerMovement.Down();
					}
				}
				else if (touch.phase == TouchPhase.Ended)
				{
					playerMovement.Idle();
				}
			}
		}
	}
	void PunchTouchControl()
	{
		Touch touch = Input.GetTouch(0);
		Vector2 position = Camera.main.ScreenToWorldPoint(touch.position);
		
		bool clicked = Mathf.Abs(position.x - joystickRenderer.transform.position.x) <= joystickRenderer.bounds.size.x &&
			Mathf.Abs(position.y - joystickRenderer.transform.position.y) <= joystickRenderer.bounds.size.y;
		
		if (clicked)
		{
			if (touch.phase == TouchPhase.Began)
			{
				firstTouch = touch;

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
			else if (touch.phase == TouchPhase.Ended)
			{
				playerMovement.Idle();
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
