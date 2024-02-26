using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButton : MonoBehaviour
{
    public void Credit()
    {
        Debug.Log("I have gone to the credits");
        SceneManager.LoadScene("Credits");
    }
    public void Play()
    {
        Debug.Log("I have gone to play");
        SceneManager.LoadScene("Tutorial");
    }
    public void Menu()
    {
        Debug.Log("I have gone to the menu");
        SceneManager.LoadScene("Menu");
    }
    public void Quit()
    {
        Debug.Log("I have quit");
        Application.Quit();
    }

}