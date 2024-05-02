using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BossBulletSpawner : MonoBehaviour
{
    [System.Serializable]
    public class BulletSpawner
    {
        public GameObject spawnPoint;
        public float shootCool;
        public float shootDelay;
        public float angleIncrease;
        public Vector3 rotationStartPoint;
    }

    public List<BulletSpawner> Streams = new List<BulletSpawner>();
    float ammountStreams;
    [SerializeField] GameObject tBullet;


    void Awake()
    {
        //Check Ammount of Streams
        ammountStreams = Streams.Count;
        for(int i = 0; i < ammountStreams; i++)
        {
            Streams[i].spawnPoint.transform.Rotate(Streams[i].rotationStartPoint); 
        }
    }

    void Update()
    {
        for(int i = 0; i < ammountStreams; i++)
        {
            ShootPattern(Streams[i]);
        }
    }


    void ShootPattern(BulletSpawner stream)
    {
        if(stream.shootCool <= 0)
        {
            var bullet = Instantiate(tBullet, stream.spawnPoint.transform.position, stream.spawnPoint.transform.rotation);
            bullet.GetComponent<testBullet>().type = testBullet.BulletType.LCurve;
            stream.shootCool = stream.shootDelay;
            stream.spawnPoint.transform.Rotate(new Vector3(0, 0, stream.angleIncrease));
        }
        else
        {
            stream.shootCool--;
        }
        
    }
}
