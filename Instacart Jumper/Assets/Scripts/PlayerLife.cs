using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    // Initalize variables
    private Rigidbody2D rigidbody;
    private Animator anim;

    [SerializeField] private AudioSource deathSoundEffect;

    // Get required component at the start
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Check if player collide with trap
    // If yes, kills the player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            deathSoundEffect.Play();
            Die();
        }
    }

    // Function for "killing" the player
    public void Die()
    {
        rigidbody.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    // Function for restarting the game level
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
