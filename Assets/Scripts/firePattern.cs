using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firePattern : MonoBehaviour
{
    [SerializeField] protected float angle;
    public ObjectPool bulletPool;
    [SerializeField] float streamsAmmount;
    [SerializeField] float Cooldown = 0.1f, AngleIncrease = 1f;

    private void Start()
    {
        //Fire();
    }

    public void Fire()
    {
        StartCoroutine(firecool());
    }

    IEnumerator firecool()
    {
        while (true)
        {
            for(int i = 0; i < streamsAmmount; i++)
            {
                float bulDirX = transform.position.x + Mathf.Sin((angle + ((360f / streamsAmmount) * i) * Mathf.PI) / (360f / streamsAmmount));
                float bulDirY = transform.position.y + Mathf.Cos((angle + ((360f / streamsAmmount) * i) * Mathf.PI) / (360f / streamsAmmount));

                Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
                Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                bulletEnemyFather bullet = (bulletEnemyFather)bulletPool.Get();
                bullet.transform.position = transform.position;
                bullet.transform.rotation = transform.rotation;
                bullet.GetComponent<bulletEnemyFather>().SetMoveDirection(bulDir);

                angle += AngleIncrease * streamsAmmount;
            }

            yield return new WaitForSeconds(Cooldown);
        }
    }

}
