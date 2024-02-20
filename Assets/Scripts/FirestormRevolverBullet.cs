using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FirestormRevolverBullet : ProjectileBase
{
    bool stopMoving;
    bool exploded;
    PlayerHealth playerHealth;

    float noExplodeStartTime = 0.1f;
    bool noExplode = true;

    public override void Start()
    {
        playerHealth = FindAnyObjectByType<PlayerHealth>();
        lifeTimeMax = 50;
        exploded = false;
        StartCoroutine(StartNoExplodeRoutine());
    }

    public override void Update()
    {
        base.Update();
        Explode();
        if (stopMoving) { return; }
        transform.position += aimDirection * movmentSpeed * Time.deltaTime;
        movmentSpeed = 150;
    }

    IEnumerator StartNoExplodeRoutine()
    {
        yield return new WaitForSeconds(noExplodeStartTime);

        noExplode = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == gameObject.layer) { return; }
        if (other.gameObject.layer != 7)
        {
            movmentSpeed = 0;
            stopMoving = true;
        }
    }

    void Explode()
    {
        if(exploded) { return; }
        if (Input.GetMouseButtonDown(1))
        {
            playerHealth.invincible = false;
            StartCoroutine(DestoryExposion());
            exploded = true;
        }
    }
}
