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

    public enum PolarityState { RED, BLUE, YELLOW, NORMAL }; //OnE = Red; Two = Blue; Three = Red
    [Space(5)]

    [Header("Player Data")]
    public PolarityState pState = PolarityState.NORMAL;
    [Space(5)]

    [Header("AttackData")]
    [SerializeField] ObjectPool playerBullets;
    [SerializeField] float fireRate, aimAngle, angleIncrease, streamsAmount;
    [SerializeField] AudioSource shootSFX;

    [Header("BombData")]
    [SerializeField] intVariable bombAmount;
    [SerializeField] GameObject bFlash;
    [SerializeField] floatVariable bullCool;
    [SerializeField] AudioSource bombSFX;
    float fireCool = 0;
    float flashTime = 0;

    [Header("UI Elements")]
    [SerializeField] hpBar healthBar;
    [SerializeField] AudioSource pauseSFX;

    Animator anim;

    void Start()
    {
        bFlash.SetActive(false);
        //playerHP.floatValue = maxHP;
        bombAmount.intValue = 3;
        anim = GetComponent<Animator>();
        //healthBar.SetMaxHealth(maxHP);
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
            pState = PolarityState.RED;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            pState = PolarityState.BLUE;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            pState = PolarityState.YELLOW;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            pState = PolarityState.NORMAL;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseSFX.Play();
        }
        


        if (Input.GetButtonDown("Jump") && bombAmount.intValue > 0)
        {
            ClearScreen();
            flashTime = 0.1f;
            bullCool.floatValue = 0.5f;
            bombAmount.intValue -= 1;
        }

        if (Input.GetButton("Fire1") && fireCool <= 0)
        {
            Fire();
            shootSFX.Play();
            fireCool = 1f / fireRate;
        }

        fireCool -= Time.deltaTime;
        flashTime -= Time.deltaTime;
        bullCool.floatValue -= Time.deltaTime;

        if(flashTime > 0)
        {
            bFlash.SetActive(true);
        }
        else
        {
            bFlash.SetActive(false);
        }



        switch (pState)
        {
            case PolarityState.NORMAL:
                {
                    anim.SetInteger("polarState",  0);
                    break;
                }
            case PolarityState.RED:
                {
                    anim.SetInteger("polarState", 1);
                    break;
                }
            case PolarityState.BLUE:
                {
                    anim.SetInteger("polarState", 2);
                    break;
                }
            case PolarityState.YELLOW:
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
            case bulletEnemyFather.PolarityType.REDB:
                {
                    if (pState != PolarityState.RED)
                    {
                        //TakeDamage(damageToDeal);
                    }
                    else
                    {
                        //score.floatValue += 10;
                    }
                    break;
                }

            case bulletEnemyFather.PolarityType.BLUEB:
                {
                    if (pState != PolarityState.BLUE)
                    {
                        //TakeDamage(damageToDeal);
                    }
                    else
                    {
                        //score.floatValue += 10;
                    }
                    break;
                }

            case bulletEnemyFather.PolarityType.YELLOWB:
                {
                    if (pState != PolarityState.YELLOW)
                    {
                       //TakeDamage(damageToDeal);
                    }
                    else
                    {
                        //score.floatValue += 10;
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

        aimAngle += angleIncrease * streamsAmount;
    }

    protected void ClearScreen()
    {
        bulletEnemyFather[] enemyBullets = FindObjectsOfType<bulletEnemyFather>();
        bombSFX.Play();

        foreach (bulletEnemyFather enemyBullet in enemyBullets)
        {
            enemyBullet.Release();
        }
    }

    /*public void Heal()
    {
        if(playerHP.floatValue < 25)
        {
            playerHP.floatValue += 5;
            healthBar.SetHealth(playerHP.floatValue);
        }
        else if (playerHP.floatValue >= 25)
        {
            playerHP.floatValue = 30;
            healthBar.SetHealth(playerHP.floatValue);
        }
    }

    public void TakeDamage(float damageAmount)
    {
        playerHP.floatValue -= damageAmount;
        healthBar.SetHealth(playerHP.floatValue);
    }*/
}
