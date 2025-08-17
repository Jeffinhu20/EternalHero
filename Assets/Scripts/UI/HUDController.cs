using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public Slider playerHPSlider;
    public Text goldText;
    public Health playerHealth;

    void Start()
    {
        if (playerHealth)
        {
            playerHPSlider.maxValue = playerHealth.maxHP;
            playerHPSlider.value = playerHealth.currentHP;
            playerHealth.OnHealthChanged += (cur, max) => { playerHPSlider.maxValue = max; playerHPSlider.value = cur; };
        }
    }

    void Update()
    {
        if (goldText) goldText.text = Currency.Gold.ToString();
    }
}
