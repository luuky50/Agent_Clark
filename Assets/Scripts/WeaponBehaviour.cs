﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class WeaponBehaviour : MonoBehaviour
{
    public SteamVR_Action_Boolean shoot = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Shoot");
    private SteamVR_Input_Sources inputSource;

    public GameObject bullet;
    public GameObject barrel;
    public float testSpeed = 4;
    private GameObject throwable;
    private Throwable throwableGun;
    

    private void Start()
    {
        throwable = gameObject;
        throwableGun = throwable.GetComponent<Throwable>();
    }

    private void Update()
    {
        if (throwableGun.canShoot && shoot.GetStateDown(inputSource))
        {
            StartCoroutine(Shoot());
        }
    }



    IEnumerator Shoot()
    {
        GameObject newBullet = Instantiate(bullet, barrel.transform.position, transform.rotation);
        Rigidbody bulletRigid = newBullet.GetComponent<Rigidbody>();
        bulletRigid.velocity = transform.forward * testSpeed;


        yield return new WaitForSeconds(0.5f);
        Destroy(newBullet);
        yield return null;
    }



}
