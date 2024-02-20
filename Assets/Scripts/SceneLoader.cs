using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    public GameObject player;
    PermanentScript permanentScript;

    private void Start()
    {
        permanentScript = FindAnyObjectByType<PermanentScript>();

        if(permanentScript.noMoreMainMenu)
        {
            mainMenuCanvas.SetActive(false);
            player.SetActive(true);
        }
        else
        {
            mainMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
            player.SetActive(false);
        }
    }

    public void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ReloadScene()
    {
        permanentScript.noMoreMainMenu = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Play()
    {
        mainMenuCanvas.SetActive(false);
        Time.timeScale = 1.0f;
        player.SetActive(true);
        permanentScript.noMoreMainMenu = true;
    }

    public void QuitGame()
    {
        Debug.Log("Left game");
        Application.Quit();
    }
}
