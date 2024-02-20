using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public Damageable holder = null;

    public GameObject projectileObject = null;
    public GameObject detonationObject = null;
    public GameObject trailEffect = null;

    protected Vector3 spawnPosition = Vector3.zero;

    protected Vector3 aimPoint = Vector3.zero;
    
    protected Vector3 aimDirection = Vector3.zero;

    float detonationLifeTime = -1337f;
    public float detonationMaxLifeTime = 1.0f;
    float lifeTime = 0.0f;
    public float lifeTimeMax = 20.0f;

    public float movmentSpeed = 20.0f;

    public bool hasCollided;

    PlayerHealth playerHealth;

    public virtual void Start()
    {
        projectileObject.SetActive(true);
        trailEffect.SetActive(false);
        if(detonationObject != null)
        {
            detonationObject.SetActive(false);
        }
    }

    public virtual void Update()
    {
        BasicLifeTime();
        DetonationLifeTIme();
    }

    private void BasicLifeTime()
    {
        lifeTime += Time.deltaTime;
        if (lifeTime > lifeTimeMax)
        {
            Destroy(gameObject);
        }
    }

    private void DetonationLifeTIme()
    {
        if (detonationObject != null && detonationLifeTime > 0.0f)
        {
            detonationLifeTime -= Time.deltaTime;
            if (detonationLifeTime <= 0.0f)
            {
                playerHealth = FindAnyObjectByType<PlayerHealth>();
                playerHealth.invincible = false;
                Destroy(gameObject);
            }
        }
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == gameObject.layer)
        {
            return;
        }

        var HittDamageable = collision.gameObject.GetComponent<Damageable>();
        if (HittDamageable != null)
        {
            if (holder != HittDamageable)
            {

            }
        }

        hasCollided = true;

        projectileObject.SetActive(false);

        movmentSpeed = 0.0f;

        if(detonationObject != null)
        {
            detonationLifeTime = detonationMaxLifeTime;
            detonationObject.SetActive(true);
        }
    }

    public virtual void Init(Vector3 SpawnPosition, Vector3 AimPosition)
    {
        spawnPosition = SpawnPosition;
        transform.position = spawnPosition;

        aimPoint = AimPosition;
        aimDirection = (aimPoint - spawnPosition).normalized;
        transform.LookAt(aimPoint);
    }
    public IEnumerator DestoryExposion()
    {
        if (detonationObject != null && projectileObject != null)
        {
            detonationObject.SetActive(true);

            yield return new WaitForSeconds(0.3f);              
            
            Destroy(detonationObject);
            Destroy(gameObject);
        }
    }
}
