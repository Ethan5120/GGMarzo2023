using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 mousePos;

    [Header("Movement Limits")]
    [SerializeField] float minY, maxY;
    [SerializeField] float minX, maxX;


    [Header("Player Data")]
    [SerializeField] floatVariable playerHP;
    [SerializeField] float maxHP = 20;
    [SerializeField] floatVariable score;
    public enum PolarityState { CYAN, ORANGE, PURPLE, NORMAL };
    public PolarityState pState = PolarityState.NORMAL;


    [Header("AttackData")]
    [SerializeField] ObjectPool playerBullets;
    [SerializeField] float fireRate, aimAngle, angleIncrease, streamsAmount;
    float fireCool = 0;
    
   
    Animator anim;

    void Start()
    {
        playerHP.floatValue = maxHP;
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log(mousePos);
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


        if(Input.GetButton("Fire1") && fireCool <= 0)
        {
            Fire();
            fireCool = 1f / fireRate;
        }

        fireCool -= Time.deltaTime;


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
                    else
                    {
                        score.floatValue += 10;
                    }
                    break;
                }

            case bulletEnemyFather.PolarityType.ORANGEB:
                {
                    if (pState != PolarityState.ORANGE)
                    {
                        TakeDamage(damageToDeal);
                    }
                    else
                    {
                        score.floatValue += 10;
                    }
                    break;
                }

            case bulletEnemyFather.PolarityType.PURPLEB:
                {
                    if (pState != PolarityState.PURPLE)
                    {
                        TakeDamage(damageToDeal);
                    }
                    else
                    {
                        score.floatValue += 10;
                    }
                    break;
                }
        }

    }


    protected void Fire()
    {
        float bulDirX = transform.position.x + Mathf.Sin((aimAngle + ((360f / streamsAmount)) * Mathf.PI) / (360f / streamsAmount));
        float bulDirY = transform.position.y + Mathf.Cos((aimAngle + ((360f / streamsAmount)) * Mathf.PI) / (360f / streamsAmount));

        Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
        Vector2 bulDir = (bulMoveVector - transform.position).normalized;

        bulletPrime bullet = (bulletPrime)playerBullets.Get();
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;
        bullet.GetComponent<bulletPrime>().SetMoveDirection(bulDir);

        aimAngle += angleIncrease * streamsAmount;
    }

    public void TakeDamage(float damageAmount)
    {
        playerHP.floatValue -= damageAmount;
    }
}
