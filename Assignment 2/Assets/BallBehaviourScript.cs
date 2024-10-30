using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviourScript : MonoBehaviour
{
    public Rigidbody basketball;  // Assign the basketball Rigidbody in the inspector
    public Transform hoopTarget;  // Assign the hoop's position
    
    [Header("------Audio Source------")]
    [SerializeField] AudioSource ThrowBallSource;

    [Header("------Audio Clip------")]
    public AudioClip ThrowBallClip;  

    // Variables
    public float deltaTime = 0;

    //Audio
    [Header("------Audio Source------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource musicSource2;

    [Header("------Audio Clip------")]
    public AudioClip throwSound;
    public AudioClip Goal;

    // Flag to check if throw sound has played
    private bool hasPlayedThrowSound = false;

 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ThrowBall();
    }

<<<<<<< Updated upstream
    void ThrowBall()
    {
        // Use ThrowBallSource instead of musicSource
        ThrowBallSource.clip = ThrowBallClip; 
        ThrowBallSource.Play();
        
=======
    void ThrowBall() {

       

>>>>>>> Stashed changes
        deltaTime += Time.deltaTime;
        float duration = 0.9f;
        float t01 = deltaTime / duration;

        // Move to target
        Vector3 A = basketball.position;
        Vector3 B = hoopTarget.position;
        Vector3 pos = Vector3.Lerp(A, B, t01);

        // Move in arc
        Vector3 arc = Vector3.up * 5 * Mathf.Sin(t01 * 3.14f);

        basketball.position = pos + arc;
       
         // Play throwSound only once when the ball is first thrown
        if (!hasPlayedThrowSound)
        {
            musicSource.clip = throwSound;
            musicSource.Play();
            hasPlayedThrowSound = true;  // Set the flag to true to prevent replaying
        }
	

        // Moment when ball arrives at the target
        if (t01 >= 1) {
<<<<<<< Updated upstream
=======
	    musicSource2.clip = Goal;
            musicSource2.Play();

            isBallFlying = false;
>>>>>>> Stashed changes
            basketball.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}