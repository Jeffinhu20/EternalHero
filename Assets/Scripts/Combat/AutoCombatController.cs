using UnityEngine;

[RequireComponent(typeof(PlayerAgent))]
public class AutoCombatController : MonoBehaviour
{
    public float detectRadius = 10f;
    public float attackRange = 2.2f;
    public float dps = 12f;
    public float attackCooldown = 0.5f;
    public LayerMask enemyMask;
    float cd;
    PlayerAgent agent;
    Transform target;

    void Awake() { agent = GetComponent<PlayerAgent>(); }

    void Update()
    {
        if (!target || Vector3.Distance(transform.position, target.position) > detectRadius || !target.gameObject.activeInHierarchy)
            target = FindClosestEnemy();

        if (target)
        {
            float dist = Vector3.Distance(transform.position, target.position);
            if (dist > attackRange) agent.MoveTo(target.position);
            else
            {
                agent.Stop();
                transform.LookAt(target);
                if (cd <= 0f) { Hit(target); cd = attackCooldown; }
            }
        }
        if (cd > 0f) cd -= Time.deltaTime;
    }

    Transform FindClosestEnemy()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, detectRadius, enemyMask);
        float best = float.MaxValue; Transform t = null;
        foreach (var h in hits)
        {
            float d = (h.transform.position - transform.position).sqrMagnitude;
            if (d < best) { best = d; t = h.transform; }
        }
        return t;
    }

    void Hit(Transform enemy)
    {
        var hp = enemy.GetComponent<Health>();
        if (hp) hp.TakeDamage(dps);
    }
}
