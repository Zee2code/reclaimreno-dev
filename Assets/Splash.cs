using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(LoadScene), 2f);
    }

    void LoadScene()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
