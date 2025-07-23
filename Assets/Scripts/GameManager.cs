using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BuildingData BuildingData;

    public static GameManager instance;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    public void OpenUpgradePanel(int buildingID)
    {
        foreach (var build in BuildingData.buildings)
        {
            if (build.buildingID == buildingID)
            {
                InstanceManager.Instance.upgrade.SetBuildingData(build);
            }
        }
    }

    public BuidInfo GetDataOfBuilding(int buildingID)
    {
        foreach (var build in BuildingData.buildings)
        {
            if (build.buildingID == buildingID)
            {
                return build;
            }
        }
        return null;
    }

    public void SetDataOfBuilding(BuidInfo buildInfo)
    {
        for (int i = 0; i < BuildingData.buildings.Count; i++)
        {
            print("Build: " + BuildingData.buildings[i].buildingID);
            if (BuildingData.buildings[i].buildingID == buildInfo.buildingID)
            {
                BuildingData.buildings[i] = buildInfo;
            }
        }
    }

}
