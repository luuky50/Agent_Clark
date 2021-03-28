using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class DropPoint : MonoBehaviour
{
    public void UnlockLift(GameObject objectToSend)
    {
        if(objectToSend.name == "Core")
        {
            LiftManager.instance.upButton.GetComponent<HoverButton>().onButtonDown.AddListener((Hand hand) =>
            {
                LiftManager.instance.CloseLift("EndScene");
            });

        }
        else if(objectToSend.name == "The_Striker")
        {
            LiftManager.instance.upButton.GetComponent<HoverButton>().onButtonDown.AddListener((Hand hand) =>
            {
                LiftManager.instance.CloseLift("AI");
            });
        }
    }
}
