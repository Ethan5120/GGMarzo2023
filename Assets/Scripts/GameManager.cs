using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("GameManager")]
    [SerializeField] GameManagerSO GM;

    [Header("BombState")]
    [SerializeField] Image[] bChargesDisplay;

    [Header("AudioData")]
    public AudioSource[] gameMusic;
    [Space(5)]

    [Header("ScoreSettings")]
    [SerializeField] TextMeshProUGUI Score, HiScore;
    [Space(5)]
    [Header("UIData")]
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject EndScreen;
    [Space(5)]

    [Header("Boss")]
    [SerializeField] GameObject Boss;
    [SerializeField] GameObject BossHpBar;
    [Space(5)]

    [Header("ResultsScreen")]
    [SerializeField] TextMeshProUGUI HiScoreResult;
    [SerializeField] TextMeshProUGUI ScoreResult;
    [SerializeField] TextMeshProUGUI BulletsMatched;
    [SerializeField] TextMeshProUGUI BulletsMatchedScore;
    [SerializeField] TextMeshProUGUI HitsRecieved;
    [SerializeField] TextMeshProUGUI HitsRecievedScore;
    [SerializeField] TextMeshProUGUI FinalScore;


    GameManagerSO.StageState currentState;


    void Start()
    {
        GM.bullMatched = 0;
        GM.hits = 0;
        Boss.SetActive(false);
        BossHpBar.SetActive(false);
        GM.isPause = false;
        GM.canPause = true;
        GM.cGState = GameManagerSO.GameState.GameWavesRunning;
        GM.cStageState = GameManagerSO.StageState.EnemiesStage;
        GM.gameTime = 1;
        EndScreen.SetActive(false);
        GM.currentScore = 0;
        GM.currentHiScore = PlayerPrefs.GetInt("Hi-Score");
        gameMusic[1].Play();

        if (GM.currentHiScore < 999999)
        {
            HiScore.text =GM.currentHiScore.ToString();
        }
        else if (GM.currentHiScore >= 999999)
        {
            HiScore.text = "999999+";
        }

    }

    void Update()
    {
        ChangeSong();
        if(GM.cGState == GameManagerSO.GameState.GamePaused)
        {
            PauseMenu.SetActive(true);
        }
        else
        {
            PauseMenu.SetActive(false);
        }

        if (GM.playerHealth <= 0)
        {
            GameEnds();
        }
        else if(GM.playerHealth > 0 && GM.cStageState == GameManagerSO.StageState.WinStage)
        {
            GameEnds();
        }



        if (GM.currentScore < 999999)
        {
            Score.text = GM.currentScore.ToString();
        }
        else if (GM.currentScore >= 999999)
        {
            Score.text = "999999+";
        }
    }


    void GameEnds()
    {
        SetFinalResults();
        Cursor.visible = true;
        GM.gameTime = 0;
        GM.isPause = true;
        GM.canPause = true;
        EndScreen.SetActive(true);
        if (GM.currentHiScore < GM.currentScore)
        {
            GM.currentHiScore = GM.currentScore;
            PlayerPrefs.SetInt("Hi-Score", GM.currentScore);
        }
    }

    void ChangeSong()
    {
        if(GM.cStageState != currentState)
        {
            switch(GM.cStageState)
            {
                case GameManagerSO.StageState.TutorialStage:
                {
                    currentState = GM.cStageState;
                    gameMusic[1].Stop();
                    gameMusic[2].Stop();
                    gameMusic[0].Play();
                    break;
                }

                case GameManagerSO.StageState.EnemiesStage:
                {
                    currentState = GM.cStageState;
                    gameMusic[0].Stop();
                    gameMusic[2].Stop();
                    gameMusic[1].Play();
                    break;
                }

                case GameManagerSO.StageState.BossStage:
                {
                    currentState = GM.cStageState;
                    gameMusic[0].Stop();
                    gameMusic[1].Stop();
                    gameMusic[2].Play();
                    Boss.SetActive(true);
                    BossHpBar.SetActive(true);
                    break;
                }
            }
        }
    }

    void SetFinalResults()
    {
        HiScoreResult.text = GM.currentHiScore.ToString();
        ScoreResult.text = GM.currentScore.ToString();
        BulletsMatched.text = GM.bullMatched.ToString();
        BulletsMatchedScore.text = (GM.bullMatched * 100).ToString();
        HitsRecieved.text = GM.hits.ToString();
        HitsRecievedScore.text = (GM.hits * -100).ToString();
        GM.finalScore = GM.currentScore + (GM.bullMatched * 100) + (GM.hits * -100);
        FinalScore.text = GM.finalScore.ToString();
    }

}
