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


    public int CheeseWheelActive = 0;
    public int SlapActive = 0;
    public int PunchActive = 0;
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

    #endregion

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

    }

    #region Upgrade Text Methods
    public void UpgradePunchText()
    {
        punchCost.text = (float.Parse(punchCost.text) * 1.75f).ToString();
        SetPunch();
    }
    public void UpgradeSlapText()
    {
        slapCost.text = (float.Parse(slapCost.text) * 1.75f).ToString();
        SetSlap();
    }
    public void UpgradeWheelText()
    {
        wheelCheeseCost.text = (float.Parse(wheelCheeseCost.text) * 1.75f).ToString();
        SetCheese();
    }
    public void UpgradeMuskText()
    {
        muskCost.text = (float.Parse(muskCost.text) * 1.75f).ToString();
        SetMusk();
    }
    public void UpgradeSpeedText()
    {
        muskCost.text = (float.Parse(speedCost.text) * 1.75f).ToString();
        SetSpeed();
    }
    public void UpgradeHPText()
    {
        HPCost.text = (float.Parse(HPCost.text) * 1.75f).ToString();
        SetMaxHP();
    }
    public void UpgradeBaseDamageText()
    {
        baseDamageCost.text = (float.Parse(baseDamageCost.text) * 1.75f).ToString();
        SetBaseDamage();
    }
    public void UpgradeKnockBackText()
    {
        knockBackCost.text = (float.Parse(knockBackCost.text) * 1.75f).ToString();
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
        PunchActive = 1;
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
    public float GetCheeseBounceCount()
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
            PlayerPrefs.SetInt("HpModifier", HPModifier + 1);
            HPModifier = PlayerPrefs.GetInt("HPModifier");
        }
        else
        {
            PlayerPrefs.SetInt("HPModifier", 2);
        }
    }
    public int GetMaxHP()
    {
        int baseHP = 100;
        if (PlayerPrefs.HasKey("HPModifier"))
        {
            HPModifier = PlayerPrefs.GetInt("HPModifier");
            nowHP = baseHP * HPModifier;
            return (nowHP);
        }
        else
        {
            PlayerPrefs.SetInt("HPModifier", 1);
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
