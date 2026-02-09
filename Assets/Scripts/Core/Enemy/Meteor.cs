using UnityEngine;

public class Meteor : Enemy
{
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float rotateSpeed;
    private float speed;
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        rb.linearVelocity = Vector2.down * speed;
    }
    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }
    public override void HurtSequence()
    {
        base.HurtSequence();
    }
    public override void DeathSequence()
    {
        base.DeathSequence();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}