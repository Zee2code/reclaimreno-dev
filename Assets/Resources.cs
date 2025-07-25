using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resources : MonoBehaviour
{

    public int resourceID;
    public float resourceAmount;
    public GameObject tutorial;
    public Text description;

    private void OnMouseDown()
    {
        print(GameManager.instance);
        GameManager.instance.GatherResources(this);
        if (tutorial)
        {
            InstanceManager.Instance.tutorialManager.ProceedTutorial();
        }
    }
}

