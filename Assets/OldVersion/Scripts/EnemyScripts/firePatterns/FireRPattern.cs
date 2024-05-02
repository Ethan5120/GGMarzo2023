using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRPattern : firePattern
{
    override public void Fire()
    {
        bulletPool = GameObject.FindObjectOfType<Bullet1Pool>();
        StartCoroutine(firecool());
    }
}
