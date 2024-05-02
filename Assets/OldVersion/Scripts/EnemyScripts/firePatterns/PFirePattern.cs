using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireYPattern : firePattern
{
    override public void Fire()
    {
        bulletPool = GameObject.FindObjectOfType<Bullet3Pool>();
        StartCoroutine(firecool());
    }
}
