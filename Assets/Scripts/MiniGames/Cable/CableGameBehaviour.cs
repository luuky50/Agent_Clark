using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableGameBehaviour : MonoBehaviour
{
    public List<GameObject> endPoints = new List<GameObject>();

    public Dictionary<int, Color> _colors = new Dictionary<int, Color>() {
        {0, Color.blue},
        {1, Color.red},
        {2, Color.green}
    };

    readonly List<int> colorsIndex = new List<int>();

    public int secondsToDestroy;

    public int completedCables = 0;

    private MeshRenderer effectObject;

    private void OnEnable()
    {
        effectObject = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetChild(3).GetComponentInChildren<MeshRenderer>();
        effectObject.enabled = true;
        SetEndColors();
    }

    private void SetEndColors()
    {
        bool complete = false;
        while (!complete)
        {
            int randomIndex = Random.Range(0, _colors.Count);
            if (!colorsIndex.Contains(randomIndex))
            {
                colorsIndex.Add(randomIndex);
            }


            if (colorsIndex.Count == _colors.Count) { complete = true; }
        }

        for (int i = 0; i < colorsIndex.Count; i++)
        {
            endPoints[i].GetComponent<Renderer>().material.color = _colors[colorsIndex[i]];
            endPoints[i].GetComponent<EndPoint>().currentEnd = colorsIndex[i];
        }
    }


    public IEnumerator Completed()
    {
        //TODO: Turn EFFECT on
        yield return new WaitForSeconds(secondsToDestroy);
        effectObject.enabled = false;
        MiniGameManager.instance.EndMiniGame();
    }




}
