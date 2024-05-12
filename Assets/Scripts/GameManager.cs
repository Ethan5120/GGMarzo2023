using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("GameManager")]
    [SerializeField] GameManagerSO GM;

    [Header("BombState")]
    [SerializeField] Image[] bChargesDisplay;



    [Header("ScoreSettings")]
    [SerializeField] TextMeshProUGUI Score, HiScore;

    [Header("Boss")]
    [SerializeField] GameObject Boss;

    void Start()
    {
        GM.currentScore = 0;
        GM.currentHiScore = PlayerPrefs.GetFloat("Hi-Score");

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
        switch(GM.cStageState)
        {
            case GameManagerSO.StageState.TutorialStage:
            {

                break;
            }

            case GameManagerSO.StageState.EnemiesStage:
            {

                break;
            }

            case GameManagerSO.StageState.BossStage:
            {
                GM.gameMusic[0].Stop();
                GM.gameMusic[1].Play();
                Boss.SetActive(true);
                break;
            }
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
        if (GM.currentHiScore < GM.currentScore)
        {
            GM.currentHiScore = GM.currentScore;
            PlayerPrefs.SetFloat("Hi-Score", GM.currentScore);
        }
        //Activate RResults Panel
    }
}
