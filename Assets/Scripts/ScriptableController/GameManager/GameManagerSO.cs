using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerSO : ScriptableObject
{
    [Header("GameState")]
    public float gameTime = 1;
    public enum GameState {MainMenu, GameWavesRunning, GamePaused, ResultsScreen}
    public GameState cGState;
    public enum StageState{EnemiesStage, BossStage, TutorialStage}
    public StageState cStageState;
    [Space(5)]

    [Header("PlayerData")]
    public float playerHealth = 5;
    public float playerMaxHP = 10;
    public int bombCharges = 1;
    [Space(5)]


    [Header("AudioData")]
    public AudioSource[] gameMusic;
    [Space(5)]

    [Header("ScoreData")]
    public float currentScore;
    public float currentHiScore;    

}
