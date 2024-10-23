using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviourScript : MonoBehaviour
{
    public Rigidbody basketball;  // Assign the basketball Rigidbody in the inspector
    public Transform hoopTarget;  // Assign the hoop's position
    // variables
    public float deltaTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ThrowBall();
    }

    void ThrowBall()
    {
        deltaTime += Time.deltaTime;
        float duration = 0.9f;
        float t01 = deltaTime / duration;

        // move to target
        Vector3 A = basketball.position;
        Vector3 B = hoopTarget.position;
        Vector3 pos = Vector3.Lerp(A, B, t01);

        // move in arc
        Vector3 arc = Vector3.up * 5 * Mathf.Sin(t01 * 3.14f);

        basketball.position = pos + arc;

        // moment when ball arrives at the target
        if (t01 >= 1) {
            basketball.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

}
