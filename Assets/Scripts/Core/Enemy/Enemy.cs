using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] protected float damage;
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected Animator anim;
    [SerializeField] protected GameObject explosionPrefab;
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