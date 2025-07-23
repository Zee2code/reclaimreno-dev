using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    private int currentStep;
    public TutorialSteps[] tutorialSteps;
    public GameObject tutorialTextPanel;
    void Start()
    {
        currentStep = PlayerPrefs.GetInt("TutorialStep");
        StartTutorial();
    }
    void StartTutorial()
    {
        for (int i = 0; i < tutorialSteps.Length; i++)
        {
            if (i == currentStep)
            {
                if (tutorialSteps[i].type == TutorialType.TypeWriter)
                {
                    InstanceManager.Instance.typeWriter.StartTypewriter(tutorialSteps[i].description);
                    tutorialTextPanel.SetActive(true);
                }
            }
        }
    }

    public void ProceedTutorial()
    {
        currentStep++;
        StartTutorial();
    }
    private void OnDisable()
    {
        PlayerPrefs.SetInt("TutorialStep", currentStep);
    }
}


[System.Serializable]
public class TutorialSteps
{
    public int stepNo;
    public TutorialType type;
    public string description;
}

public enum TutorialType
{
    TypeWriter
}
