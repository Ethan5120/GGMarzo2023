using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBPattern : firePattern
{
    override public void Fire()
    {
        bulletPool = GameObject.FindObjectOfType<Bullet2Pool>();
        StartCoroutine(firecool());
    }
}
