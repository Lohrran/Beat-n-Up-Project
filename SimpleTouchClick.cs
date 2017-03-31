using UnityEngine;
using System.Collections;

public class SimpleTouchClick : MonoBehaviour {

	public Renderer buttonRenderer;
	
	void Update()
	{
		SimpleClick ();
	}
	
	void SimpleClick()
	{
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
			Vector2 position = Camera.main.ScreenToWorldPoint(touch.position);
			
			bool clicked = Mathf.Abs(position.x - buttonRenderer.transform.position.x) <= buttonRenderer.bounds.size.x && Mathf.Abs(position.y - buttonRenderer.transform.position.y) <= buttonRenderer.bounds.size.y;
			
			if (clicked)
			{
				if (touch.phase == TouchPhase.Began)
				{
					Application.LoadLevel("Level 1");
				}
			}
		}
	}
}
