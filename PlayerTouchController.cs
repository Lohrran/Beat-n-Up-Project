using UnityEngine;
using System.Collections;

public enum State
{
    MOVING,
    RIGHT,
    LEFT,
    NOTHING
}


public class PlayerTouchController : MonoBehaviour
{
    private float controlSpeed;
    private State state = State.NOTHING;
    private Animator anim;
    private float X;
    public bool controller = true;

    void Start()
    {
        X = transform.localScale.x;
        anim = GetComponent<Animator>();
        controlSpeed = gameObject.GetComponent<Status>().walkSpeed;
    } 

    void Update()
    {
       transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y - 0.1f);

       Flip();
       AnimationUpdate();
    }

    public void Right()
    {
        transform.Translate ( Vector2.right * (controlSpeed * Time.deltaTime));
        state = State.MOVING;        
    }

    public void Left()
    {
        transform.Translate( -Vector2.right * (controlSpeed * Time.deltaTime));
        state = State.MOVING;
    }

    public void Up()
    {
        transform.Translate( Vector2.up * (controlSpeed * Time.deltaTime));
        state = State.MOVING;
    }

    public void Down()
    {
        transform.Translate( -Vector2.up * (controlSpeed * Time.deltaTime));
        state = State.MOVING;
    }

    public void Idle()
    {
        state = State.NOTHING;
    }

    void Flip()
    {
        Vector2 aux = transform.localScale;

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            aux.x = -X;
        }

        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            aux.x = X;
        }

        transform.localScale = aux;
    }

    void AnimationUpdate()
    {
        if (state == State.MOVING)
        {
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }
    }


}
