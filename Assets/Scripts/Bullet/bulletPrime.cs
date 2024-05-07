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



    protected void Update()
    {
       switch (type)
        {
            case BulletType.Straight:
            {
                transform.position += transform.up * bulletSpeed * Time.deltaTime;
                break;
            }
         
            case BulletType.LCurve:
            {
                transform.position += transform.up * bulletSpeed * Time.deltaTime;
                transform.Rotate(0, 0, curveStrength);
                break;
            }            
            
            case BulletType.RCurve:
            {
                transform.position += transform.up * bulletSpeed * Time.deltaTime;
                transform.Rotate(0, 0, -curveStrength);
                break;
            }
            case BulletType.Speed:
            {
                transform.position += transform.up * bulletSpeed * Time.deltaTime;
                bulletSpeed += speedIncrements;
                break;
            }

            case BulletType.LWave:
            {
                waveSpeed = 180;
                transform.position += transform.up * bulletSpeed * Time.deltaTime;
                transform.position += new Vector3(-Mathf.Sin(waveSpeed * waveFreq) * waveAmp,0,0);
                waveSpeed += waveStrength;
                break;
            }            
            
            case BulletType.RWave:
            {
                waveSpeed = 180;
                transform.position += transform.up * bulletSpeed * Time.deltaTime;
                transform.position += new Vector3(Mathf.Sin(waveSpeed * waveFreq) * waveAmp,0,0);
                waveSpeed += waveStrength;
                break;
            }
            case BulletType.LDoubleWave:
            {
                waveSpeed = 1;
                transform.position += transform.up * bulletSpeed * Time.deltaTime;
                transform.position += new Vector3(-Mathf.Sin(waveSpeed * waveFreq) * waveAmp,0,0);
                waveSpeed += waveStrength;
                break;
            }            
            
            case BulletType.RDoubleWave:
            {
                waveSpeed = 1;
                transform.position += transform.up * bulletSpeed * Time.deltaTime;
                transform.position += new Vector3(Mathf.Sin(waveSpeed * waveFreq) * waveAmp,0,0);
                waveSpeed += waveStrength;
                break;
            }

            default:
            {
                transform.position += transform.up * bulletSpeed * Time.deltaTime;
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
