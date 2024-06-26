using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnerPrime : MonoBehaviour
{
    [System.Serializable]
    public class BulletSpawner
    {
        public GameObject spawnPoint;
        public float shootCool;
        public float shootDelay;
        public float angleIncrease;
        public Vector3 rotationStartPoint;
        public int colorType;
        public int bulletType;
    }

    public List<BulletSpawner> Streams = new List<BulletSpawner>();
    protected float ammountStreams;
    public List<BulletPool> colorBullet = new List<BulletPool>();
    public bool willFire = false;

    [Header("GameManager")]
    [SerializeField] protected GameManagerSO GM;


    virtual protected void Awake()
    {
        //Check Ammount of Streams
        ammountStreams = Streams.Count;
        for(int i = 0; i < ammountStreams; i++)
        {
            Streams[i].spawnPoint.transform.Rotate(Streams[i].rotationStartPoint); 
        }
    }

    virtual protected void FixedUpdate()
    {
        if(willFire && !GM.isPause)
        {
            for(int i = 0; i < ammountStreams; i++)
            {
                ShootPattern(Streams[i], Streams[i].bulletType);
            }
        }
    }


    virtual protected void ShootPattern(BulletSpawner stream, int bType)
    {
        if(stream.shootCool <= 0)
        {
            var bullet = (bulletPrime)colorBullet[stream.colorType].Get();
            bullet.transform.position = stream.spawnPoint.transform.position;
            bullet.transform.rotation = stream.spawnPoint.transform.rotation;
            bullet.GetComponent<bulletPrime>().bulletLife = 500;
            bullet.GetComponent<bulletPrime>().bulletSpeed = 0.02f;
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
