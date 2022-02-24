using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//************** INHERITANCE **************
public class SimpleSpaceshipController : Vehicle
{
    public float speed = 10.0f;
    private Rigidbody shipRb;

    // Start is called before the first frame update
    void Start()
    {
        shipRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    //************** POLYMORPHISM **************
    public override void Move()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            shipRb.AddForce(transform.forward * speed);
        }
        else
        {
            if(shipRb.velocity.magnitude > 0)
            {
                shipRb.AddForce(-transform.forward * (speed / 2));
            }

            if(shipRb.velocity.x < 0 || shipRb.velocity.y < 0 || shipRb.velocity.z < 0)
            {
                shipRb.velocity = Vector3.zero;
            }
        }

        Debug.Log("Velocity: " + shipRb.velocity);
    }
}
