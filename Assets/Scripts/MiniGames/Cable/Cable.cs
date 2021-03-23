using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cable : MonoBehaviour
{
    [SerializeField]
    GameObject nozzle;

    [SerializeField]
    GameObject cable;

    // Start is called before the first frame update
    void Start()
    {



    }

    void Stretch()
    {
        Vector3 nozzlePosition = nozzle.transform.position;

        //cable.transform.localScale()

    }

    // Update is called once per frame
    void Update()
    {
        Stretch();
    }
}
