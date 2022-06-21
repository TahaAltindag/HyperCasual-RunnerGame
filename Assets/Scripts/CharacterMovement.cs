using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float swerveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * swerveSpeed * Time.deltaTime;
        this.transform.Translate(horizontal, 0, forwardSpeed * Time.deltaTime);
    }
}
