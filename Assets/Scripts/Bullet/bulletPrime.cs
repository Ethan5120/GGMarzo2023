using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletPrime : PooledObject
{
    public enum BulletType{Straight, LCurve, RCurve, Speed, LWave, RWave, LDoubleWave, RDoubleWave}
    public BulletType type;

    [Header("Bullet Data:")]
    [Header("   General Bullets:")]
    public float bulletSpeed = 1;

    [Header("   Curve Bullets:")]
    public float curveStrength = 1;

    [Header("   Speed Bullets:")]
    public float speedIncrements = 0.1f;

    [Header("   Wave Bullets:")]
    public float waveStrength = 1;
    public float waveSpeed = 180;
    public float waveFreq = 1;
    public float waveAmp = 1;
    protected float damage = 1;


    public float bulletLife;



    protected void FixedUpdate()
    {
        bulletLife--;
        if(bulletLife <= 0)
        {
            Release();
        }
       switch (type)
        {
            case BulletType.Straight:
            {
                transform.position += transform.up * bulletSpeed;
                break;
            }
         
            case BulletType.LCurve:
            {
                transform.position += transform.up * bulletSpeed;
                transform.Rotate(0, 0, curveStrength);
                break;
            }            
            
            case BulletType.RCurve:
            {
                transform.position += transform.up * bulletSpeed;
                transform.Rotate(0, 0, -curveStrength);
                break;
            }
            case BulletType.Speed:
            {
                transform.position += transform.up * bulletSpeed;
                bulletSpeed += bulletSpeed * speedIncrements;
                break;
            }

            case BulletType.LWave:
            {
                transform.position += transform.up * bulletSpeed;
                transform.position += -transform.right * Mathf.Sin(waveSpeed * waveFreq) * waveAmp;
                waveSpeed += waveStrength;
                break;
            }            
            
            case BulletType.RWave:
            {
                transform.position += transform.up * bulletSpeed;
                transform.position += -transform.right * Mathf.Sin(waveSpeed * waveFreq) * waveAmp;
                waveSpeed += waveStrength;
                break;
            }
            case BulletType.LDoubleWave:
            {
                transform.position += transform.up * bulletSpeed;
                transform.position += -transform.right * Mathf.Sin(waveSpeed * waveFreq) * waveAmp;
                waveSpeed += waveStrength;
                break;
            }            
            
            case BulletType.RDoubleWave:
            {
                transform.position += transform.up * bulletSpeed;
                transform.position += transform.right * Mathf.Sin(waveSpeed * waveFreq) * waveAmp;
                waveSpeed += waveStrength;
                break;
            }

            default:
            {
                transform.position += transform.up * bulletSpeed;
                break;
            }

        }
    }
    
    public void ChooseType(int bPath)
    {
        switch(bPath)
        {
            case 0:
            {
                type = BulletType.Straight;
                break;
            }
            case 1:
            {
                type = BulletType.LCurve;
                break;
            }
            case 2:
            {
                type = BulletType.RCurve;
                break;
            }
            case 3:
            {
                type = BulletType.Speed;
                break;
            }
            case 4:
            {
                waveSpeed = 180;
                type = BulletType.LWave;
                break;
            }
            case 5:
            {
                waveSpeed = 180;
                type = BulletType.RWave;
                break;
            }
            case 6:
            {
                waveSpeed = 1;
                type = BulletType.LDoubleWave;
                break;
            }
            case 7:
            {
                waveSpeed = 1;
                type = BulletType.RDoubleWave;
                break;
            }
            default:
            {
                type = BulletType.Straight;
                break;
            }
        }
    }
    virtual protected void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.TryGetComponent<Wall>(out Wall wallComponent))
        {
            Release();
        }
    }
}
