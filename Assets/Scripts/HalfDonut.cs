using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfDonut : MonoBehaviour
{
    private Vector3 startPosition;
    [SerializeField] private float frequency = 1f;
    [SerializeField] private float magnitude = 0.12f;
    [SerializeField] private float offset = 2f;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPosition + transform.right * Mathf.Sin(Time.time * frequency * offset) * magnitude;
    }
}
