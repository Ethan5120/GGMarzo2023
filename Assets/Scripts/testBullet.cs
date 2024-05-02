using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testBullet : MonoBehaviour
{
    public enum BulletType{Straight, LCurve, RCurve, Speed, LLoop, RLoop}
    public BulletType type;

    [Header("Bullet Data:")]
    [Header("   General Bullets:")]
    public float bulletSpeed = 1;

    [Header("   Curve Bullets:")]
    public float curveStrength = 1;

    [Header("   Speed Bullets:")]
    public float speedIncrements;

    [Header("   Loop Bullets:")]
    public float loopStrength = 1;
    public float speedLoop = 1;

    float curveVal;
    


    void Awake()
    {
        curveStrength /= 360;
        loopStrength /= 360;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
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

            case BulletType.LLoop:
            {
                transform.position += transform.up * bulletSpeed * Time.deltaTime;
                transform.Rotate(0, 0, loopStrength);
                bulletSpeed += speedLoop;
                break;
            }            
            
            case BulletType.RLoop:
            {
                transform.position += transform.up * bulletSpeed * Time.deltaTime;
                transform.Rotate(0, 0, -loopStrength);
                bulletSpeed += speedLoop;
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
