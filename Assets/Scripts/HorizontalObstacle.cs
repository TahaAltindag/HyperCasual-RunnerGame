using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalObstacle : MonoBehaviour
{
    private Vector3 startPosition;
    [SerializeField] private float frequency = 3f;
    [SerializeField] private float magnitude = 1f;
    [SerializeField] private float offset = 1f;


    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPosition + transform.forward * Mathf.Sin(Time.time * frequency * offset) * magnitude;
    }
}
