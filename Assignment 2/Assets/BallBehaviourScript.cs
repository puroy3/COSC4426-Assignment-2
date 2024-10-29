using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviourScript : MonoBehaviour
{
    public Transform basketball;
    public Transform hoopTarget;
    public float deltaTime = 0;
    public bool isBallFlying = true;

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
        if(isBallFlying)
            ThrowBall();
    }

    void ThrowBall() {

       

        deltaTime += Time.deltaTime;
        float duration = 0.9f;
        float t01 = deltaTime / duration;

        // move target A to B
        Vector3 A = basketball.position;
        Vector3 B = hoopTarget.position;
        Vector3 pos = Vector3.Lerp(A, B, t01);

        // move in arc
        Vector3 arc = Vector3.up * 1 * Mathf.Sin(t01 * 3.14f);
        
        basketball.position = pos + arc;
       
         // Play throwSound only once when the ball is first thrown
        if (!hasPlayedThrowSound)
        {
            musicSource.clip = throwSound;
            musicSource.Play();
            hasPlayedThrowSound = true;  // Set the flag to true to prevent replaying
        }
	

        // moment when ball arrives at the target
        if (t01 >= 1) {
	    musicSource2.clip = Goal;
            musicSource2.Play();

            isBallFlying = false;
            basketball.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

}
