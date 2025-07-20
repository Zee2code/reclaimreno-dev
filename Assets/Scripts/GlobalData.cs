using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalData 
{
    public static int GetCoins()
    {
        if (!PlayerPrefs.HasKey("Coins"))
        {
            AddCoins(10000);
        }

        return PlayerPrefs.GetInt("Coins");
    }

    public static void AddCoins(int amount)
    {
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + amount);
        UIManager.Instance.SetCoinsUI();
    }    
    public static void DeductCoins(int amount)
    {
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + (-amount));
        UIManager.Instance.SetCoinsUI();
    }
}
