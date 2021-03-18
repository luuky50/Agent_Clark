using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class SwarmManager : SingletonComponent<SwarmManager>
{
public    GameObject swarm;
    bool hasShot = false;
    Vector3 beginPoint = new Vector3(0, 5f, 0);
    Vector3 endPoint = new Vector3(0, 0, 53.508f);
    float timer = 0;
    float timeToDestroy = .8f;
  public  ParticleSystem boom;
    void Start()
    {
        DOTween.Init();
    }

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { ShootTheSwarm(); }
        


        if (hasShot) 
        {
            timer +=Time.deltaTime;
            if (timer > timeToDestroy && timeToDestroy + .1f > timer) {

                Destroy();
            }
        }
      
    }

    public void ShootTheSwarm() {
        MoveSwarm();
        hasShot = true;
        timer = 0;
    }

    void MoveSwarm() {
        swarm.transform.localPosition = beginPoint;
        swarm.transform.gameObject.SetActive(true);
        swarm.transform.DOLocalMove(endPoint, .8f);
       
        
    }
    private void Destroy()
    {
        hasShot = false;
        boom.gameObject.SetActive(true);
        swarm.transform.gameObject.SetActive(false);
        boom.Play();
        DamageManager.instance.DamageToPlayer(50);
        //main.loop = false;
    }
}
