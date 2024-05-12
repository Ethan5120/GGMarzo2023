using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBulletSpawn : BulletSpawnerPrime
{
    public BulletPool colBullet;


    override protected void Awake()
    {
        colBullet = GameObject.FindObjectOfType<Bullet2Pool>();

        //Check Ammount of Streams
        ammountStreams = Streams.Count;
        for(int i = 0; i < ammountStreams; i++)
        {
            Streams[i].spawnPoint.transform.Rotate(Streams[i].rotationStartPoint); 
        }
    }

    override protected void ShootPattern(BulletSpawner stream, int bType)
    {
        if(stream.shootCool <= 0)
        {
            var bullet = (bulletPrime)colBullet.Get();
            bullet.transform.position = stream.spawnPoint.transform.position;
            bullet.transform.rotation = stream.spawnPoint.transform.rotation;
            bullet.GetComponent<bulletPrime>().bulletLife = 1000;
            bullet.GetComponent<bulletPrime>().bulletSpeed = 0.05f;
            bullet.GetComponent<bulletPrime>().ChooseType(bType);
            stream.shootCool = stream.shootDelay;
            stream.spawnPoint.transform.Rotate(new Vector3(0, 0, stream.angleIncrease));
        }
        else
        {
            stream.shootCool -= 1 * GM.gameTime;
        }
        
    }
}