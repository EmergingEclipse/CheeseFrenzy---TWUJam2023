using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    private GameObject attackarea;

    [SerializeField] private GameObject wheel;
    private bool attacking = false;
    private float timeToAttack = .25f;
    private float timer = 0f;

    public Transform player;
    public UpgradeMenu playerupgrades;
    int cheeseCounter = 0;

    void Start()
    {

        attackarea = transform.GetChild(0).gameObject;
        playerupgrades = GetComponent<UpgradeMenu>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
        if (attacking)
        {
            timer += Time.deltaTime;
            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackarea.SetActive(attacking);

            }
        }
        cheeseWheel();
    }


    private void Attack()
    {
        attacking = true;
        attackarea.SetActive(attacking);
    }

    public void cheeseWheel()
    {
        if (playerupgrades.cheeseChecker() && cheeseCounter == 0)
        {
            spawnWheel(2.5f, wheel);
            cheeseCounter = 1;
        }
    }


    private IEnumerator spawnWheel(float interval, GameObject wheel)
    {

        yield return new WaitForSeconds(interval);

        GameObject newWheel = Instantiate(wheel, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), Quaternion.identity);
        StartCoroutine(spawnWheel(interval, wheel));
    }


}
