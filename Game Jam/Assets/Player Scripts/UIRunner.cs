using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIRunner : MonoBehaviour
{
    [SerializeField] private int CheeseNumber;
    [SerializeField] private int health;
    [SerializeField] private int MAX_HEALTH;

    [SerializeField] private TMP_Text currencyUI;
    [SerializeField] private TMP_Text currentHealthUI;
    [SerializeField] private TMP_Text maxHealthUI;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        float money = GetComponent<UpgradeMenu>().currencyChecker();
        currencyUI.text = money.ToString();
        int MAX_HEALTH = GetComponent<UpgradeMenu>().GetMaxHP();
        maxHealthUI.text = MAX_HEALTH.ToString();
        int health = GetComponent<Health>().getHealth();
        currentHealthUI.text = health.ToString();
    }
}
