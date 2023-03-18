using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{ 
    public enum PolarityState{CYAN, ORANGE, PURPLE};

    [SerializeField]
    floatVariable playerHP;
    float maxHP = 20;
   

    void Start()
    {
        playerHP.floatValue = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damageAmmount)
    {
        playerHP.floatValue -= damageAmmount;
    }
}
