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
    public enum weaponType { none, minigun, bombglove, cryogun, windcannon}
    public int equipedWeapon;
    public KeyCode fireWeapon;

    // Start is called before the first frame update
    void Start()
    {
        slam = false;
        equipedWeapon = (int) weaponType.minigun;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(fireWeapon))
            UseWeapon();
    }

    void UseWeapon()
    {
        //preform weapon check & if passed fire weapon
        //fire weapon
        if(equipedWeapon !=  (int)weaponType.none)
        {
            if(weapons[0].Check())
            {
                weapons[0].Fire();
                weapons[0].DecrementAmmo();
            }
        }
    }
}
