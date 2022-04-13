using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RotateAroundCar : MonoBehaviour
{
    [SerializeField] private GameObject pivotObject;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private bool isPowerUpOpen;
    [SerializeField] private GameObject ObiRope;
    [SerializeField] private GameObject robiObject;
    private Vector3 mesafe;
    public float radius;
    public float radiusSpeed = 0.5f;


    private void Start()
    {
        mesafe = new Vector3(1, 1, 1);
    }

    public bool GetPowerUp
    {
        get => isPowerUpOpen;
        set => isPowerUpOpen = value;
    }
    
    private void Update()
    {
 
        if (isPowerUpOpen)
        {
            StartCoroutine(RotateAround(55));
        }
    }

    IEnumerator RotateAround(int waitTime)
    {
       
        transform.RotateAround(pivotObject.transform.position, Vector3.up , rotationSpeed * Time.deltaTime *2 );
        yield return new WaitForSeconds(waitTime);
        isPowerUpOpen = false;
        ObiRope.GetComponent<MeshRenderer>().enabled = true;
        robiObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
