using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarJoystick : MonoBehaviour
{
    [SerializeField] private FixedJoystick _fixedJoystick;
    
    public float steerAngle = 20;
    public float Traction =1;
    
    private Vector3 moveForce;
    public float moveSpeed = 20;
    private int maxSpeed = 15;
    private float drag = 0.98f;
    
    
    void Start()
    {
        moveForce = new Vector3(_fixedJoystick.Horizontal, 0f, 0f);
    }

    void FixedUpdate()
    {
        //Moving
        moveForce += transform.right * moveSpeed * _fixedJoystick.Vertical* Time.fixedDeltaTime;
        transform.position += moveForce * Time.deltaTime;

        float steerInput = _fixedJoystick.Horizontal;
        transform.Rotate(Vector3.up * steerInput * moveForce.magnitude *steerAngle *Time.fixedDeltaTime);
        
        // Drag and max.Limit
        moveForce *= drag;
        moveForce = Vector3.ClampMagnitude(moveForce, maxSpeed);
            
        // Traction  (Sürüklenme yönü kendini yavaşça düzeltir.)
        Debug.DrawRay(transform.position,moveForce.normalized *3);
        Debug.DrawRay(transform.position,transform.right *3,Color.blue);
        moveForce = Vector3.Lerp(moveForce.normalized, transform.right, Traction * Time.fixedDeltaTime) *
                    moveForce.magnitude;
    }
}
