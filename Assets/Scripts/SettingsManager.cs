using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Toggle toggleEasy;
    public Toggle toggleMedium;
    public Toggle toggleHard;

    void Start()
    {
        // Ensure the script subscribes to the toggle events
        toggleEasy.onValueChanged.AddListener(delegate { HandleToggle(toggleEasy, "Easy"); });
        toggleMedium.onValueChanged.AddListener(delegate { HandleToggle(toggleMedium, "Medium"); });
        toggleHard.onValueChanged.AddListener(delegate { HandleToggle(toggleHard, "Hard"); });

        if (toggleEasy.isOn) HandleToggle(toggleEasy, "Easy");
        else if (toggleMedium.isOn) HandleToggle(toggleMedium, "Medium");
        else if (toggleHard.isOn) HandleToggle(toggleHard, "Hard");
    }

    // General handler that checks which toggle was changed
    void HandleToggle(Toggle changedToggle, string optionName)
    {
        if (changedToggle.isOn)
        {
            switch (optionName)
            {
                case "Easy":
                    GameManager.instance.SetGridSize(2, 2);
                    break;
                case "Medium":
                    GameManager.instance.SetGridSize(2, 3);
                    break;
                case "Hard":
                    GameManager.instance.SetGridSize(5, 6);
                    break;
                default:
                    Debug.LogError("Unhandled option");
                    break;
            }
        }
    }
}
