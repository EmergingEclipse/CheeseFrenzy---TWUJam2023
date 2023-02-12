using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ActivateUpgradeMenu : MonoBehaviour
{


    [SerializeField] private GameObject UpgradeUI;
    [SerializeField] private GameObject UpgradeTable;
    [SerializeField] private GameObject player;
    [SerializeField] private Button punchPurchase;
    [SerializeField] private Button slapPurchase;
    [SerializeField] private Button wheelPurchase;
    [SerializeField] private Button muskPurchase;
    [SerializeField] private Button speedPurchase;
    [SerializeField] private Button hpPurchase;
    [SerializeField] private Button knockbackPurchase;
    [SerializeField] private Button basePurchase;


    public float distance;
    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.GetComponent<Transform>().position, this.gameObject.transform.position);
        WindowOpen();
    }

    public void WindowOpen()
    {
        if ((distance < 2) && Input.GetKeyDown(KeyCode.E))
        {
            ButtonChecker();

            UpgradeUI.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void windowClosed()
    {

        TableRemover();
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }

    public void ButtonChecker()
    {
        UpgradeMenu UpgradeScript = player.GetComponent<UpgradeMenu>();
        float currency = UpgradeScript.currencyChecker();
        // punch,slap,wheel,musk,speed,Hp,Base,knockBack
        List<string> list;
        Debug.Log(currency);
        list = UpgradeScript.CostGetter();

        for (int i = 0; i < 8; i++)
        {

            string tempStr = list[i];
            float tempNum = float.Parse(tempStr);
            if (i == 0)
            {

                if (tempNum > currency)
                {
                    Debug.Log("buttonfalse");
                    punchPurchase.interactable = false;
                }
                else
                {
                    Debug.Log("buttontrue");
                    punchPurchase.interactable = true;
                }
            }

            if (i == 1)
            {
                if (tempNum > currency)
                {
                    Debug.Log("buttonfalse");
                    slapPurchase.interactable = false;
                }
                else
                {
                    Debug.Log("buttontrue");
                    slapPurchase.interactable = true;
                }
            }
            if (i == 2)
            {
                if (tempNum > currency)
                {
                    wheelPurchase.interactable = false;
                }
                else
                {
                    wheelPurchase.interactable = true;
                }
            }
            if (i == 3)
            {
                if (tempNum > currency)
                {
                    muskPurchase.interactable = false;
                }
                else
                {
                    muskPurchase.interactable = true;
                }
            }
            if (i == 4)
            {
                if (tempNum > currency)
                {
                    speedPurchase.interactable = false;
                }
                else
                {
                    speedPurchase.interactable = true;
                }
            }
            if (i == 5)
            {
                if (tempNum > currency)
                {
                    hpPurchase.interactable = false;
                }
                else
                {
                    hpPurchase.interactable = true;
                }
            }
            if (i == 6)
            {
                if (tempNum > currency)
                {
                    basePurchase.interactable = false;
                }
                else
                {
                    basePurchase.interactable = true;
                }
            }
            if (i == 7)
            {
                if (tempNum > currency)
                {
                    knockbackPurchase.interactable = false;
                }
                else
                {
                    //knockbackPurchase.interactable = true;
                }
            }

        }
    }
    public void TableRemover()
    {
        GameObject[] Tables = GameObject.FindGameObjectsWithTag("Table");
        foreach (GameObject table in Tables)
        {
            Destroy(table);
        }
    }
}
