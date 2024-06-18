using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public UpgradeSlotData slotData;
    [SerializeField]
    private Define.SlotType slotType;
    [SerializeField]
    private int slotIndex;

    [SerializeField]
    private TextMeshProUGUI costTxt;
    // Start is called before the first frame update
    void Start()
    {
        slotData = UpgradeManager.instance.dicUpgradeSlot[slotType][slotIndex];
    }

    public void UpdateCost()
    {
        costTxt.text = string.Format($"가격 : {slotData.cost}G");
    }
}
