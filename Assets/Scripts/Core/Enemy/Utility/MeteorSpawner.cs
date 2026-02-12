using System.Collections;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] meteorPrefabs;
    [SerializeField] private float spawnTime;

    private float timer;

    private Camera mainCam;
    private float maxLeft;
    private float maxRight;
    private float yPos;
    void Start()
    {
        mainCam = Camera.main;
        StartCoroutine(SetBoundaries());
    }
    void Update()
    {
        MeteorSpawn();
    }
    private void MeteorSpawn()
    {
        timer += Time.deltaTime;
        if (timer > spawnTime)
        {
            int randPick = Random.Range(0, meteorPrefabs.Length);
            GameObject tempMeteor = Instantiate(meteorPrefabs[randPick], new Vector3(Random.Range(maxLeft, maxRight), yPos, -5), Quaternion.Euler(0, 0, Random.Range(0, 360)));
            float size = Random.Range(0.9f, 1.1f);
            tempMeteor.transform.localScale = new Vector3(size, size, 0);
            timer = 0;
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