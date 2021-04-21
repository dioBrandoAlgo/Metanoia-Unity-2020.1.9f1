using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class FIFKoala : MonoBehaviour
{
    //Public
    public Transform[] waypoints;

    public GameObject UI;
    public RawImage hifFifImageUI;
    public Text dialogTextUI;
    

    //Private
    private string[] sentences = { "aa", "bb" };
    private int sentencesIndex = 0;
    private int waypointIndex = 0;

    private string[] state = { "walking", "talking", "waiting" };
    private int stateIndex;

    //GetStuff
    private NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        //Call NavMesh
        navMeshAgent = GetComponent<NavMeshAgent>();

        //Give Initial Waypoint
        navMeshAgent.SetDestination(waypoints[waypointIndex].position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (stateIndex == 0)
        {
            Walking();

        }
        if(stateIndex == 1)
        {
            Talking();
        }
        if (stateIndex == 2)
        {
            Waiting();
        }



    }

    public void Walking()
    {
        navMeshAgent.SetDestination(waypoints[waypointIndex].position);
        if (transform.position.x == waypoints[waypointIndex].position.x)
        {
            if (waypointIndex == (waypoints.Length - 1))
            {
                waypointIndex = 0;
            }
            else
            {
                waypointIndex += 1;
            }
        }
    }

    public void Talking()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            dialogTextUI.text = sentences[sentencesIndex];
            if (Input.GetKeyDown(KeyCode.Space))
            {
                sentencesIndex += 1;
            }
        }
    }

    public void Waiting()
    {
        navMeshAgent.SetDestination(transform.position); 
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Player") {
            if (Input.GetKeyDown(KeyCode.E))
            {
                stateIndex += 1;
            }
        }
    }
}
