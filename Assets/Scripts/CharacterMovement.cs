using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float swerveSpeed;
    [SerializeField] public GameObject wall;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        wall.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * swerveSpeed * Time.deltaTime;
        this.transform.Translate(horizontal, 0, forwardSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {

        forwardSpeed = swerveSpeed = 0f;
        animator.SetBool("isFinished", true);
        wall.SetActive(true);
    }
}
