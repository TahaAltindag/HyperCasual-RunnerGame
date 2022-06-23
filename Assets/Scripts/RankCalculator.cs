using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RankCalculator : MonoBehaviour
{
    public Transform[] competitors;
    private float[] distances;

    Dictionary<int, float> opponents = new Dictionary<int, float>();

    void Start()
    {
        
        distances = new float[11];
        Sort();
        for (int i = 0; i < 11; i++)
        {
            Debug.Log(distances[i]);
        }
    }
    void Sort()
    {
        for (int i = 0; i < competitors.Length; i++)
        {

            distances[i] = Vector3.Distance(competitors[i].position, transform.position);
            opponents.Add(i, distances[i]);
        }
       // System.Array.Sort();

    }
    
}
