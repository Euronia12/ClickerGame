using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public SaveData saveData;

    public int BigFan
    {
        get { return saveData.bigFan; } 
        set { saveData.bigFan += value; }
    }
    public int upgradeBigFan = 1;
    public float upgradeFanPercent = 1.0f;
    public float upgradeAddPercent => ((int)(BigFan / 100)) / 10f;

    public int SubscriberPoint
    {
        get { return saveData.subscriberPoint; }
        set 
        {
            saveData.subscriberPoint += value;
            if (value > 0 && SubscriberPoint > BigFan)
            {
                BigFan = GetRandCount(upgradeFanPercent, upgradeBigFan);
            }
        }
    }
    public int upgradeSubscriber = 1;
    public float upgradeSubPercent = 10.0f;

    public int Gold
    {
        get { return saveData.gold; }
        set { saveData.gold += value; }
    }
    public int clickPerGold = 10;
    public int autoGold = 0;
    private void Awake()
    {
        if(instance == null)
            instance = this;
    }

    public void GetGold()
    {
        Gold = (int)(clickPerGold + (SubscriberPoint / 100) + (clickPerGold * upgradeAddPercent));
    }

    public int GetRandCount(float percent, int count)
    {
        float randPercent = UnityEngine.Random.Range(0f, 100);
        if (percent >= randPercent)
        {
            return (int)UnityEngine.Random.Range(MathF.Max(0, count - 4), count + 4);
        }
        return 0;
    }
}
