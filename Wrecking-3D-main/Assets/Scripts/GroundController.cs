using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Random = UnityEngine.Random;

public class GroundController : MonoBehaviour
{
    [SerializeField] private GameObject[] groundSize;
    [SerializeField] private Material[] _materials;
    void Start()
    {
        StartCoroutine(GroundBreakingTime(1));
    }

    IEnumerator GroundBreakingTime(int waitTime)
    {
        
        for (int i = 0; i < groundSize.Length-1; i++)
        {
            int randomMaterial = Random.Range(0, 4);
            MeshRenderer meshRenderer = groundSize[i].GetComponent<MeshRenderer>();
            meshRenderer.material = _materials[randomMaterial];
            yield return new WaitForSeconds(waitTime);
            groundSize[i].SetActive(false);
            yield return new WaitForSeconds(waitTime);
        }
    }

    // private void OnTriggerStay(Collider other)
    // {
    //     Debug.Log("Çarptığı sürece true kal");
    //     other.GetComponent<AISystem>().GetIsGroundCheck = true; 
    // }
    //
    // private void OnTriggerExit(Collider other)
    // {
    //     Debug.Log("çarpma bitti, false çek");
    //     other.GetComponent<AISystem>().GetIsGroundCheck = false;
    // }
}
