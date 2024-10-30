using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviourScript : MonoBehaviour
{
    private Rigidbody basketballRb;
    private bool isShot = false;
    public Transform hoopTarget;  //reference to hoop
    public float horizontalForce = 9f;
    public float verticalForce = 15f;
    
    void Start()
    {
        basketballRb = GetComponent<Rigidbody>();
        basketballRb.isKinematic = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isShot)  //spacebar to shoot ball
        {
            isShot = true;
            ShootBall();
        }
    }
    void ShootBall()
    {
        basketballRb.isKinematic = false;  //enables physics
        Vector3 direction = (hoopTarget.position - transform.position).normalized;  //direction points to hoop
        Vector3 horizontalDirection = new Vector3(direction.x, 0, direction.z);     //horizontal direction towards hoop
        Vector3 verticalDirection = Vector3.up;     //vertical direction (upward)
        basketballRb.AddForce(horizontalDirection * horizontalForce, ForceMode.Impulse);    //impulse force - applied once
        basketballRb.AddForce(verticalDirection * verticalForce, ForceMode.Impulse);        //impulse force - applied once
    }
}
