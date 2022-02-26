using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//************** INHERITANCE **************
public class SimpleSpaceshipController : Vehicle
{
    public float horsePower = 25000f;
    private Rigidbody shipRb;
    private float maxSpeed = 300; // kph

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
            if(GetSpeed() < maxSpeed)
            {
                shipRb.AddForce(transform.forward * horsePower);
            }
        }
        else
        {
            if(GetSpeed() > 0)
            {
                shipRb.AddForce(-transform.forward * (horsePower / 2));
            }
        }

        Debug.Log("Speed: " + GetSpeed() + " kph");
    }

    private float GetSpeed()
    {
        return Mathf.Round(shipRb.velocity.magnitude * 3.6f);
    }
}
