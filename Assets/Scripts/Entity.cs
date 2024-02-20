using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public int health = 1;

    public virtual void OnCollisionEnter(Collision collision)
    {

    }

    public virtual bool LessHealth()
    {
        health--;
        Debug.Log("DED");
        return false;
    }
}
