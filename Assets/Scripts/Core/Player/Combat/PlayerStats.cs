using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private float maxHealth;
    private float health;
    [SerializeField] private Image healthFill;
    [SerializeField] private GameObject explosionPrefab;
    private void Start()
    {
        health = maxHealth;
        healthFill.fillAmount = health / maxHealth;
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        healthFill.fillAmount = health / maxHealth;
        if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Dmg")) return;
        anim.SetTrigger("Damage");
        if (health <= 0)
        {
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }}