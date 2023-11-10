using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;

    [SerializeField] private float mainThrust = 1000f;
    [SerializeField] private float rotationThrust = 1f;
    [SerializeField] private AudioClip mainEngine;

    [SerializeField] private ParticleSystem mainEngineParticles;
    [SerializeField] private ParticleSystem leftThrusterParticles;
    [SerializeField] private ParticleSystem rightThrusterParticles;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }
    
    private void OnDisable()
    {
        mainEngineParticles.Stop();
        StopSideParticles();
    }

    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            // Make it thrust up
            StartThrusting();
        }
        else
        {
            // Stop when not pressing space
            StopThrusting();
        }
    }

    private void StartThrusting()
    {
        rb.AddRelativeForce(mainThrust * Time.deltaTime * Vector3.up);

        // Trigger particle
        if (!mainEngineParticles.isPlaying)
        {
            mainEngineParticles.Play();
        }

        // Audio play
        if (!audioSource.isPlaying && mainEngine)
        {
            audioSource.PlayOneShot(mainEngine);
        }
    }
    
    private void StopThrusting()
    {
        mainEngineParticles.Stop();
        audioSource.Stop();
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A)) // Right rotation
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D)) // Left rotation
        {
            RotateRight();
        }
        else
        {
            StopSideParticles();
        }
    }

    private void StopSideParticles()
    {
        leftThrusterParticles.Stop();
        rightThrusterParticles.Stop();
    }

    private void RotateLeft()
    {
        ApplyRotation(rotationThrust);

        // Trigger particles
        if (!leftThrusterParticles.isPlaying)
        {
            leftThrusterParticles.Play();
        }
    }

    private void RotateRight()
    {
        ApplyRotation(-rotationThrust);

        // Trigger particles
        if (!rightThrusterParticles.isPlaying)
        {
            rightThrusterParticles.Play();
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; //so that we can manually rotate
        transform.Rotate(rotationThisFrame * Time.deltaTime * Vector3.forward);
        rb.freezeRotation = false; //so the physics system can take over
    }  
}
