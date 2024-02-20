using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermanentScript : MonoBehaviour
{
    public bool noMoreMainMenu = false;

    private void Awake()
    {
        if (FindObjectsOfType<PermanentScript>().Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }
}
