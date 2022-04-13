using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AISystem : MonoBehaviour
{
    [SerializeField] private Transform[] target;
    [SerializeField] private bool isGroundCheck = false;
    [SerializeField] private float lookRadius = 5f;
    
    private NavMeshAgent _navMeshAgent;
    private int _randomCarLookAndRun;
    private bool _isNavMeshAgentActive = true;

    public bool GetIsGroundCheck
    {
        get => isGroundCheck;
        set => isGroundCheck = value;
     
    }
    
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _randomCarLookAndRun = Random.Range(0,1);
        Debug.Log(_randomCarLookAndRun);

    }

    void Update()
    {
        if (!_isNavMeshAgentActive)
        {
            return;
        }
        AIDirectionToFace();
       
    }
    
    private void AIDirectionToFace()
    {
        _navMeshAgent.destination = target[_randomCarLookAndRun].position;
        Vector3 directionToFace = target[_randomCarLookAndRun].position - transform.position; 
        transform.rotation = Quaternion.LookRotation(directionToFace);
        
        float distance = Vector3.Distance(target[_randomCarLookAndRun].position, transform.position);
 
        if (distance <= lookRadius)
        {
            Debug.Log("Set destination girdi mi");
            _navMeshAgent.SetDestination(target[_randomCarLookAndRun].position); // Mesafe 10 dan azsa takip et.
        }
    }
    

    public void CloseNavMeshAgent() // Objenin alan dışı kalabilmesi için
    {
        GetComponent<NavMeshAgent>().enabled = false;
        _isNavMeshAgentActive = false;
    }
    public void OpenNavMeshAgent()
    {
        GetComponent<NavMeshAgent>().enabled = true;
        _isNavMeshAgentActive = true;
    }


    
    public IEnumerator OpenAndCloseMesh(int waitTime)
    {
        Debug.Log("Enumerator Girebildik mi");
        CloseNavMeshAgent();
        yield return new WaitForSeconds(waitTime);
        // OpenNavMeshAgent();

    }

    public void DestroyYourself()
    {
        Debug.Log("Yok olmaya mı girdin");
        if (gameObject == null)
        {
            Destroy(gameObject);
        }
 
    }
    
    
    // public void OpennAndCloseNavMesh()
    // {
    //     if (!_characterController.isGrounded)
    //     {
    //         Debug.Log("Zeminde değilse");
    //         CloseNavMeshAgent();
    //     }
    //     else
    //     {
    //         Debug.Log("zemindeyse");
    //         OpenNavMeshAgent();
    //     }
    // }
}
