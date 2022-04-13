using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;

public class GroundDestroyingController : MonoBehaviour
{
    [SerializeField] private GameObject[] groundlist1 = new GameObject[30];
    [SerializeField] private GameObject[] groundlist2 = new GameObject[25];
    [SerializeField] private GameObject[] groundlist3 = new GameObject[20];
    private int j = 0;
    private void Start()
    {
        GroundFinishedTime(groundlist1);
        // StartCoroutine(GroundBreakingTime(0.5f,groundlist1));
        // StartCoroutine(GroundBreakingTime(0.5f,groundlist2));
        // StartCoroutine(GroundBreakingTime(0.5f,groundlist3));
    }

    void GroundFinishedTime(GameObject[] list)
    {
        while (j < list.Length)
        {
            // int randomNumber = Random.Range(0, list.Length - 1);
            // int yoksa = Array.IndexOf(list, randomNumber); // aranılan sayı aynı değilse
            // if (yoksa ==-1)
            // {
            //     list[randomNumber].SetActive(false);
            //     j++;
            // }
            // list[randomNumber].SetActive(false);
            //  j++;

        }

        // for (int i = 0; i < list.Length; i++)
        // {
        //     list[i].SetActive(false);
        // }
    }
    
    
    IEnumerator GroundBreakingTime(float waitTime,GameObject[] list)
    {
        
        // for (int i = 0; i < list.Length-1; i++) 
        // {
        //     yield return new WaitForSeconds(waitTime);
        //     list[Random.Range(0,list.Length -1)].SetActive(false);
        //     yield return new WaitForSeconds(waitTime);
        // }

     
        while (j < list.Length)
        {
            int randomNumber = Random.Range(0, list.Length - 1);
            int yoksa = Array.IndexOf(list, randomNumber); // aranılan sayı aynı değilse
            if (yoksa ==-1)
            {
                list[randomNumber].SetActive(false);
                j++;
            }
            yield return new WaitForSeconds(waitTime);
            
        }
        
       
    }

}
