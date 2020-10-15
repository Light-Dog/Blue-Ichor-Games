using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    public int ammo;
    public int maxAmmo;
    public float cooldown;
    public float damage;
    public ParticleSystem muzzleParticle;

    //to display the UI to aim
    public virtual void Aim()
    {

    }

    //executes the primary function of the weapon
    public virtual void Fire()
    {

    }

    //if Check returns true, call Fire
    public virtual bool Check()
    {
        return true;
    }

    public int GetAmmo() { return ammo; }
    public void IncrementAmmo(int pickup) { ammo += pickup;  }
    public void DecrementAmmo() { ammo--; }
}
