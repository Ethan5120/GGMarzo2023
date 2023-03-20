using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] boolVariable isWavesCompleted;
    [SerializeField] floatVariable playerHealth;
    [SerializeField] intVariable bCharges;
    [SerializeField] BossFactory bossFactory;
    [SerializeField] Image[] bChargesDisplay;
    [SerializeField] Sprite[] bChargesSprites;
    bool HasBossSpawned = false;
    void Start()
    {
        HasBossSpawned = false;
    }

    void Update()
    {
        if (isWavesCompleted.boolValue == true && HasBossSpawned == false)
        {
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }



    }
}
