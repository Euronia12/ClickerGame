using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager instance;
    public Dictionary<Define.SlotType, List<UpgradeSlotData>> dicUpgradeSlot = new Dictionary<Define.SlotType, List<UpgradeSlotData>>();
    public List<UpgradeSlotData> clickSlots = new List<UpgradeSlotData>();
    public List<UpgradeSlotData> autoSlots = new List<UpgradeSlotData>();
    public List<UpgradeSlotData> itemSlots = new List<UpgradeSlotData>();
    [SerializeField]
    private DataManager dataManager;
    [SerializeField]
    private Player player;

    private void Awake()
    {
        if(instance == null)
            instance = this; 
    }

    // Start is called before the first frame update
    void Start()
    {
        dataManager = DataManager.instance;
        if (DataManager.instance.saveData.dicUpgradeSlot.Count == 0)
        {
            dicUpgradeSlot.Add(Define.SlotType.Clicker, clickSlots);
            dicUpgradeSlot.Add(Define.SlotType.Auto, autoSlots);
            dicUpgradeSlot.Add(Define.SlotType.Item, itemSlots);
        }
        else
        {
            dicUpgradeSlot = DataManager.instance.saveData.dicUpgradeSlot;
        }
    }


    public bool CheckedCanBuy(int cost)
    {
        if (cost <= DataManager.instance.Gold) return true;
        return false;
    }

    public void UpgradeClick(int index)
    {
        UpgradeSlotData slotData = dicUpgradeSlot[Define.SlotType.Clicker][index];
        if (CheckedCanBuy(slotData.cost))
        {
            dataManager.Gold = -slotData.cost;
            dataManager.clickPerGold += slotData.addValue;
            slotData.cost *= slotData.additionalCost;
            GameManager.instance.OnUIUpdate();
        }
    }

    public void UpgradeAuto(int index)
    {
        UpgradeSlotData slotData = dicUpgradeSlot[Define.SlotType.Auto][index];
        if (CheckedCanBuy(slotData.cost))
        {
            dataManager.Gold = -slotData.cost;
            dataManager.autoGold += slotData.addValue;
            slotData.cost *= slotData.additionalCost;
            GameManager.instance.OnUIUpdate();
            GameManager.instance.OnAutoClick();
        }
    }

    //미완
    public void UpgradeItem(int index)
    {
        UpgradeSlotData slot = dicUpgradeSlot[Define.SlotType.Item][index];
        if (CheckedCanBuy(slot.cost))
        {
            dataManager.Gold = -slot.cost;
            dataManager.upgradeSubPercent += slot.addValue;
            slot.cost *= slot.additionalCost;
            GameManager.instance.OnUIUpdate();
        }
    }
}
