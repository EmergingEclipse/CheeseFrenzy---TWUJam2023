using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{



    [SerializeField] private GameObject RatWave1;
    private float rat1Interval = 7f;
    [SerializeField] private GameObject RatWave2;
    private float rat2Interval = 5f;
    [SerializeField] private GameObject RatWave3;
    private float rat3Interval = 3.5f;
    [SerializeField] private GameObject RatWave4;
    private float rat4Interval = 2f;
    [SerializeField] private GameObject RatWave5;
    private float rat5Interval = 0.5f;

    [SerializeField] private GameObject HazmatWave1;
    private float Hazmat1Interval = 3f;
    [SerializeField] private GameObject HazmatWave2;
    private float Hazmat2Interval = 2f;
    [SerializeField] private GameObject HazmatWave3;
    private float Hazmat3Interval = 1f;

    [SerializeField] private GameObject CatWave1;
    private float Cat1Interval = 300f;
    [SerializeField] private GameObject CatWave2;
    private float Cat2Interval = 300f;
    [SerializeField] private GameObject CatWave3;
    private float Cat3Interval = 300f;


    // Start is called before the first frame update
    void FixedUpdate()
    {
        int Count = 1;
        if ((Time.deltaTime > 0 && Count == 1))
        {
            StartCoroutine(spawnEnemy(rat1Interval, RatWave1));
            StartCoroutine(spawnEnemy(Hazmat1Interval, HazmatWave1));
            Count += 1;
        }
        if ((Time.deltaTime > 90 && Count == 2))
        {
            StartCoroutine(spawnEnemy(rat2Interval, RatWave2));
            Count += 1;

        }
        if ((Time.deltaTime > 180 && Count == 3))
        {
            StartCoroutine(spawnEnemy(rat2Interval, RatWave3));
            StartCoroutine(spawnEnemy(rat5Interval, RatWave1));
            Count += 1;

        }
        if ((Time.deltaTime > 300 && Count == 4))
        {
            StartCoroutine(spawnEnemy(Cat1Interval, CatWave1));
            StartCoroutine(spawnEnemy(Hazmat2Interval, HazmatWave2));
            Count += 1;
        }
        if ((Time.deltaTime > 420 && Count == 5))
        {
            StartCoroutine(spawnEnemy(rat5Interval, RatWave3));
            StartCoroutine(spawnEnemy(Hazmat3Interval, HazmatWave1));
            Count += 1;
        }
        if ((Time.deltaTime > 500 && Count == 5))
        {
            StartCoroutine(spawnEnemy(rat5Interval, RatWave5));
            StartCoroutine(spawnEnemy(Hazmat1Interval, HazmatWave1));
            Count += 1;
        }
        if ((Time.deltaTime > 600 && Count == 6))
        {
            StartCoroutine(spawnEnemy(Cat1Interval, CatWave2));
            StartCoroutine(spawnEnemy(Hazmat2Interval, HazmatWave2));
            Count += 1;
        }
        if ((Time.deltaTime > 600 && Count == 6))
        {
            StartCoroutine(spawnEnemy(Cat1Interval, CatWave2));
            StartCoroutine(spawnEnemy(Hazmat2Interval, HazmatWave2));
            Count += 1;
        }
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-8f, 8f), Random.Range(-10f, 10f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
