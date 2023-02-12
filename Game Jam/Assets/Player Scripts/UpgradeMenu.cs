using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text punchCost;
    [SerializeField] private TMP_Text slapCost;
    [SerializeField] private TMP_Text wheelCheeseCost;
    [SerializeField] private TMP_Text muskCost;
    [SerializeField] private TMP_Text speedCost;

    [SerializeField] private TMP_Text HPCost;
    [SerializeField] private TMP_Text baseDamageCost;
    [SerializeField] private TMP_Text knockBackCost;

    private float cheeseCurrency = 0;


    public int CheeseWheelActive = 0;
    public int SlapActive = 0;
    public int PunchActive = 1;
    public int MuskActive = 0;


    #region Variables
    private int punchDamage = 10;
    private float punchFrequency;
    private float slapPower = 1;
    private int slapDamage = 5;

    private int cheeseBounceCount = 3;
    private int cheeseDamage = 10;
    private float muskRange = 2;
    private float muskDamage = 5;

    private int HPModifier = 1;
    private float speedModifier = 1;
    private int baseDamage = 10;
    private int knockBackBuff = 1;

    private int nowHP;

    private float nowSpeed;

    private ActivateUpgradeMenu ButtonUpdater;

    public GameObject Table;
    private Health healthy;
    #endregion

    public List<string> CostGetter()
    {
        List<string> list = new List<string>();
        list.Add(punchCost.text);
        list.Add(slapCost.text);
        list.Add(wheelCheeseCost.text);
        list.Add(muskCost.text);
        list.Add(speedCost.text);
        list.Add(HPCost.text);
        list.Add(baseDamageCost.text);
        list.Add(knockBackCost.text);
        return list;
    }
    public void currencyAdder(float amount)
    {
        cheeseCurrency += amount;
    }
    public void currencyRemover(float amount)
    {
        cheeseCurrency -= amount;
    }
    public float currencyChecker()
    {
        return cheeseCurrency;
    }
    public bool cheeseChecker()
    {
        if (CheeseWheelActive == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool PunchChecker()
    {
        if (PunchActive == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool SlapChecker()
    {
        if (SlapActive == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool MuskChecker()
    {
        if (MuskActive == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void Start()
    {

        punchDamage = 10;
        punchFrequency = 1.5f;
        slapPower = 1;
        slapDamage = 5;

        cheeseBounceCount = 3;
        cheeseDamage = 10;
        muskRange = 2;
        muskDamage = 5;
        ButtonUpdater = Table.GetComponent<ActivateUpgradeMenu>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        healthy = player.GetComponent<Health>();
        healthy.PlayerHealthSetter();
        continuedCostUpgrades();

    }
    public bool IsAbleToBuy(TMP_Text value)
    {
        float CostOfUpgrade = float.Parse(value.text);
        float currentMoney = currencyChecker();
        if (CostOfUpgrade > currentMoney)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public void initialUpgradeCost()
    {
        PlayerPrefs.SetFloat("SpeedModifierCost", 100);
        PlayerPrefs.SetFloat("HPModifierCost", 150);
        PlayerPrefs.SetFloat("KnockBackModifierCost", 100);
        PlayerPrefs.SetFloat("BaseDamageModifierCost", 150);
    }
    public void continuedCostUpgrades()
    {
        speedCost.text = PlayerPrefs.GetFloat("SpeedModifierCost").ToString();
        HPCost.text = PlayerPrefs.GetFloat("HPModifierCost").ToString();
        knockBackCost.text = PlayerPrefs.GetFloat("KnockBackModifierCost").ToString();
        baseDamageCost.text = PlayerPrefs.GetFloat("BaseDamageModifierCost").ToString();
    }

    #region Upgrade Text Methods
    public void UpgradePunchText()
    {
        float amount = float.Parse(punchCost.text);
        currencyRemover(amount);
        punchCost.text = (float.Parse(punchCost.text) * 1.75f).ToString();
        ButtonUpdater.ButtonChecker();
        SetPunch();
    }
    public void UpgradeSlapText()
    {
        float amount = float.Parse(slapCost.text);
        currencyRemover(amount);
        slapCost.text = (float.Parse(slapCost.text) * 1.75f).ToString();
        ButtonUpdater.ButtonChecker();
        SetSlap();
    }
    public void UpgradeWheelText()
    {
        float amount = float.Parse(wheelCheeseCost.text);
        currencyRemover(amount);
        wheelCheeseCost.text = (float.Parse(wheelCheeseCost.text) * 1.75f).ToString();
        ButtonUpdater.ButtonChecker();
        SetCheese();
    }
    public void UpgradeMuskText()
    {

        float amount = float.Parse(muskCost.text);
        currencyRemover(amount);
        muskCost.text = (float.Parse(muskCost.text) * 1.75f).ToString();
        ButtonUpdater.ButtonChecker();
        SetMusk();
    }
    public void UpgradeSpeedText()
    {
        float amount = float.Parse(speedCost.text);
        currencyRemover(amount);
        speedCost.text = (float.Parse(speedCost.text) * 1.75f).ToString();
        PlayerPrefs.SetFloat("SpeedModifierCost", float.Parse(speedCost.text));
        ButtonUpdater.ButtonChecker();
        SetSpeed();
    }
    public void UpgradeHPText()
    {
        float amount = float.Parse(HPCost.text);
        currencyRemover(amount);
        HPCost.text = (float.Parse(HPCost.text) * 1.75f).ToString();
        PlayerPrefs.SetFloat("HPModifierCost", float.Parse(HPCost.text));
        ButtonUpdater.ButtonChecker();
        SetMaxHP();
    }
    public void UpgradeBaseDamageText()
    {
        float amount = float.Parse(baseDamageCost.text);
        currencyRemover(amount);
        baseDamageCost.text = (float.Parse(baseDamageCost.text) * 1.75f).ToString();
        PlayerPrefs.SetFloat("BaseDamageModifierCost", float.Parse(baseDamageCost.text));
        ButtonUpdater.ButtonChecker();
        SetBaseDamage();
    }
    public void UpgradeKnockBackText()
    {
        float amount = float.Parse(knockBackCost.text);
        currencyRemover(amount);
        knockBackCost.text = (float.Parse(knockBackCost.text) * 1.75f).ToString();
        PlayerPrefs.SetFloat("KnockBackModifierCost", float.Parse(knockBackCost.text));
        ButtonUpdater.ButtonChecker();
        SetKnockBack();
    }

    #endregion

    #region Get Set Methods for Temp Upgrades
    public void SetPunch()
    {
        baseDamage = GetBaseDamage();
        int damageIncrease = baseDamage * 2;
        punchDamage = punchDamage + damageIncrease;
        PunchActive = 1;
    }
    public int GetPunch()
    {
        return punchDamage;
    }
    public float GetPunchFrequency()
    {
        return (punchFrequency);
    }
    public void SetSlap()
    {
        baseDamage = GetBaseDamage();
        slapPower = (slapPower * 1.15f);
        slapDamage = slapDamage + baseDamage;
        SlapActive = 1;
    }
    public int GetSlapDamage()
    {
        return (slapDamage);
    }
    public float GetSlapKnockBack()
    {
        return (slapPower);
    }

    public void SetCheese()
    {
        baseDamage = GetBaseDamage();
        int damageIncrease = (baseDamage * 1);
        cheeseDamage = cheeseDamage + damageIncrease;

        cheeseBounceCount += 2;
        CheeseWheelActive = 1;

    }
    public int GetCheeseDamage()
    {
        return (cheeseDamage);
    }
    public int GetCheeseBounceCount()
    {
        return (cheeseBounceCount);
    }

    public void SetMusk()
    {
        baseDamage = GetBaseDamage();
        float damageIncrease = (baseDamage * .5f);
        muskDamage = muskDamage + damageIncrease;

        muskRange = (muskRange * 1.25f);
        MuskActive = 1;
    }

    public float GetMuskRange()
    {
        return (muskRange);
    }

    public float GetMuskDamage()
    {
        return (muskDamage);
    }
    #endregion

    #region Get Set Methods for Perm upgrades

    public void SetMaxHP()
    {

        if (PlayerPrefs.HasKey("HPModifier"))
        {
            HPModifier = PlayerPrefs.GetInt("HPModifier");
            HPModifier += 1;
            PlayerPrefs.SetInt("HPModifier", HPModifier);
            Debug.Log(HPModifier);

        }
        else
        {
            PlayerPrefs.SetInt("HPModifier", 2);
            Debug.Log("NoKeyFound");
        }
    }
    public int GetMaxHP()
    {
        int baseHP = 100;
        if (PlayerPrefs.HasKey("HPModifier"))
        {
            HPModifier = PlayerPrefs.GetInt("HPModifier");
            nowHP = baseHP * HPModifier;
            Debug.Log(nowHP);
            return (nowHP);
        }
        else
        {
            PlayerPrefs.SetInt("HPModifier", 2);
            HPModifier = PlayerPrefs.GetInt("HPModifier");
            nowHP = baseHP * HPModifier;
            return (nowHP);
        }

    }

    public void SetSpeed()
    {
        if (PlayerPrefs.HasKey("SpeedModifier"))
        {
            speedModifier = PlayerPrefs.GetFloat("SpeedModifier");
            PlayerPrefs.SetFloat("SpeedModifier", speedModifier + .30f);
        }
        else
        {
            PlayerPrefs.SetFloat("SpeedModifier", 1.25f);
        }
    }

    public float GetSpeed()
    {
        if (PlayerPrefs.HasKey("SpeedModifier"))
        {
            float baseSpeed = 5;
            speedModifier = PlayerPrefs.GetFloat("SpeedModifier");
            nowSpeed = baseSpeed * speedModifier;
            return (nowSpeed);
        }
        else
        {
            float baseSpeed = 5;
            PlayerPrefs.SetFloat("SpeedModifier", 1.00f);
            speedModifier = PlayerPrefs.GetFloat("SpeedModifier");
            nowSpeed = baseSpeed * speedModifier;
            return (nowSpeed);
        }
    }


    public void SetBaseDamage()
    {
        int baseDamage;
        if (PlayerPrefs.HasKey("BaseDamage"))
        {
            baseDamage = PlayerPrefs.GetInt("BaseDamage");
            PlayerPrefs.SetInt("BaseDamage", baseDamage + 5);

        }
        else
        {
            PlayerPrefs.SetInt("BaseDamage", 10);
        }
    }

    public int GetBaseDamage()
    {
        if (PlayerPrefs.HasKey("BaseDamage"))
        {

            baseDamage = PlayerPrefs.GetInt("BaseDamage");
            return baseDamage;
        }

        else
        {
            PlayerPrefs.SetInt("BaseDamage", 10);
            baseDamage = PlayerPrefs.GetInt("BaseDamage");
            return baseDamage;

        }
    }

    public void SetKnockBack()
    {
        if (PlayerPrefs.HasKey("KnockBackBuff"))
        {
            float KnockBackBuff = PlayerPrefs.GetFloat("KnockBackBuff");
            PlayerPrefs.SetFloat("KnockBackBuff", knockBackBuff * 1.15f);
        }
        else
        {
            PlayerPrefs.SetFloat("KNockBackBuff", 1.15f);
        }
    }

    public float GetKnockBackBuff()
    {
        if (PlayerPrefs.HasKey("KnockBackBuff"))
        {
            float KnockBackBuff = PlayerPrefs.GetFloat("KnockBackBuff");
            return baseDamage;


        }
        else
        {
            PlayerPrefs.SetFloat("KnockBackBuff", 1.00f);
            float KnockBackBuff = PlayerPrefs.GetFloat("KnockBackBuff");
            return KnockBackBuff;
        }
    }

    #endregion

    public void UpdateStats()
    {


    }
}
