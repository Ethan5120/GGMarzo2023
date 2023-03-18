using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firePattern : MonoBehaviour
{
    private float angle = 0f;
    public ObjectPool yBulletPool;


    private void Start()
    {
        InvokeRepeating("Fire", 0f, 0.1f);
    }

    private void Fire()
    {
        float bulDirX = transform.position.x + Mathf.Sin((angle + Mathf.PI / 100f));
        float bulDirY = transform.position.y + Mathf.Cos((angle + Mathf.PI / 100f));

        Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
        Vector2 bulDir = (bulMoveVector - transform.position).normalized;

        bulletEYellow bullet = (bulletEYellow) yBulletPool.Get();
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;
        bullet.GetComponent <bulletEYellow>().SetMoveDirection(bulDir);

        angle += 10f;

    }

}
