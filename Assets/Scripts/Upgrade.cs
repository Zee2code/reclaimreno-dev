using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.ObjectChangeEventStream;

public class Upgrade : MonoBehaviour
{
    public Text buildingName;
    public Text buildingLevel;
    public Text buildingUpgradePercentage;
    public Image buildingPercentage;

    [Header("Items Info")]
    public Image icon;
    public Text itemName;
    public Text info;
    public Text generateCoins;

    public List<ItemData> itemData;

    public GameObject item;
    public Transform itemContent;
    private List<GameObject> itemsList =  new List<GameObject>();
    private BuidInfo buildingInfo;

    public void SetBuildingData(BuidInfo buildInfo)
    {
        DestroyAllItem();
        buildingInfo = buildInfo;
        buildingName.text = buildInfo.buildingName;
        buildingLevel.text = "Level "+ buildInfo.buildingLevel;
        buildingUpgradePercentage.text = buildInfo.buildingUpgradePercentage + " %";
        itemData = buildInfo.items;
        AddItems();
        gameObject.SetActive(true);
    }

    void DestroyAllItem()
    {
        foreach(var g in itemsList)
        {
            Destroy(g);
        }
    }

    public void AddItems()
    {
        itemsList.Clear();
        for (int i = 0; i < itemData.Count; i++) 
        {
            GameObject itemObj = Instantiate(item, itemContent);
            itemObj.GetComponent<Image>().sprite = itemData[i].icon;
            itemObj.name = itemData[i].name;
            itemsList.Add(itemObj);
        }
        itemsList[0].GetComponent<Item>().OnClick();
    }


    public void ItemClick(string buildName)
    {
        foreach (GameObject itemObj in itemsList)
        {
            itemObj.transform.GetChild(0).gameObject.SetActive(false);
        }

        foreach (var build in itemData)
        {
            if (build.name == buildName)
            {
                icon.sprite = build.icon;
                info.text = build.description;
                itemName.text = build.name;
                generateCoins.text = build.coinsToGenerate + "/min";
            }
        }
     }

    public void OnUpgradeClick()
    {
        if(GlobalData.GetCoins()>= GetUpgradeAmount())
        {
            GlobalData.DeductCoins(GetUpgradeAmount());
            buildingUpgradePercentage.text = (buildingInfo.buildingUpgradePercentage+25).ToString();
            buildingInfo.buildingUpgradePercentage += 0.25f;
            buildingPercentage.fillAmount = buildingInfo.buildingUpgradePercentage;
        }
    }

    public void UpdateBuilding(float percentage)
    {
        foreach (var build in GameManager.instance.BuildingData.buildings)
        {
            if(build.buildingName == buildingName.text)
            {
                build.buildingUpgradePercentage = percentage;
            }
        }
    }

    public int GetUpgradeAmount()
    {
        return (buildingInfo.buyMultiplier * buildingInfo.buildingLevel);
    }

}
