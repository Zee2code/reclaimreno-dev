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
    private int selectedItem;
    private List<GameObject> itemsList = new List<GameObject>();
    public BuidInfo buildingInfo;

    public void SetBuildingData(BuidInfo buildInfo)
    {
        DestroyAllItem();
        buildingInfo = buildInfo;
        buildingName.text = buildInfo.buildingName;
        buildingLevel.text = "Level " + buildInfo.buildingLevel;
        buildingUpgradePercentage.text = buildInfo.buildingUpgradePercentage + " %";
        buildingPercentage.fillAmount = buildInfo.buildingUpgradePercentage / 100f;
        itemData = buildInfo.items;
        AddItems();
        gameObject.SetActive(true);
    }

    void DestroyAllItem()
    {
        foreach (var g in itemsList)
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

        for (int i = 0; i < itemData.Count; i++)
        {
            if (itemData[i].name == buildName)
            {
                selectedItem = i;
                ItemUISetting(itemData[i]);
            }
        }
    }

    void ItemUISetting(ItemData build)
    {
        icon.sprite = build.icon;
        info.text = build.description;
        itemName.text = build.name;
        generateCoins.text = build.coinsToGenerate + "/min";
    }

    public void OnUpgradeClick()
    {
        if (GlobalData.GetCoins() >= GetUpgradeAmount())
        {
            GlobalData.DeductCoins(GetUpgradeAmount());
            UgpradeBuilding();
        }
    }

    public void UgpradeBuilding()
    {
        if (buildingInfo.buildingUpgradePercentage >= 100)
        {

            buildingInfo.buildingUpgradePercentage = 0;
            if (buildingInfo.buildingLevel < buildingInfo.buildingTotalLevel)
            {
                buildingInfo.buildingLevel++;
                buildingLevel.text = "Level " + buildingInfo.buildingLevel;
                for (int i = 0; i < buildingInfo.items.Count; i++)
                {
                    buildingInfo.items[i].coinsToGenerate *= buildingInfo.coinsToGenerateMultiplier;
                }
                ItemUISetting(buildingInfo.items[selectedItem]);
                GameManager.instance.SetDataOfBuilding(buildingInfo);
            }
            else
            {
                return;
            }
        }
        buildingInfo.buildingUpgradePercentage += buildingInfo.valueToUpgrade;
        GameManager.instance.SetDataOfBuilding(buildingInfo);
        buildingUpgradePercentage.text = buildingInfo.buildingUpgradePercentage + "%";
        buildingPercentage.fillAmount = buildingInfo.buildingUpgradePercentage / 100f;
    }




    public float GetUpgradeAmount()
    {
        return (buildingInfo.buyMultiplier * buildingInfo.buildingLevel);
    }

}
