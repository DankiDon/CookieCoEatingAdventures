using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody cookieRigidBody;
    AudioSource cookiecooSound;
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotationThrust = 100f;
    [SerializeField] AudioClip cookieNoises;
    [SerializeField] ParticleSystem superParticle;
    [SerializeField] ParticleSystem lefthandParticle;
    [SerializeField] ParticleSystem righthandParticle;
    [SerializeField] ParticleSystem leftlegParticle;
    [SerializeField] ParticleSystem rightlegParticle;
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
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            StopRotating();
        }
    }

    void StartThrusting()
    {
        cookieRigidBody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!cookiecooSound.isPlaying)
        {
            cookiecooSound.PlayOneShot(cookieNoises);
        }
        if (!superParticle.isPlaying)
        {
            superParticle.Play();
        }
    }

    void StopThrusting()
    {
        cookiecooSound.Stop();
        superParticle.Stop();
    }

    void RotateLeft()
    {
        ApplyRotation(Vector3.forward);
        if (!lefthandParticle.isPlaying && !righthandParticle.isPlaying)
        {
            lefthandParticle.Play();
            righthandParticle.Play();
        }
    }

    void RotateRight()
    {
        ApplyRotation(Vector3.back);
        if (!leftlegParticle.isPlaying && !rightlegParticle.isPlaying)
        {
            leftlegParticle.Play();
            rightlegParticle.Play();
        }
    }

    void StopRotating()
    {
        leftlegParticle.Stop();
        rightlegParticle.Stop();
        lefthandParticle.Stop();
        righthandParticle.Stop();
    }

    void ApplyRotation(Vector3 rotateDirection)
    {
        cookieRigidBody.freezeRotation = true;
        transform.Rotate(rotateDirection * rotationThrust * Time.deltaTime);
        cookieRigidBody.freezeRotation = false;
    }
}
