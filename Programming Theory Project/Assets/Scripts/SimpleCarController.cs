using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//************** INHERITANCE **************
public class SimpleCarController : Vehicle
{
    // Wheel Meshes
    public Transform frontLeftWheelMesh;
    public Transform frontRightWheelMesh;
    public Transform rearLeftWheelMesh;
    public Transform rearRightWheelMesh;
    // Wheel Colliders
    public WheelCollider wheelFL;
    public WheelCollider wheelFR;
    public WheelCollider wheelRL;
    public WheelCollider wheelRR;
    public float maxTorque = 500f;
    public float brakeTorque = 1000f;
    public float maxWheelTurnAngle = 30f; // degrees
    public Vector3 centerOfMass = new Vector3(0f, 0f, 0f); // unchanged
    public Vector3 eulertest;
    // PRIVATE
    //************** ENCAPSULATION **************
    // acceleration increment counter
    private float torquePower { get; set; }
    // turn increment counter
    private float steerAngle { get; set; }

    private void Awake()
    {
        torquePower = 0f;
        steerAngle = 30f;
    }

    void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = centerOfMass;
    }
    
    void Update()
    {
        //************** ABSTRACTION **************
        WheelMovement();
    }
    
    void FixedUpdate()
    {
        //************** ABSTRACTION **************
        Move();
    }

    //************** POLYMORPHISM **************
    public override void Move()
    {
        // CONTROLS - FORWARD & RearWARD
        if (Input.GetKey(KeyCode.Space))
        {
            // BRAKE
            torquePower = 0f;
            wheelRL.brakeTorque = brakeTorque;
            wheelRR.brakeTorque = brakeTorque;
        }
        else
        {
            // SPEED
            torquePower = maxTorque * Mathf.Clamp(Input.GetAxis("Vertical"), -1, 1);
            wheelRL.brakeTorque = 0f;
            wheelRR.brakeTorque = 0f;
        }
        // Apply torque
        wheelRR.motorTorque = torquePower;
        wheelRL.motorTorque = torquePower;
        // CONTROLS - LEFT & RIGHT
        // apply steering to front wheels
        steerAngle = maxWheelTurnAngle * Input.GetAxis("Horizontal");
        wheelFL.steerAngle = steerAngle;
        wheelFR.steerAngle = steerAngle;
    }

    private void WheelMovement()
    {
        //changing tyre direction
        Vector3 temp = frontLeftWheelMesh.localEulerAngles;
        Vector3 temp1 = frontRightWheelMesh.localEulerAngles;
        temp.y = wheelFL.steerAngle - (frontLeftWheelMesh.localEulerAngles.z);
        frontLeftWheelMesh.localEulerAngles = temp;
        temp1.y = wheelFR.steerAngle - (frontRightWheelMesh.localEulerAngles.z);
        frontRightWheelMesh.localEulerAngles = temp1;
        // Wheel rotation
        frontLeftWheelMesh.Rotate(wheelFL.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        frontRightWheelMesh.Rotate(wheelFR.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        rearLeftWheelMesh.Rotate(wheelRL.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        rearRightWheelMesh.Rotate(wheelRR.rpm / 60 * 360 * Time.deltaTime, 0, 0);
    }
}
