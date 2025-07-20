using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Text coinsText;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SetCoinsUI();
    }

    public void OnClickRouletteWheel()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnClickSpinWheel()
    {
        SceneManager.LoadScene("GameReward");

    }

    public void OnClickHome()
    {
        SceneManager.LoadScene("GamePlay");

    }

    public void SetCoinsUI()
    {
        coinsText.text = GlobalData.GetCoins().ToString();
    }
}
