using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("GameStateChecks")]
    [SerializeField] boolVariable isWavesCompleted, bossDead;
    [SerializeField] AudioSource[] gameMusic;

    [Header("PlayerState")]
    [SerializeField] floatVariable playerHealth;

    [Header("BombState")]
    [SerializeField] intVariable bCharges;
    [SerializeField] Image[] bChargesDisplay;
    [SerializeField] Sprite[] bChargesSprites;

    [Header("BossCheck")]
    [SerializeField] BossFactory bossFactory;

    [Header("ScoreSettings")]
    [SerializeField] floatVariable playerScore, playerHScore;
    [SerializeField] TextMeshProUGUI Score, HiScore;

    bool HasBossSpawned = false;
    void Start()
    {
        HasBossSpawned = false;
        playerScore.floatValue = 0;
        bossDead.boolValue = false;

        if (playerHScore.floatValue < 999999)
        {
            HiScore.text ="HI-SCORE\n" + playerHScore.floatValue.ToString();
        }
        else if (playerHScore.floatValue >= 999999)
        {
            HiScore.text = "HI-SCORE\n999999+";
        }

    }

    void Update()
    {
        if (isWavesCompleted.boolValue == true && HasBossSpawned == false)
        {
            gameMusic[0].Stop();
            gameMusic[1].Play();
            HasBossSpawned = true;
            BossController thisenemy = (BossController) bossFactory.GetProduct(new Vector2(0f, 6f));

        }

        switch (bCharges.intValue)
        {
            case 0:
                {
                    bChargesDisplay[bCharges.intValue].sprite = bChargesSprites[0];
                    break;
                }

            case 1:
                {
                    bChargesDisplay[bCharges.intValue].sprite = bChargesSprites[0];
                    break;
                }

            case 2:
                {
                    bChargesDisplay[bCharges.intValue].sprite = bChargesSprites[0];
                    break;
                }
        }

        if (playerHealth.floatValue <= 0)
        {
            GameLose();
        }



        if (playerScore.floatValue < 999999)
        {
            Score.text = "SCORE\n" + playerScore.floatValue.ToString();
        }
        else if (playerScore.floatValue >= 999999)
        {
            Score.text = "SCORE\n999999+";
        }
    }


    void GameLose()
    {
        if (playerHScore.floatValue < playerScore.floatValue)
        {
            playerHScore.floatValue = playerScore.floatValue;
        }
        SceneManager.LoadScene(2);
    }
}
