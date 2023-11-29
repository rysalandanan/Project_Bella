using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScreenSettings : MonoBehaviour
{
    [Header("Game script (Settings)")]
    public GameSettings _gameSettings;
    private void OnEnable()
    {
        _gameSettings.PauseGame();
    }
    private void OnDisable()
    {
        _gameSettings.UnpauseGame();
    }
}
