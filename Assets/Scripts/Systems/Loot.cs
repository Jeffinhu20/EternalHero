using UnityEngine;

public class Loot : MonoBehaviour
{
    public int gold = 5;
    public float lifeTime = 8f;

    void Start() { Destroy(gameObject, lifeTime); }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Currency.GiveGold(gold);
            Destroy(gameObject);
        }
    }
}

public static class Currency
{
    public static long Gold = 0;
    public static void GiveGold(long amount)
    {
        Gold += amount;
        Debug.Log($"Gold: {Gold} (+{amount})");
    }
}
