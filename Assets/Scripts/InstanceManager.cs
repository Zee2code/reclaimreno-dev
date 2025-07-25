using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceManager : MonoBehaviour
{
    public static InstanceManager Instance;
    public Upgrade upgrade;
    public TypeWriter typeWriter;
    public TutorialManager tutorialManager;
    private void Awake()
    {
        if (!Instance)
            Instance = this;
    }
}
