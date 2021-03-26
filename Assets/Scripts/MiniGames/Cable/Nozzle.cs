using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Nozzle : MonoBehaviour
{
    [SerializeField]
    private CableGameBehaviour cableGameBehaviour;

    bool isConnected = false;
    public int cableID;

    private void OnEnable()
    {
        isConnected = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<EndPoint>() != null)
        {
            if (cableID == other.gameObject.GetComponent<EndPoint>().currentEnd && !isConnected)
            {
                isConnected = true;
                if (gameObject.GetComponent<Interactable>().attachedToHand != null)
                {
                    gameObject.GetComponent<Interactable>().attachedToHand.DetachObject(this.gameObject, true);
                    gameObject.GetComponent<Throwable>().onDetachFromHand.Invoke();
                    gameObject.GetComponent<MeshCollider>().enabled = false;
                }

                cableGameBehaviour.completedCables++;

                if (cableGameBehaviour.completedCables == 3)
                {
                    StartCoroutine(cableGameBehaviour.Completed());
                }
                Debug.Log("You put the good cable on");
            }
            else if (cableID != other.gameObject.GetComponent<EndPoint>().currentEnd)
            {
                Debug.Log("You put the wrong cable on");
            }
        }
        else
        {
            Debug.Log("colliding with:" + other.gameObject);
        }
        
    }
}
