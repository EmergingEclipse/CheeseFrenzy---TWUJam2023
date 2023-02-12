using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    private GameObject attackarea;

    [SerializeField] private GameObject fistL;
    [SerializeField] private GameObject fistR;
    [SerializeField] private GameObject slapL;
    [SerializeField] private GameObject slapR;
    [SerializeField] private GameObject musk;

    [SerializeField] private GameObject wheel;
    private bool attacking = false;
    private float timeToAttack = .25f;
    private float timer = 0f;

    public Transform player;
    public UpgradeMenu playerupgrades;
    public int cheeseCounter = 0;

    public int punchCounter = 0;
    public int slapCounter = 0;
    public int muskCounter = 0;
    public int side = 0;
    void Start()
    {




        attackarea = transform.GetChild(0).gameObject;
        playerupgrades = GetComponent<UpgradeMenu>();
    }

    void Update()
    {
        cheeseWheel();
        punch();
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
            StartCoroutine(spawnWheel(2.5f, wheel));
            cheeseCounter = 1;
        }
    }


    private IEnumerator spawnWheel(float interval, GameObject wheel)
    {

        yield return new WaitForSeconds(interval);

        GameObject newWheel = Instantiate(wheel, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), Quaternion.identity);
        StartCoroutine(spawnWheel(interval, wheel));
    }



    public void punch()
    {
        if (playerupgrades.PunchChecker() && punchCounter == 0)
        {
            StartCoroutine(spawnFist(fistL, fistR));
            punchCounter = 1;
        }
    }

    private IEnumerator spawnFist(GameObject fistL, GameObject fistR)
    {
        float interval = player.GetComponent<UpgradeMenu>().GetPunchFrequency();

        yield return new WaitForSeconds(interval);


        if (side == 0)
        {
            GameObject newFist = Instantiate(fistL, new Vector3(player.transform.position.x - .5f, player.transform.position.y, player.transform.position.z), Quaternion.Euler(0, 0, 90));
            //Left
            Animator a = newFist.GetComponent<Animator>();
            a.Play("punch");

            StartCoroutine(spawnFist(fistL, fistR));
            side = 1;
        }
        else
        {
            GameObject newFist = Instantiate(fistR, new Vector3(player.transform.position.x + .5f, player.transform.position.y, player.transform.position.z), Quaternion.Euler(0, 0, -90));
            //right
            StartCoroutine(spawnFist(fistL, fistR));
            side = 0;
        }
    }

    private IEnumerator spawnSlap(float interval, GameObject slapL, GameObject slapR)
    {


        yield return new WaitForSeconds(interval);


        if (side == 0)
        {
            //Left
            GameObject newslap = Instantiate(slapR, new Vector3(player.transform.position.x + .5f, player.transform.position.y, player.transform.position.z), Quaternion.identity);
            StartCoroutine(spawnWheel(interval, slapL));
            side = 1;
        }
        else
        {
            GameObject newslap = Instantiate(slapL, new Vector3(player.transform.position.x - .5f, player.transform.position.y, player.transform.position.z), Quaternion.identity);
            //right
            StartCoroutine(spawnWheel(interval, slapR));
            side = 0;
        }
    }


}
