using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firetrap : PlayerLife //use inheritance to inherit properties from PlayerLife script
{
    [Header("Firetrap Timer")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;
    private Animator anim;
    private SpriteRenderer spriteRend;
    PlayerLife p1 = new PlayerLife(); //create PlayerLife object

    private bool triggered; //when the trap gets triggered
    private bool active; //when the trap is active and can hurt

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if (!triggered)
            {
                //trigger trap
                StartCoroutine(ActivateFiretrap());
            }
            //if (active)
                //p1.Die();
        }
    }
    private void Update()
    {
        if (active && p1 != null)
            p1.Die();
    }
    private IEnumerator ActivateFiretrap()
    {
        //turn the sprite red to notify player trigger trap
        triggered = true;
        spriteRend.color = Color.red; // turn sprite to red

        //wait for delay, activate trap, turn on animation, return colour to norm
        yield return new WaitForSeconds(activationDelay);
        spriteRend.color = Color.white; //turn back to normal
        active = true;
        anim.SetBool("activated", true);

        //wait until x seconds, decativate trap;
        yield return new WaitForSeconds(activeTime);
        active = false;
        triggered = false;
        anim.SetBool("activated", false);
    }
}
