using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        InstanceManager.Instance.upgrade.ItemClick(gameObject.name);
        Debug.Log("Button clicked!");
        transform.GetChild(0).gameObject.SetActive(true);
    }
}

