using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUpgradeTable : MonoBehaviour
{

    [SerializeField] private GameObject Table;
    [SerializeField] private int interval;
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(spawnTable(interval, Table));
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator spawnTable(float interval, GameObject Table)
    {
        yield return new WaitForSeconds(interval);
        GameObject newUpgradeTable = Instantiate(Table, new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0), Quaternion.identity);
        StartCoroutine(spawnTable(interval, Table));
    }
}
