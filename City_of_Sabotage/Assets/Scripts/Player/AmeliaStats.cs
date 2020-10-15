using System.Collections;
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
    bool slam = false;
    public GameObject hammer;

    [Header("Weapon Settings")]
    public List<WeaponBase> weapons;
    public enum weaponType { minigun, bombglove, cryogun, windcannon}
    public int equipedWeapon;
    public GameObject WeaponWheel;
    public float slowScale = 0.05f;
    bool slow = false;
    bool weaponChange = false;

    // Start is called before the first frame update
    void Start()
    {
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
        //q
        weaponSelect();

        //Left Click
        if (Input.GetButton("UseEquipment"))
            UseWeapon();

        //Right Click
        if(Input.GetMouseButtonDown(1))
        {
            Debug.Log("HAMMER TIME");
            weapons[equipedWeapon].gameObject.SetActive(false);
            hammer.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.E))
            healthbar.SetHealth(--health);

        if (Input.GetKeyDown(KeyCode.Y))
        {
            print("RELOADED");
            weapons[equipedWeapon].ammo = weapons[equipedWeapon].maxAmmo;
        }
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
            Cursor.lockState = CursorLockMode.Confined;

            WeaponWheel.SetActive(true);
            weapons[equipedWeapon].gameObject.SetActive(false);
            hammer.SetActive(false);

            Time.timeScale = slowScale;
            Time.fixedDeltaTime = Time.timeScale * .02f;

            weaponChange = true;
        }
        else if (weaponChange)
        {
            WeaponWheel.SetActive(false);

            equipedWeapon = WeaponWheel.GetComponent<MenuScript>().GetCurrentWeapon();
            weapons[equipedWeapon].gameObject.SetActive(true);

            Time.timeScale = 1;
            Time.fixedDeltaTime = Time.timeScale * .02f;
            weaponChange = false;

            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void Slowmotion()
    {
        Time.timeScale = slowScale;
        Time.fixedDeltaTime = Time.timeScale * .02f;
        slow = true;
    }
}
