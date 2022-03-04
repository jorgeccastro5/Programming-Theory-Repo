using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//************** INHERITANCE **************
public class SimpleSpaceshipController : Vehicle
{
    public float horsePower = 25000f;
    private Rigidbody shipRb;
    private float maxSpeed = 300; // kph
    [SerializeField] private float turnSpeed = 100f;
    [SerializeField] private float yAxisOffset = 2f;
    [SerializeField] private float maxYPosition = 4f;
    [SerializeField] private float yPositionOriginal = 2f;

    // Start is called before the first frame update
    void Start()
    {
        shipRb = GetComponent<Rigidbody>();
        transform.position = new Vector3(transform.position.x, yPositionOriginal, transform.position.z);
    }

    void Update()
    {
        Move();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Accelerate();
    }

    //************** POLYMORPHISM **************
    public override void Move()
    {
        /*float verticalInput = Input.GetAxis("Vertical");
        transform.Rotate(transform.right, verticalInput * turnSpeed * Time.deltaTime);*/

        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(transform.up, horizontalInput * turnSpeed * Time.deltaTime);
    }

    private void Accelerate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (GetSpeed() < maxSpeed)
            {
                shipRb.AddForce(transform.forward * horsePower);
            }
        }
        else
        {
            if (GetSpeed() > 0)
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
