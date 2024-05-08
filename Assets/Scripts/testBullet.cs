using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testBullet : MonoBehaviour
{
    public enum BulletType{Straight, LCurve, RCurve, Speed, LWave, RWave, LDoubleWave, RDoubleWave}
    public BulletType type;

    [Header("Bullet Data:")]
    [Header("   General Bullets:")]
    public float bulletSpeed = 1;

    [Header("   Curve Bullets:")]
    public float curveStrength = 1;

    [Header("   Speed Bullets:")]
    public float speedIncrements;

    [Header("   Wave Bullets:")]
    public float waveStrength = 1;
    public float waveSpeed = 180;
    public float waveFreq = 1;
    public float waveAmp = 1;
    
// A bit of warning on the types of bullets here if you want to use de Wave types of bullets the waveSpeed must be 180 at the start,
// but if you want to use the "double wave" ones, you can usea almost any value, 1 works great
// Use this script to test variables to then know what to asign to the bullets form the pool in the shooting scripts.
    void Update()
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
                transform.position += transform.up * bulletSpeed * Time.deltaTime;
                transform.position += -transform.right * Mathf.Sin(waveSpeed * waveFreq) * waveAmp * Time.deltaTime;
                waveSpeed += waveStrength;
                break;
            }            
            
            case BulletType.RWave:
            {
                transform.position += transform.up * bulletSpeed * Time.deltaTime;
                transform.position += transform.right * Mathf.Sin(waveSpeed * waveFreq) * waveAmp;
                waveSpeed += waveStrength;
                break;
            }
            case BulletType.LDoubleWave:
            {
                transform.position += transform.up * bulletSpeed * Time.deltaTime;
                transform.position += -transform.right * Mathf.Sin(waveSpeed * waveFreq) * waveAmp;
                waveSpeed += waveStrength;
                break;
            }            
            
            case BulletType.RDoubleWave:
            {
                transform.position += transform.up * bulletSpeed * Time.deltaTime;
                transform.position += transform.right * Mathf.Sin(waveSpeed * waveFreq) * waveAmp;
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
    
}
