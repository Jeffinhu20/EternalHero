using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHP = 100f;
    public float currentHP;

    public System.Action<float, float> OnHealthChanged;
    public System.Action OnDied;

    void Awake()
    {
        currentHP = maxHP;
        OnHealthChanged?.Invoke(currentHP, maxHP);
    }

    public void TakeDamage(float dmg)
    {
        if (currentHP <= 0f) return;
        currentHP -= dmg;
        OnHealthChanged?.Invoke(currentHP, maxHP);
        if (currentHP <= 0f)
        {
            currentHP = 0f;
            OnDied?.Invoke();
            Destroy(gameObject, 0.05f);
        }
    }
}
