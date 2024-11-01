using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallBehaviourScript : MonoBehaviour
{
    private Rigidbody basketballRb;
    private Transform basketball;
    private Transform goalDetector;
    private Vector3 initialPosition;
    public float horizontalForce;
    public float verticalForce;
    private bool simulationPaused = true;

    //Audio
    [Header("------Audio Source------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource musicSource2;

    [Header("------Audio Clip------")]
    public AudioClip throwSound;
    public AudioClip Goal;

    private TextMeshProUGUI Instructions; //Reference for TMP text for instructions

    //Sets the initial values for the ball.
    void Start()
    {
        horizontalForce = 1.68f;
        verticalForce = 2.5f;

        //Get basketball and goal detector objects by name
        basketball = GameObject.Find("Basketball").transform;
        goalDetector = GameObject.Find("GoalDetector").transform;

        //Find and set the Instructions TMP text object under Canvas
        Instructions = GameObject.Find("Canvas/Instructions").GetComponent<TextMeshProUGUI>();

        basketballRb = basketball.GetComponent<Rigidbody>();
        basketballRb.isKinematic = true;

        //Saves the initial location of the ball for when the phenomenon is reset.
        initialPosition = basketball.position;

        simulationPaused = true; //Set isRunning to true at the start to show instructions
        Instructions.gameObject.SetActive(true); //Show instructions initially
    }

    //Handle user input for shooting and resetting
    void Update()
    {
        //Display instructions if isRunning is true
        Instructions.gameObject.SetActive(simulationPaused);

        //Spacebar to shoot
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootBall();
        }

        //R key to reset the ball position
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetBall();
        }
    }

    //Apply force to shoot the ball in a set direction, with audio feedback
    void ShootBall()
    {
        simulationPaused = false; //Set isRunning to false once ball is shot

        //Enable physics, calculate direction to goal, and apply horizontal and vertical forces
        basketballRb.isKinematic = false;
        Vector3 direction = (goalDetector.position - basketball.position).normalized;
        Vector3 horizontalDirection = new Vector3(direction.x, 0, direction.z);
        Vector3 verticalDirection = Vector3.up;

        basketballRb.AddForce(horizontalDirection * horizontalForce, ForceMode.Impulse);
        basketballRb.AddForce(verticalDirection * verticalForce, ForceMode.Impulse);

        musicSource.clip = throwSound;
        musicSource.Play();
    }

    //Detect if the ball goes through the goal and play the goal sound
    private void OnTriggerEnter(Collider other)
    {
        //Play goal sound only if it touches GoalDetector
        if (other.transform == goalDetector)
        {
            musicSource2.clip = Goal;
            musicSource2.Play();
        }
    }

    //Reset the ball’s position, velocity, and state to its initial values for another shot
    private void ResetBall()
    {
        simulationPaused = true; 

        //Temporarily disable kinematic to clear velocity and spin, reset position, then re-enable
        basketballRb.isKinematic = false;
        basketballRb.velocity = Vector3.zero;
        basketballRb.angularVelocity = Vector3.zero;
        basketball.position = initialPosition;
        basketballRb.isKinematic = true;
    }
}
