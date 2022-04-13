using System;
using System.Collections;
using System.Collections.Generic;
using Obi;
using UnityEngine;
using UnityEngine.AI;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float force; // Zıplatma
    [SerializeField] private float forcex; // ileri yönde hareket verme
    [SerializeField] private float explosionRadius;
    // [SerializeField] private CameraShake _cameraShake;
    
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("AI")) return;
        rb = collision.gameObject.GetComponent<Rigidbody>();
        Debug.Log("Allahımya");
        rb.AddExplosionForce(force, collision.gameObject.transform.position, explosionRadius, 0.05f, ForceMode.Impulse);
        rb.AddForce(transform.forward * forcex);

        var openAndCloseMesh = collision.gameObject.GetComponent<AISystem>().OpenAndCloseMesh(2);
        StartCoroutine(openAndCloseMesh);


    }
    
}
