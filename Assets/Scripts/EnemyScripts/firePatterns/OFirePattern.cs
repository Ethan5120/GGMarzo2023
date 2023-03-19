using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OFirePattern : firePattern
{
    override public void Fire()
    {
        bulletPool = GameObject.FindObjectOfType<OBulletPool>();
        StartCoroutine(firecool());
    }
}
