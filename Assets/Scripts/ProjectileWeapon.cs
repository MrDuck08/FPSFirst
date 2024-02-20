using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : Weapon
{
    public ProjectileBase projectileToSpawn = null;
    public GameObject shootParticle = null;

    public float x = 0.5f;
    public float y = 0.5f;

    Menuhandler pauseScript;

    public override void Start()
    {
        base.Start();
        shootParticle.SetActive(false);
        pauseScript = FindAnyObjectByType<Menuhandler>();
    }

    public override bool Fire()
    {
        if(pauseScript.MenuIsActive) { return true; }
        if (base.Fire() == false)
        {
            return true;
        }

        ProjectileBase SpawnedProjectile = Instantiate(projectileToSpawn);

        SpawnedProjectile.Init(new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z), Camera.main.transform.forward.normalized * 10000.0f + Camera.main.transform.position);

        SpawnedProjectile.holder = holder;

        StartCoroutine(ParticleEffect());

        return false;
    }

    IEnumerator ParticleEffect()
    {
        shootParticle.SetActive(true);

        yield return new WaitForSeconds(0.2f);

        shootParticle.SetActive(false);
    }
}
