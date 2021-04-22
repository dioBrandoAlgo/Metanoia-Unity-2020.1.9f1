using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class NavMesh : MonoBehaviour
{
    public List<Waypoints> waypoints;
    private NavMeshAgent agent;
    private int currWaypoint;
    public Waypoints target;
    public Waypoints origin;
    private List<Waypoints> path;

    private void MoveAgent()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            currWaypoint++;
            SetDestination();
        }

    }

    private void SetDestination()
    { 
        path = Pathfinding.FindPath(origin, target, waypoints);
        agent.SetDestination(path[currWaypoint % path.Count].transform.position);
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        MoveAgent();
    }
}
