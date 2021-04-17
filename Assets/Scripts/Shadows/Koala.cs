using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Koala : MonoBehaviour
{
    //Public
    public Transform[] waypoints;
    public Transform player;
    public int waypointIndex;
    public ControlAndMovement controlPlayer;

    //Private
    public int waypointCountDown;

    //Call Stuff
    private NavMeshAgent navMeshAgent;
    private MeshRenderer mesh;

    // Start is called before the first frame update
    void Start()
    {
        //Call NavMeshAgent
        navMeshAgent = GetComponent<NavMeshAgent>();
        //Call MeshRenderer
        mesh = GetComponent<MeshRenderer>();
        mesh.enabled = false;

        //Give Initial Waypoint
        waypointIndex = Random.Range(0, waypoints.Length);
        navMeshAgent.SetDestination(waypoints[waypointIndex].position);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x == waypoints[waypointIndex].position.x) 
        {
            Patrol();

            if (waypointCountDown >= 3)
            {
                Sleep();
            }
            else
            {
                waypointCountDown += 1;
            }
        }

    }

    public void Patrol()
    {
        //Random Waypoint
        waypointIndex = Random.Range(0, waypoints.Length);
        //Move Toward that waypoint
        navMeshAgent.SetDestination(waypoints[waypointIndex].position);
    }

    public void Sleep()
    {
    
        if (controlPlayer.heartBeat >= 150)
        {
            Patrol();
        }
        else
        {
            //Stop Agent
            navMeshAgent.SetDestination(transform.position);
            //Invoke calls for a function after x Amount of time
            Invoke("Patrol", 5f);
            //Restart The Countdown to Sleep
            waypointCountDown = 1;
        }
    }

    public void Chase()
    {
        //Move Towards the player
        navMeshAgent.SetDestination(player.position);
    }

    
    private void OnTriggerStay(Collider collider)
    {
        //If sees the player, chase
        if (collider.tag == "Player")
        {
            Chase();
        }

        //If in lights, be visible
        if (collider.tag == "Lights")
        {
            mesh.enabled = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        //If stops seeing the player, patrol
        if (collider.tag == "Player")
        {
            Patrol();
        }

        //Exit light, turns invisible
        if (collider.tag == "Lights")
        {
            mesh.enabled = false;
        }
    }   
}