using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class overScreenData : MonoBehaviour
{
    [Header("ScoreSettings")]
    [SerializeField] floatVariable playerScore;
    [SerializeField] floatVariable playerHScore;
    [SerializeField] TextMeshProUGUI Score, HiScore;
    void Start()
    {
        Score.text = playerScore.floatValue.ToString();
        HiScore.text = playerHScore.floatValue.ToString();
    }
}
