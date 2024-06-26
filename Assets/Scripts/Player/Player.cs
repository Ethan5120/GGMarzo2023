using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    Vector3 mousePos;
    [Header("GameManager")]
    [SerializeField] GameManagerSO GM;

    [Header("Movement Limits")]
    [SerializeField] float minY, maxY;
    [SerializeField] float minX, maxX;

    public enum PolarityState { RED, BLUE, YELLOW, NORMAL }; //OnE = Red; Two = Blue; Three = Yellow
    [Space(5)]

    [Header("Player Data")]
    [SerializeField] TestColorSwap colorChanger;
    public PolarityState pState = PolarityState.NORMAL;
    public float IFrames = 5;
    float cIFrames;

    [Space(5)]

    [Header("AttackData")]
    [SerializeField] ObjectPool playerBullets;
    [SerializeField] float fireRate;
    [SerializeField] AudioSource shootSFX;

    [Header("BombData")]
    [SerializeField] GameObject bFlash;
    [SerializeField] AudioSource bombSFX;
    float fireCool = 0;
    float flashTime = -1 ;

    [Header("UI Elements")]
    [SerializeField] hpBar healthBar;
    [SerializeField] AudioSource pauseSFX;

    [Header("TestingParameters")]
    [SerializeField] int hits;
    [SerializeField] TextMeshProUGUI Hits;


    void Start()
    {
        hits = 0;

        bFlash.SetActive(false);
        colorChanger = GetComponent<TestColorSwap>();
        Cursor.visible = false;
        //healthBar.SetMaxHealth(maxHP);
    }

    
    void Update()
    {
        //Delete this at the final compilation
        Hits.text = hits.ToString();


        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log(mousePos);
        float posYlimited = Mathf.Clamp(mousePos.y, minY, maxY);
        float posXlimited = Mathf.Clamp(mousePos.x, minX, maxX);
        
        if(!GM.isPause)
        {
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
            
            
        }





        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseSFX?.Play();
            if(GM.isPause)
            {
                GM.isPause = false;
                GM.gameTime = 1;
                Cursor.visible = false;
            }
            else
            {
                GM.isPause = true;
                GM.gameTime = 0;
                Cursor.visible = true;
            }
        }
        


        if (Input.GetButtonDown("Jump") && GM?.bombCharges > 0)
        {
            ClearScreen();
            flashTime = 0.1f;
            GM.bulletCool = 0.5f;
            GM.bombCharges -= 1;
        }

        if (Input.GetButton("Fire1") && fireCool <= 0 && !GM.isPause)
        {
            Fire();
            shootSFX?.Play();
            fireCool = 1f / fireRate;
        }

        if(fireCool >= 0) {fireCool -= Time.deltaTime * GM.gameTime;}
        if(GM.bulletCool >= 0) {GM.bulletCool -= Time.deltaTime * GM.gameTime;}
        if(cIFrames >= 0) {cIFrames -= Time.deltaTime* GM.gameTime;}

        if(flashTime >= 0)
        {
            flashTime -= Time.deltaTime * GM.gameTime;
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
                    colorChanger.colorNumber = 0;
                    break;
                }
            case PolarityState.RED:
                {
                    colorChanger.colorNumber = 1;
                    break;
                }
            case PolarityState.BLUE:
                {
                    colorChanger.colorNumber = 2;
                    break;
                }
            case PolarityState.YELLOW:
                {
                    colorChanger.colorNumber = 3;
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
                    if (pState != PolarityState.RED && cIFrames < 0)
                    {
                        TakeDamage(damageToDeal);
                    }
                    else
                    {
                        GM.currentScore += 1;
                    }
                    break;
                }

            case bulletEnemyFather.PolarityType.BLUEB:
                {
                    if (pState != PolarityState.BLUE && cIFrames < 0)
                    {
                        TakeDamage(damageToDeal);
                    }
                    else
                    {
                        GM.currentScore += 1;
                    }
                    break;
                }

            case bulletEnemyFather.PolarityType.YELLOWB:
                {
                    if (pState != PolarityState.YELLOW && cIFrames < 0)
                    {
                       TakeDamage(damageToDeal);
                    }
                    else
                    {
                        GM.currentScore += 1;
                    }
                    break;
                }
        }

    }


    protected void Fire()
    {
        var bullet = (bulletPrime)playerBullets.Get();
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;
        bullet.GetComponent<bulletPrime>().bulletLife = 500;
    }

    protected void ClearScreen()
    {
        bulletEnemyFather[] enemyBullets = FindObjectsOfType<bulletEnemyFather>();
        bombSFX?.Play();

        foreach (bulletEnemyFather enemyBullet in enemyBullets)
        {
            enemyBullet.Release();
        }
    }


    public void TakeDamage(float damageAmount)
    {
        GM.playerHealth -= damageAmount;
        hits++;
        cIFrames = IFrames;
        healthBar?.SetHealth(GM.playerHealth);
    }
}
