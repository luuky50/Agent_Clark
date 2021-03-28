using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class WeaponBehaviour : MonoBehaviour
{
    public SteamVR_Action_Boolean shoot = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("ShootWeapon");
    private SteamVR_Input_Sources inputSource;


    public GameObject bullet;
    public float testSpeed = 4;
    private GameObject throwable;
    [SerializeField]
    private GameObject spawnPoint;

    private Throwable throwableGun;

    [SerializeField]
    private WeaponData weaponData;

    bool canShoot = false;

    private void Start()
    {

        throwableGun = this.gameObject.GetComponent<Throwable>();

        throwableGun.onPickUp.AddListener(() =>
        {
            canShoot = true;
            if (LevelManager.instance.currentScene.name == "AI")
            {
                ExtrasManager.instance.extraManagerInit();
                RobotManager.instance.StartCoroutine(RobotManager.instance.generateRobots(4));
            }
        });

        throwableGun.onDetachFromHand.AddListener(() =>
        {
            canShoot = false;
        });


        //The_Destroyer the_Destroyer = new The_Destroyer();
        //the_Destroyer.SpawnWeapon();





        if (spawnPoint == null)
        {
            Debug.LogError("CANNOT FIND A SPAWNPOINT");
        }

    }

    private void Update()
    {
        if (canShoot && shoot.GetStateDown(inputSource))
        {
            StartCoroutine(Shoot());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<DropPoint>())
        {
            DropPoint newDropPoint = other.gameObject.GetComponent<DropPoint>();
            newDropPoint.UnlockLift(gameObject);
        }
    }


    IEnumerator Shoot()
    {
        GameObject newBullet = Instantiate(bullet, spawnPoint.transform.position, transform.rotation);
        Rigidbody bulletRigid = newBullet.GetComponent<Rigidbody>();
        bulletRigid.velocity = transform.forward * testSpeed;


        yield return new WaitForSeconds(8f);
        Destroy(newBullet);
        yield return null;
    }



}
