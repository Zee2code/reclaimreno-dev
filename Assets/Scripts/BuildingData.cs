using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBuilding", menuName = "Game/Building")]
public class BuildingData : ScriptableObject
{
    public List<BuidInfo> buildings;
}

[System.Serializable]
public class BuidInfo
{
    public int buildingID;
    public string buildingName;
    public int buildingLevel;
    public int buildingTotalLevel;
    public float buildingUpgradePercentage;
    public float valueToUpgrade;
    public float buyMultiplier;
    public float coinsToGenerateMultiplier;
    public List<ItemData> items;
}

[System.Serializable]
public class ItemData
{
    public Sprite icon;
    public string name;
    [TextArea]
    public string description;
    public float coinsToGenerate;
}
