using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float swerveSpeed;
    [SerializeField] public GameObject wall;
    Animator animator;
    Rigidbody rb;
    private bool isBouncing = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
       // wall.SetActive(false);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isBouncing)
        {
            float horizontal = Input.GetAxis("Horizontal") * swerveSpeed * Time.deltaTime;
            this.transform.Translate(horizontal, 0, forwardSpeed * Time.deltaTime); 
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "FinishLine")
        {
            forwardSpeed = swerveSpeed = 0f;
            animator.SetBool("isFinished", true);
            wall.SetActive(true); 
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "stick")
        {
            float bounce = 100f;
            rb.AddForce(collision.contacts[0].normal * bounce);
            isBouncing = true;
            Invoke("StopBounce", 0.3f);
        }
    }
    void StopBounce()
    {
        isBouncing = false;
    }
}
