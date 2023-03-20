using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] boolVariable isWavesCompleted;
    [SerializeField] BossFactory bossFactory;
    [SerializeField] intVariable bCharges;
    [SerializeField] SpriteRenderer[] bChargesDisplay;
    [SerializeField] Sprite[] bChargesSprites;
    bool HasBossSpawned = false;
    void Start()
    {
      
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
    }
}
