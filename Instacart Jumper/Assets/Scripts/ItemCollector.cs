using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    // Initalize variables
    private int collectables = 0;
    
    [SerializeField] private Text collectionText;

    [SerializeField] private AudioSource collectSoundEffect;

    // Function for collecting item, and keeping the scores in the game
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            collectables++;
            collectionText.text = "Cherry: " + collectables;
        }
    }
}
