using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;
    public int enemiesPerWave = 6;
    public float radius = 8f;
    public float timeBetweenWaves = 4f;

    void Start() { StartCoroutine(SpawnLoop()); }

    IEnumerator SpawnLoop()
    {
        yield return new WaitForSeconds(1.5f);
        while (true)
        {
            for (int i = 0; i < enemiesPerWave; i++)
            {
                Vector3 pos = player.position + Random.insideUnitSphere * radius;
                pos.y = player.position.y;
                var go = Object.Instantiate(enemyPrefab, pos, Quaternion.identity);
                var ai = go.GetComponent<Enemies.EnemyAI>(); // caso namespace não usado, remover "Enemies."
                if (!ai) ai = go.AddComponent<EnemyAI>();
                ai.target = player;
                go.layer = LayerMask.NameToLayer("Enemy");
            }
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }
}
