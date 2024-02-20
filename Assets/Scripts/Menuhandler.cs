using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menuhandler : MonoBehaviour
{
    public GameObject menuCanvas;

    public bool MenuIsActive;

    private void Update()
    {
        MenuAnywhere();
    }

    private void Start()
    {
        menuCanvas.SetActive(false);
    }

    public void startAgain()
    {
        menuCanvas.SetActive(false);
        Time.timeScale = 1.0f;
        MenuIsActive = false;
    }

    void MenuAnywhere()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (!MenuIsActive)
            {
                menuCanvas.SetActive(true);

                MenuIsActive = true;

                Time.timeScale = 0f;

                return;
            }

            if (MenuIsActive)
            {
                menuCanvas.SetActive(false);

                MenuIsActive = false;

                Time.timeScale = 1f;
            }
        }
    }
}
