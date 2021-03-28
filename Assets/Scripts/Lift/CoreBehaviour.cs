using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<DropPoint>())
        {
            DropPoint newDropPoint = other.gameObject.GetComponent<DropPoint>();
            newDropPoint.UnlockLift(gameObject);
        }
    }
}
