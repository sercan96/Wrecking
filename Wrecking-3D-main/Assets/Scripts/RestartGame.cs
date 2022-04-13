using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            SceneManager.LoadScene(0);
        else if(collision.gameObject.CompareTag("AI"))
            collision.gameObject.GetComponent<AISystem>().DestroyYourself(); // Hangi obje değerse onu yok et.
    }
}
