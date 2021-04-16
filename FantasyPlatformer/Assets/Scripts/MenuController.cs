using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void PlayCave()
    {
        SceneManager.LoadScene("Level1");
    }

    public void PlayGround()
    {
        SceneManager.LoadScene("Level16");
    }

    public void PlaySky()
    {
        SceneManager.LoadScene("Level31");
    }

    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }
}
