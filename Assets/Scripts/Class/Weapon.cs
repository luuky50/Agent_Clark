using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon
{
    public string name;
    public float damage;
    public GameObject modelHolder;
    public float bulletVelocity;
    public float chargeTimer;
    public float rechargeTime;
    public bool isAutomatic;

}
public class The_Striker
{
    public Weapon weapon;
    public The_Striker(Weapon newWeapon)
    {
        weapon = newWeapon;
        newWeapon.name = "The Striker";
        newWeapon.damage = 15;

        newWeapon.bulletVelocity = 2;
        newWeapon.chargeTimer = 2;
    }

}
