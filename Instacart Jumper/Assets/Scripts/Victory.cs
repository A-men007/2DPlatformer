using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    // Initalize variables
    private AudioSource victorySound;
    private bool levelCompleted = false;
    private void Start()
    {
        victorySound = GetComponent<AudioSource>();
    }

    // Function for checking if player collide with the victory point
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            victorySound.Play();
            levelCompleted = true;
            Invoke("CompleteLevel", 2f);
        }
    }

    // Function for loading the next scene
    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
