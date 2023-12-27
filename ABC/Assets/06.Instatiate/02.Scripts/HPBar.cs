using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] Slider HPSlider;

    public void UpdateHP(float health, float maxHealth)
    {
        HPSlider.value = health / maxHealth;
    }
}