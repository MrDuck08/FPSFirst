using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketProjectile : ProjectileBase
{
    public override void Start()
    {
        movmentSpeed = 20;
        trailEffect.SetActive(false);
    }

    public override void Update()
    {
        base.Update();
        if (!hasCollided)
        {
            AddForce();
            StartCoroutine(AddMovment());
        }
        else
        {
            transform.position += new Vector3(0, 0, 0);
            trailEffect.SetActive(false);
        }
    }

    private void AddForce()
    {
        transform.position += aimDirection * movmentSpeed * Time.deltaTime;
    }

    IEnumerator AddMovment()
    {
        yield return new WaitForSeconds(0.4f);
        movmentSpeed = 100;
        trailEffect.SetActive(true);
    }
}
