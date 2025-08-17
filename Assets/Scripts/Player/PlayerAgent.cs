using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Health))]
public class PlayerAgent : MonoBehaviour
{
    public float moveSpeed = 3.5f;
    NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed;
        agent.stoppingDistance = 1.8f;
        agent.autoBraking = false;
    }

    public void MoveTo(Vector3 pos) => agent.SetDestination(pos);
    public void Stop() => agent.ResetPath();
}
