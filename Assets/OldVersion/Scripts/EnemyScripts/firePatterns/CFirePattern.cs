using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFirePattern : firePattern
{
    override public void Fire()
    {
        bulletPool = GameObject.FindObjectOfType<CBulletPool>();
        StartCoroutine(firecool());
    }
}
