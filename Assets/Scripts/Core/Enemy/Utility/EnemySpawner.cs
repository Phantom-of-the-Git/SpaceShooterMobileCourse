using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Camera mainCam;
    private float maxLeft;
    private float maxRight;
    private float yPos;

    [Header("Enemy Prefabs")]
    [SerializeField] private GameObject[] enemies;
    private float enemyTimer;
    [Space(15)]
    [SerializeField] private float enemySpawnTime;
    void Start()
    {
        mainCam = Camera.main;
        StartCoroutine(SetBoundaries());
    }
    void Update()
    {
        EnemySpawn();
    }
    private void EnemySpawn()
    {
        enemyTimer += Time.deltaTime;
        if (enemyTimer > enemySpawnTime)
        {
            int randPick = Random.Range(0, enemies.Length);
            Instantiate(enemies[randPick], new Vector3(Random.Range(maxLeft, maxRight), yPos, 0), Quaternion.identity);
            enemyTimer = 0;
        }
    }
    private IEnumerator SetBoundaries()
    {
        yield return new WaitForSeconds(0.4f);
        //Set boundaries of the movement for player through camera view point (0,0) to (1,1)
        maxLeft = mainCam.ViewportToWorldPoint(new Vector2(0.15f, 0)).x;
        maxRight = mainCam.ViewportToWorldPoint(new Vector2(0.85f, 0)).x;
        yPos = mainCam.ViewportToWorldPoint(new Vector2(0, 1.1f)).y;
    }

}