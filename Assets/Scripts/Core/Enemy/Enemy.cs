using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected float damage;
    void Start()
    {
        
    }
    public void TakeDamage(float damage)
    {
        health-=damage;
        HurtSequence();
        if (health <= 0)
        {
            DeathSequence();
        }
    }
    public virtual void HurtSequence()
    {
        //override according to child
    }
    public virtual void DeathSequence()
    {
        //override according to child
    }
}