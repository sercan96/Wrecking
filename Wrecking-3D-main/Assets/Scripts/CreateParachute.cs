using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class CreateParachute : MonoBehaviour
{
    [SerializeField] private GameObject parachutePrefab;
    void Start()
    {
        InvokeRepeating(nameof(GetParachute),Random.Range(0,5),10);
    }
    
    void GetParachute()
    {
        Instantiate(parachutePrefab,new Vector3(Random.Range(-3,3),10f,Random.Range(-3,3)),parachutePrefab.transform.rotation);
    }
    
   
}
