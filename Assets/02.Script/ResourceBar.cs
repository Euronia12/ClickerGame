using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceBar : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI goodPointTxt;
    [SerializeField]
    private TextMeshProUGUI subscriberPointTxt;
    [SerializeField]
    private TextMeshProUGUI goldTxt;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.CallbackUIUpdate += UpdateGold;
        GameManager.instance.CallbackUIUpdate += UpdateSubscriberPoint;
        GameManager.instance.CallbackUIUpdate += UpdateGoodPoint;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateGoodPoint()
    {
        goodPointTxt.text = string.Format($"{DataManager.instance.BigFan} 명");
    }

    private void UpdateSubscriberPoint() 
    {
        subscriberPointTxt.text = string.Format($"{DataManager.instance.SubscriberPoint} 명");
    }

    private void UpdateGold()
    {
        goldTxt.text = string.Format($"{DataManager.instance.Gold} 원");
    }
}
