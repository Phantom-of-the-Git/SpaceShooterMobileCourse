using UnityEngine;

public class PurpleEnemy : Enemy
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform leftCannon;
    [SerializeField] private Transform rightCannon;
    [SerializeField] private float speed;
    [SerializeField] private float shootInterval;
    private float shootTimer = 0;
    void Start()
    {
        rb.linearVelocity = Vector2.down * speed;
    }
    void Update()
    {
        shootTimer += Time.deltaTime;
        if(shootTimer >= shootInterval)
        {
            Instantiate(bulletPrefab, leftCannon.position, Quaternion.identity);
            Instantiate(bulletPrefab, rightCannon.position, Quaternion.identity);
            shootTimer = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStats>().TakeDamage(damage);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    public override void HurtSequence()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Dmg")) return;
        anim.SetTrigger("Damage");
    }
    public override void DeathSequence()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}