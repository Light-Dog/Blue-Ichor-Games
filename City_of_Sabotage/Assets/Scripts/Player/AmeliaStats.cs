﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmeliaStats : MonoBehaviour
{
    [Header("Health Settings")]
    public int health;
    public int healthPerPickup;
    public HealthBar healthbar;

    [Header("Hammer Settigns")]
    public int meleeDamage;
    public float knockbackDistance;
    bool slam;
    public GameObject hammer;

    [Header("Weapon Settings")]
    public List<WeaponBase> weapons;
    public enum weaponType { minigun, bombglove, cryogun, windcannon}
    public int equipedWeapon;
    public GameObject WeaponWheel;
    public float slowScale = 0.05f;
    bool slow = false;

    // Start is called before the first frame update
    void Start()
    {
        slam = false;
        equipedWeapon = (int) weaponType.minigun;
        WeaponWheel.SetActive(false);
        healthbar.SetMaxHealth(health);

        foreach(WeaponBase weapon in weapons)
        {
            weapon.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        weaponSelect();

        if (Input.GetButton("UseEquipment"))
            UseWeapon();

        if(Input.GetMouseButtonDown(1))
        {
            Debug.Log("HAMMER TIME");
            weapons[equipedWeapon].gameObject.SetActive(false);
            hammer.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.E))
            healthbar.SetHealth(--health);
    }

    void UseWeapon()
    {
        //preform weapon check & if passed fire weapon
        //fire weapon
        weapons[equipedWeapon].gameObject.SetActive(true);
        hammer.SetActive(false);

        if (weapons[equipedWeapon].Check())
        {
            weapons[equipedWeapon].Fire();
            weapons[equipedWeapon].DecrementAmmo();
        }

    }

    void weaponSelect()
    {
        if (Input.GetButton("WeaponSelect"))
        {
            WeaponWheel.SetActive(true);

            Time.timeScale = slowScale;
            Time.fixedDeltaTime = Time.timeScale * .02f;

        }
        else
        {
            //weapons[equipedWeapon].gameObject.SetActive(false);
            equipedWeapon = WeaponWheel.GetComponent<MenuScript>().GetCurrentWeapon();
            //weapons[equipedWeapon].gameObject.SetActive(true);
            WeaponWheel.SetActive(false);

            Time.timeScale = 1;
            Time.fixedDeltaTime = Time.timeScale * .02f;
        }
    }

    void Slowmotion()
    {
        Time.timeScale = slowScale;
        Time.fixedDeltaTime = Time.timeScale * .02f;
        slow = true;
    }
}
