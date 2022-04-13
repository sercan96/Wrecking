using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;
using Vector3 = UnityEngine.Vector3;

public class CarDriftController : MonoBehaviour
{
    public float moveSpeed = 20;
    public float steerAngle = 20;
    public float Traction =1;
    
    [SerializeField] private Vector3 moveForce;

    public Vector3 GetMoveForce
    {
        get => moveForce;
    }
    private int maxSpeed = 15;
    private float drag = 0.98f;
    

    void Start()
    {
        moveForce = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
    }

    void FixedUpdate()
    {
        //Moving
        moveForce += transform.right * moveSpeed * Input.GetAxis("Vertical")* Time.fixedDeltaTime;
        transform.position += moveForce * Time.deltaTime;

        float steerInput = Input.GetAxis("Horizontal");
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
