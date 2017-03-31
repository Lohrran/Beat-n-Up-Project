using UnityEngine;
using System.Collections;

public class HealthInterface : MonoBehaviour
{
	private Status controlHealth;

	private GameObject player;
	private GameObject healthHud;
	
	public Sprite spriteOne;
	public Sprite spriteTwo;
	public Sprite spriteThree;
	public Sprite spriteFour;
	public Sprite spriteFive;
	public Sprite spriteSix;
	public Sprite spriteEmpty;
	
	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		healthHud = GameObject.Find("Health HUD");
		controlHealth = player.GetComponent<Status>();

		UpdateHealth();
	}
	void Update()
	{	
        if (player != null)
        {
	    	controlHealth = player.GetComponent<Status>();
		    UpdateHealth ();
        }
	}
	
	public void UpdateHealth()
	{
		
		if (controlHealth.health == 6) 
		{
			healthHud.GetComponent<SpriteRenderer>().sprite = spriteOne;
		} 
		else if (controlHealth.health == 5)
		{

			healthHud.GetComponent<SpriteRenderer>().sprite = spriteTwo;
		} 
		else if (controlHealth.health == 4) 
		{
			healthHud.GetComponent<SpriteRenderer>().sprite = spriteThree;
		}
		else if (controlHealth.health == 3)
		{
			healthHud.GetComponent<SpriteRenderer>().sprite = spriteFour;
		} 
		else if (controlHealth.health == 2) 
		{
			healthHud.GetComponent<SpriteRenderer>().sprite = spriteFive;
		}
		else if (controlHealth.health == 1) 
		{
			healthHud.GetComponent<SpriteRenderer>().sprite = spriteSix;
		}
		else if (controlHealth.health == 0) 
		{
			healthHud.GetComponent<SpriteRenderer>().sprite = spriteEmpty;
		}
	}
}