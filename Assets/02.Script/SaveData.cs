using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData
{
    [Header("열혈팬")]
    [SerializeField]
    public int bigFan;

    [Header("구독자")]
    [SerializeField]
    public int subscriberPoint;

    [Header("골드")]
    [SerializeField]
    public int gold;

    public Dictionary<Define.SlotType, List<UpgradeSlotData>> dicUpgradeSlot = new Dictionary<Define.SlotType, List<UpgradeSlotData>>();
}
