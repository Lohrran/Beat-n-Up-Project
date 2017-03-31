using UnityEngine;
using System.Collections;

public class HealthPlayer : Health {

    [HideInInspector]
    public Status health;
    private Animator anim;

    void Start()
    {
        health = gameObject.GetComponent<Status>();

        anim = GetComponent<Animator>();
    }

    override public void TakeDamage(int damage)
    {
        health.health -= damage;

        if (health.health <= 0)
        {
            gameObject.GetComponent<PlayerScript>().enabled = false;
            gameObject.GetComponent<Punch>().enabled = false;

            anim.SetBool("death", true);
            Destroy(gameObject, 1);
        }
    }
}
