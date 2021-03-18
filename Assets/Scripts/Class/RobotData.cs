using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Robot", menuName = "Robot Creation/Robot")]
public class RobotData : ScriptableObject
{
    public string robotName;
    public float robotHealth;
    public float damage;
    public GameObject robotGameObject;
    public float sideWaysMultiplier;
    public float forwardMultiplier;



}
