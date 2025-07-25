using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    public int buildID;
    public GameObject tutorial;

    private void OnMouseDown()
    {
        print(GameManager.instance);
        GameManager.instance.OpenUpgradePanel(buildID);
        if (tutorial)
            tutorial.SetActive(false);
    }
}
