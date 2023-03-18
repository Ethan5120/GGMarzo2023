using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firePattern : MonoBehaviour
{
    private float angle = 0f;
    public ObjectPool bulletPool;


    [SerializeField] float Cooldown = 0.1f, AngleIncrease = 1f;

    private void Start()
    {
        Fire();
    }

    private void Fire()
    {
        StartCoroutine(firecool());
    }

    IEnumerator firecool()
    {
        while (true)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle + Mathf.PI / 100f));
            float bulDirY = transform.position.y + Mathf.Cos((angle + Mathf.PI / 100f));

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            bulletEnemyFather bullet = (bulletEnemyFather)bulletPool.Get();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.GetComponent<bulletEnemyFather>().SetMoveDirection(bulDir);

            angle += AngleIncrease;

            yield return new WaitForSeconds(Cooldown);
        }
    }

}
