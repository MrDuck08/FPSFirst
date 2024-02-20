using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    int health = 3;
    
    public bool invincible;

    public TextMeshProUGUI healthText;

    SceneLoader loader;

    // Update is called once per frame
    void Update()
    {
        healthText.text = health.ToString() + " Health";

        if (health == 0)
        {
            loader = FindAnyObjectByType<SceneLoader>();

            loader.ReloadScene();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.layer == 8 && !invincible)
        {
            health--;
            invincible = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == 8 && !invincible)
        {
            health--;
            invincible = true;
        }
    }
}
