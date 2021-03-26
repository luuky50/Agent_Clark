using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Cable : MonoBehaviour
{
    [SerializeField]
    GameObject nozzle;

    [SerializeField]
    GameObject cable;

    Vector3 nozzleHandPosition;

    //float offSet = 1.5f;

    float distanceToFill;


    void Start()
    {
        Throwable throweable = nozzle.GetComponent<Throwable>();
        throweable.onHeldUpdate.AddListener((Hand hand) =>
        {
            Stretch();
        });
        throweable.onDetachFromHand.AddListener(() =>
        {
            Stretch();
        });
    }
    public void Stretch()
    {
        //Debug.Log("currentAttachtedObject:" + hand.currentAttachedObject.transform.localPosition);
        //if (hand.currentAttachedObject != null)
        //{
        //TODO: When grabbing the object in VR extend the cable to the nozzle
        nozzleHandPosition = nozzle.transform.localPosition;//hand.transform.localPosition;

        distanceToFill = Vector3.Distance(nozzleHandPosition, cable.transform.localPosition);
        //Debug.Log("Distance" + distanceToFill);

        cable.transform.localScale = new Vector3(distanceToFill, 1, 1);
        //}
    }
}
