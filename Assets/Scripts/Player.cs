using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 mousePos;
    [SerializeField] float minY, maxY;
    [SerializeField] float minX, maxX;
    public enum PolarityState{ CYAN, ORANGE, PURPLE, NORMAL };
    Animator anim;
    public firePattern stream;


    [SerializeField]
    floatVariable playerHP;
    float maxHP = 20;



    public PolarityState pState = PolarityState.NORMAL;

    void Start()
    {
        playerHP.floatValue = maxHP;
        anim = GetComponent<Animator>();
        stream = this.gameObject.GetComponent<firePattern>();
    }

    
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(mousePos);
        float posYlimited = Mathf.Clamp(mousePos.y, minY, maxY);
        float posXlimited = Mathf.Clamp(mousePos.x, minX, maxX);
        transform.position = new Vector3(posXlimited, posYlimited, 0);


        if(Input.GetKeyDown(KeyCode.A))
        {
            pState = PolarityState.CYAN;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            pState = PolarityState.ORANGE;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            pState = PolarityState.PURPLE;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            pState = PolarityState.NORMAL;
        }


        if(Input.GetMouseButtonDown(0))
        {
            //stream.Fire();
        }


        switch (pState)
        {
            case PolarityState.NORMAL:
                {
                    anim.SetInteger("polarState",  0);
                    break;
                }
            case PolarityState.CYAN:
                {
                    anim.SetInteger("polarState", 1);
                    break;
                }
            case PolarityState.PURPLE:
                {
                    anim.SetInteger("polarState", 2);
                    break;
                }
            case PolarityState.ORANGE:
                {
                    anim.SetInteger("polarState", 3);
                    break;
                }
        }

    }


    public void CheckPolarity(bulletEnemyFather.PolarityType polarityType, float damageToDeal)
    {
        switch(polarityType)
        {
            case bulletEnemyFather.PolarityType.CYANB:
                {
                    if (pState != PolarityState.CYAN)
                    {
                        TakeDamage(damageToDeal);
                    }
                    break;
                }

            case bulletEnemyFather.PolarityType.ORANGEB:
                {
                    if (pState != PolarityState.ORANGE)
                    {
                        TakeDamage(damageToDeal);
                    }
                    break;
                }

            case bulletEnemyFather.PolarityType.PURPLEB:
                {
                    if (pState != PolarityState.PURPLE)
                    {
                        TakeDamage(damageToDeal);
                    }
                    break;
                }
        }

    }
    public void TakeDamage(float damageAmount)
    {
        playerHP.floatValue -= damageAmount;
    }
}
