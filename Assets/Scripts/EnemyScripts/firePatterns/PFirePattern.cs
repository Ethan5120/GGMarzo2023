using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PFirePattern : firePattern
{
    override public void Fire()
    {
        bulletPool = GameObject.FindObjectOfType<PBulletPool>();
        StartCoroutine(firecool());
    }
}
