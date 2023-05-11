using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody cookieRigidBody;
    AudioSource cookiecooSound;
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotationThrust = 100f;
    // Start is called before the first frame update
    void Start()
    {
        cookieRigidBody = GetComponent<Rigidbody>();
        cookiecooSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //Debug.Log("Pressed SPACE - Thrusting");
            cookieRigidBody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if(!cookiecooSound.isPlaying)
            {
                cookiecooSound.Play();
            }
        }
        else
        {
            cookiecooSound.Stop();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(Vector3.forward);
            //Debug.Log("Pressed A - Rotating Left");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(Vector3.back);
            //Debug.Log("Pressed D - Rotating Right");
        }
    }

    void ApplyRotation(Vector3 rotateDirection)
    {
        cookieRigidBody.freezeRotation = true;
        transform.Rotate(rotateDirection * rotationThrust * Time.deltaTime);
        cookieRigidBody.freezeRotation = false;
    }
}
