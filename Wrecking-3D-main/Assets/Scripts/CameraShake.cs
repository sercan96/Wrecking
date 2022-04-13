using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float power = 0.7f;
    [SerializeField] private float duration = 0.2f;
    [SerializeField] private Transform camera;
    [SerializeField] private float slowDownAmount = 0.5f;
    [SerializeField] private bool isShake = false;
    [SerializeField] private GameObject targetPosition;

    private Vector3 startPosition;
    private float initialDuration;
    
    public bool GetIsShake
    {
        get => isShake;
        set => isShake = value;
    }


    void Start()
    {
        if (Camera.main != null) camera = Camera.main.transform;
        startPosition = camera.transform.position;
        // camera = Camera.main.transform;
        // startPosition = camera.localPosition;
        initialDuration = duration;
    }
    
    void Update()
    {
        if (isShake)
        {
            if (duration > 0)
            {
                camera.transform.position = startPosition  + Random.insideUnitSphere *power;
                duration -= Time.deltaTime * slowDownAmount;
            }
            else
            {
                Debug.Log("kaç kere");
                isShake = false;
                duration = initialDuration;
                camera.transform.position = startPosition;
            }
        }
    }
}
