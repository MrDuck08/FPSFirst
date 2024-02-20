using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum WeaponState
{
    unarmed = 0,
    HitScan = 1,
    Projectile = 2,
    FireStormRevolver = 3,
    Total
}

public class WeaponHandler : MonoBehaviour
{
    public PlayerMovment myPlayerMovment = null;

    [Header("Unarmed = Element 0 \n Hitscan = Element 1 \n Projectile = Element 2")]
    public Weapon[] avilableWeapons = new Weapon[(int)WeaponState.Total];
    public Weapon currentWeapon = null;

    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI whatWeaponText;

    float mouseAxisBreakpoin = 1.0f;
    float ScollWhellDelta = 0.0f;

    Menuhandler pauseScript;

    private void Update()
    {
        HandleWeaponSwap();

        foreach (Weapon weapon in avilableWeapons)
        {
            weapon.gameObject.SetActive(false);
        }
     
        currentWeapon.gameObject.SetActive(true);

        if (Input.GetMouseButtonDown(0) && currentWeapon != null)
        {
            currentWeapon.Fire();
        }

        ammoText.text = currentWeapon.ammunition.ToString() + " Ammo";

        WhatWeaponToShow(); 

        currentWeapon.holder = myPlayerMovment;
    }

    void WhatWeaponToShow()
    {
        int CurrenWeaponIndex = (int)currentWeapon.weaponType;
        if (CurrenWeaponIndex == (int)WeaponState.unarmed)
        {
            whatWeaponText.text = "Unarmed";
        }
        if(CurrenWeaponIndex == (int)WeaponState.Projectile)
        {
            whatWeaponText.text = "Rocket Launcher";
        }
        if (CurrenWeaponIndex == (int)WeaponState.FireStormRevolver)
        {
            whatWeaponText.text = "Firestorm Revolver";
        }
        if (CurrenWeaponIndex == (int)WeaponState.HitScan)
        {
            whatWeaponText.text = "Hitscan";
        }
    }

    public void Start()
    {
        int currentWeaponIndex = (int)currentWeapon.weaponType;
        WeaponSwapAnimation(currentWeaponIndex);

        pauseScript = FindAnyObjectByType<Menuhandler>();
    }
    private void HandleWeaponSwap()
    {
        if(pauseScript.MenuIsActive) { return; }
        ScollWhellDelta += Input.mouseScrollDelta.y;
        if (Mathf.Abs(ScollWhellDelta) > mouseAxisBreakpoin)
        {
            int SwapDirection = (int)Mathf.Sign(ScollWhellDelta);
            ScollWhellDelta -= SwapDirection * mouseAxisBreakpoin;

            int CurrenWeaponIndex = (int)currentWeapon.weaponType;
            CurrenWeaponIndex += SwapDirection;

            if (CurrenWeaponIndex < 0)
            {
                CurrenWeaponIndex = (int)WeaponState.Total + CurrenWeaponIndex;
            }
            if (CurrenWeaponIndex >= (int)WeaponState.Total)
            {
                CurrenWeaponIndex = 0;
            }
            WeaponSwapAnimation(CurrenWeaponIndex);

        }
    }

    private void WeaponSwapAnimation(int currentWeaponIndex)
    {
        foreach (var weapon in avilableWeapons)
        {
            weapon.gameObject.SetActive(false);
        }
        currentWeapon = avilableWeapons[currentWeaponIndex];
        currentWeapon.gameObject.SetActive(true);
        currentWeapon.holder = myPlayerMovment;
    }


    private void OnTriggerEnter(Collider other)
    {
        int CurrenWeaponIndex = (int)currentWeapon.weaponType;
        if (CurrenWeaponIndex == (int)WeaponState.unarmed)
        {
            return;
        }
        if (other.gameObject.layer == 10)
        {
            Destroy(other.gameObject);

            currentWeapon.ammunition += 50;
        }
    }
}
