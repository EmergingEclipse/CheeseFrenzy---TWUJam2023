using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public int Count = 1;

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
    void Update()
    {

        if ((Time.timeSinceLevelLoad > 0 && Count == 1))
        {
            StartCoroutine(spawnEnemy(rat1Interval, RatWave1));
            StartCoroutine(spawnEnemy(Hazmat1Interval, HazmatWave1));
            Debug.Log("First Wave");
            Count += 1;
        }
        if ((Time.timeSinceLevelLoad > 90 && Count == 2))
        {
            StartCoroutine(spawnEnemy(rat2Interval, RatWave2));
            Count += 1;
            Debug.Log("Second Wave");
        }
        if ((Time.timeSinceLevelLoad > 180 && Count == 3))
        {
            StartCoroutine(spawnEnemy(rat2Interval, RatWave3));
            StartCoroutine(spawnEnemy(rat5Interval, RatWave1));
            Count += 1;

        }
        if ((Time.timeSinceLevelLoad > 300 && Count == 4))
        {
            StartCoroutine(spawnEnemy(Cat1Interval, CatWave1));
            StartCoroutine(spawnEnemy(Hazmat2Interval, HazmatWave2));
            Count += 1;
        }
        if ((Time.timeSinceLevelLoad > 420 && Count == 5))
        {
            StartCoroutine(spawnEnemy(rat5Interval, RatWave3));
            StartCoroutine(spawnEnemy(Hazmat3Interval, HazmatWave1));
            Count += 1;
        }
        if ((Time.timeSinceLevelLoad > 500 && Count == 6))
        {
            StartCoroutine(spawnEnemy(rat5Interval, RatWave5));
            StartCoroutine(spawnEnemy(Hazmat1Interval, HazmatWave1));
            Count += 1;
        }
        if ((Time.timeSinceLevelLoad > 550 && Count == 7))
        {
            StartCoroutine(spawnEnemy(Cat1Interval, CatWave2));
            StartCoroutine(spawnEnemy(Hazmat2Interval, HazmatWave2));
            Count += 1;
        }
        if ((Time.timeSinceLevelLoad > 600 && Count == 8))
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
