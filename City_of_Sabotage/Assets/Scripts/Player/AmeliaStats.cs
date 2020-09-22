using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmeliaStats : MonoBehaviour
{
    [Header("Health Settings")]
    public int health;
    public int healthPerPickup;

    [Header("Hammer Settigns")]
    public int meleeDamage;
    public float knockbackDistance;
    bool slam;

    [Header("Weapon Settings")]
    public List<WeaponBase> weapons;
    public enum weaponType { minigun, bombglove, cryogun, windcannon}
    public int equipedWeapon;
    public GameObject WeaponWheel;

    // Start is called before the first frame update
    void Start()
    {
        slam = false;
        equipedWeapon = (int) weaponType.minigun;
        WeaponWheel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        weaponSelect();

        if (Input.GetButton("UseEquipment"))
            UseWeapon();
    }

    void UseWeapon()
    {
        //preform weapon check & if passed fire weapon
        //fire weapon
        if(equipedWeapon == (int)weaponType.minigun)
        {
            if(weapons[equipedWeapon].Check())
            {
                weapons[equipedWeapon].Fire();
                weapons[equipedWeapon].DecrementAmmo();
            }
        }
    }

    void weaponSelect()
    {
        if (Input.GetButton("WeaponSelect"))
        {
            WeaponWheel.SetActive(true);
        }
        else
        {
            equipedWeapon = WeaponWheel.GetComponent<MenuScript>().GetCurrentWeapon();
            WeaponWheel.SetActive(false);
        }
    }
}
