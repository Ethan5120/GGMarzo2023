using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GameManagerController", menuName = "Assets/GameManager", order = 0)]
public class GameManagerSO : ScriptableObject
{
    [Header("GameState")]
    public float gameTime = 1;
    public bool isPause = false;
    public enum GameState {MainMenu, GameWavesRunning, GamePaused, ResultsScreen}
    public GameState cGState;
    public enum StageState{EnemiesStage, BossStage, TutorialStage, WinStage}
    public StageState cStageState;
    [Space(5)]

    [Header("PlayerData")]
    public float playerHealth = 5;
    public float playerMaxHP = 10;
    public int bombCharges = 1;
    public float bulletCool = 0.5f;
    [Space(5)]



    [Header("ScoreData")]
    public float currentScore;
    public float currentHiScore;    

}
