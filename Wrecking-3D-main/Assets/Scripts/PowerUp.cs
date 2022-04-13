using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private GameObject fakeObject;
    [SerializeField] private GameObject robiObject;
    [SerializeField] private GameObject obiRope;
     private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Respawn"))
        {
            Destroy(other.gameObject); 
            DestroyObject();
        }

    }
     private void DestroyObject()
     {
         robiObject.SetActive(false);
         obiRope.GetComponent<MeshRenderer>().enabled = false;
         fakeObject.SetActive(true);
         fakeObject.GetComponent<RotateAroundCar>().GetPowerUp = true;
     }
}
