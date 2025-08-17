using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Health))]
public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 2.8f;
    public float attackRange = 1.6f;
    public float dps = 6f;
    public float attackCooldown = 0.8f;
    float cd;
    NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed;
        agent.stoppingDistance = attackRange * 0.8f;
    }

    void Update()
    {
        if (!target) return;
        float dist = Vector3.Distance(transform.position, target.position);

        if (dist > attackRange) agent.SetDestination(target.position);
        else
        {
            agent.ResetPath();
            transform.LookAt(target);
            if (cd <= 0f)
            {
                var hp = target.GetComponent<Health>();
                if (hp) hp.TakeDamage(dps);
                cd = attackCooldown;
            }
        }
        if (cd > 0f) cd -= Time.deltaTime;
    }
}
