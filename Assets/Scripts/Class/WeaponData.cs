using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Weapon", menuName= "Weapon Creation/Weapon")]
public class WeaponData : ScriptableObject
{

    public string weaponName; //{ get { return weaponName; } }
    public float damage; //{ get { return damage; } }
    //public GameObject modelHolder; //{ get { return modelHolder; } }
    public float bulletVelocity; //{ get { return bulletVelocity; } }
    public float chargeTimer; //{ get { return chargeTimer; } }
    public float rechargeTime; //{ get { return rechargeTime; } }
    public bool isAutomatic; //{ get { return isAutomatic; } }


    //Methods
    public void SpawnWeapon() 
    {
        SetSpawnLocation();

    }

    private void SetSpawnLocation()
    {
        
    }

}
/*public class The_Striker : Weapon
{
    Weapon weapon;
    public The_Striker()
    {
        
        weapon.name = "The Striker";
        weapon.damage = 15;

        weapon.bulletVelocity = 2;
        weapon.chargeTimer = 2;
    }

}

public class The_Destroyer : Weapon
{
    Weapon weapon;
    public The_Destroyer()
    {
        weapon.name = "The Destroyer";

    }
}*/
