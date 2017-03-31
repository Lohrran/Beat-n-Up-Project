using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	
	private float controlSpeed;
	private Animator anim;
	private float X;
    public bool controller = true;
	
	void Start () {
		X = transform.localScale.x;
		anim = GetComponent<Animator> ();	
		controlSpeed = gameObject.GetComponent<Status>().walkSpeed;
	}

	void Update () {
		transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.y - 0.1f);
        
        if(controller == true)
        {
		    Movement ();
		}

        Flip ();
		AnimationUpdate ();
	}

	void Movement()
	{
		if (Input.GetAxisRaw ("Horizontal") > 0)
		{
			rigidbody2D.transform.Translate(Vector2.right * (controlSpeed * Time.deltaTime));
		}
		
		if (Input.GetAxisRaw ("Horizontal") < 0)
		{
			rigidbody2D.transform.Translate(-Vector2.right * (controlSpeed * Time.deltaTime));
		}
		
		if (Input.GetAxisRaw ("Vertical") > 0)
		{
			rigidbody2D.transform.Translate(Vector2.up * (controlSpeed * Time.deltaTime));
		}
		
		if (Input.GetAxisRaw ("Vertical") < 0)
		{
			rigidbody2D.transform.Translate(-Vector2.up * (controlSpeed * Time.deltaTime));
		}
	}

	void Flip()
	{
		Vector2 aux = transform.localScale;
		
		if(Input.GetAxisRaw ("Horizontal") < 0)
        {	
			aux.x = -X;
		}
		
		else if(Input.GetAxisRaw ("Horizontal") > 0)
        {
			aux.x = X;
		}	
		
		transform.localScale = aux;
	}

	void OnDestroy()
	{
		Application.LoadLevel("Game Over");
	}

	void AnimationUpdate()
	{
        if (Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("Horizontal") < 0 || Input.GetAxisRaw("Vertical") > 0 || Input.GetAxisRaw("Vertical") < 0)
        {
			anim.SetBool ("walk", true);
		}
		else
        {
			anim.SetBool ("walk", false);
		}
	}

}
