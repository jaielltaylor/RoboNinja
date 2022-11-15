using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomAgent : MonoBehaviour
{
    [SerializeField]
    public List<Transform> goals;
    public GameObject playerAgent;
    public NavMeshAgent patrol;
    private int currentDestination;

    void Start()
    {
        patrol = playerAgent.gameObject.transform.GetComponent<NavMeshAgent>();
        playerAgent.GetComponent<Animator>().Play("Patrol");
        patrol.destination = goals[0].position;
        currentDestination = 1;
    }
    
    void Update()
    {
        if (patrol.remainingDistance <= 2)
        {
            patrol.destination = goals[currentDestination].position;
            currentDestination += 1;
            if (currentDestination == 3)
            {
                currentDestination = 0;
            }
        }
    }
    
}
