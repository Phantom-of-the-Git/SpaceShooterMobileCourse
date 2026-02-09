using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private float health;
    [SerializeField] private Image healthFill;
    private void Start()
    {
        health = maxHealth;
        healthFill.fillAmount = health / maxHealth;
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        healthFill.fillAmount = health / maxHealth;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}