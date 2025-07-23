using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalData
{
    public static float GetCoins()
    {
        if (!PlayerPrefs.HasKey("Coins"))
        {
            AddCoins(10000);
        }

        return PlayerPrefs.GetFloat("Coins");
    }

    public static void AddCoins(float amount)
    {
        PlayerPrefs.SetFloat("Coins", PlayerPrefs.GetFloat("Coins") + amount);
        UIManager.Instance.SetCoinsUI();
    }
    public static void DeductCoins(float amount)
    {
        PlayerPrefs.SetFloat("Coins", PlayerPrefs.GetFloat("Coins") + (-amount));
        UIManager.Instance.SetCoinsUI();
    }
}
