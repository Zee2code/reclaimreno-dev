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

    public void OpenUpgradePanel(int buildID)
    {
       foreach(var build in BuildingData.buildings)
       {
            if(build.buildingID == buildID)
            {
                InstanceManager.Instance.upgrade.SetBuildingData(build);
            }
       }
    }

}
