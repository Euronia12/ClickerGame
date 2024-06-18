using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class UpgradeSlotData
{
    public int cost;
    public int addValue;
    public int additionalCost = 2;
    public Define.SlotType slotType;
    public int slotIndex;
}
