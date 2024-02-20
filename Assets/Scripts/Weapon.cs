using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Damageable holder = null;
    public WeaponState weaponType = WeaponState.Total;
    public int ammunition = 0;
    public float weaponRange = 1337.0f;

    public LayerMask ignoreHitMask = 0;
    public LayerMask enemyMask = 0;

    protected Camera mainCamera = null;

    Menuhandler pauseScript;

    public virtual void Start()
    {
        mainCamera = Camera.main;

        pauseScript = FindAnyObjectByType<Menuhandler>();
    }

    public virtual bool Fire()
    {
        if(pauseScript.MenuIsActive) { return true; } 
        // 2 Check ammo
        if(ammunition < 1)
        {
            return false;
        }
        // 3 less ammo
        ammunition--;
        // 4 return to HitScanWeapon
        return true;
    }
}
