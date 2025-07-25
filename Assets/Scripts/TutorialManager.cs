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
                DoTutorial(tutorialSteps[i]);
            }
        }
    }

    void DoTutorial(TutorialSteps currentTutorial)
    {
        switch (currentTutorial.type)
        {
            case TutorialType.TypeWriter:
                InstanceManager.Instance.typeWriter.StartTypewriter(currentTutorial.description);
                tutorialTextPanel.SetActive(true);
                break;
            case TutorialType.Building:
                currentTutorial.targetBuildling.SetActive(true);
                tutorialTextPanel.SetActive(false);
                break;
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
    [Header("Type Writer")]
    public TutorialType type;
    public string description;
    [Header("Building")]

    public GameObject targetBuildling;
}

public enum TutorialType
{
    TypeWriter,
    Building
}
