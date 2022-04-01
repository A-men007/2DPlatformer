using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    // Function for loading the next level scene
    public void LevelOne()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void LevelTwo()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void LevelThree()
    {
        SceneManager.LoadScene("Level 3");
    }
    public void SelectLevel()
    {
        SceneManager.LoadScene("LevelSelector");
    }
    public void Main()
    {
        SceneManager.LoadScene("Start Scene");
    }
}
