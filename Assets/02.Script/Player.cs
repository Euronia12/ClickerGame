using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ApperanceType
{
    ACC = 0,
    Hair,
    Body,
    Face,
    Head,
    Hair_back,
    MaxNum
}

public enum FaceType
{
    Happy = 0,
    Idle,
    Worried,
    Angry,
    MaxNum
}

public class Player : MonoBehaviour
{
    public DataManager dataManager;
    [SerializeField]
    private Sprite[] playerFace;
    [SerializeField]
    private SpriteRenderer[] playerBody;
    private Dictionary<ApperanceType, SpriteRenderer> dicPlayerBody = new Dictionary<ApperanceType, SpriteRenderer>();
    Coroutine AutoClickCoroutine;
    Coroutine EmotionCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < (int)ApperanceType.MaxNum; i++)
        {
            dicPlayerBody.Add((ApperanceType)i, playerBody[i]);
        }
        GameManager.instance.CallbackAutoClick += AutoClick;
    }



    public void PlayerClick()
    {
        if(EmotionCoroutine != null)
            StopCoroutine(EmotionCoroutine);
        EmotionCoroutine = StartCoroutine(ChagngedEmotion());
        dataManager.SubscriberPoint = dataManager.GetRandCount(dataManager.upgradeSubPercent, dataManager.upgradeSubscriber);
        dataManager.GetGold();
        GameManager.instance.OnUIUpdate();
    }




    public void AutoClick()
    {
        if (AutoClickCoroutine == null)
        {
            AutoClickCoroutine = StartCoroutine(GetAutoGold());
        }
    }

    IEnumerator GetAutoGold()
    {
        GameManager.instance.CallbackAutoClick -= AutoClick;
        while (true)
        {
            dataManager.Gold = dataManager.autoGold;
            GameManager.instance.OnUIUpdate();
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator ChagngedEmotion()
    {
        for(int i = 0; i < (int)FaceType.MaxNum; i++) 
        {
            dicPlayerBody[ApperanceType.Face].sprite = playerFace[i];
            yield return new WaitForSeconds(3);
        }
    }
}
