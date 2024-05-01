using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerSO : ScriptableObject
{
    [Header("GameState")]
    public float gameTime = 1;
    public enum GameState {MainMenu, GameWavesRunning, GameBoss, GamePaused, GameWin, GameLose, SecretFound}
    [Space(5)]

    [Header("PlayerData")]
    public float playerHealth = 5;


}
