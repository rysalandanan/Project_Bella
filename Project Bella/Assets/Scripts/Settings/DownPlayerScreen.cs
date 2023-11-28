using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownPlayerScreen : MonoBehaviour
{
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
