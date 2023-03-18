using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 mousePos;
    [SerializeField] float minY, maxY;
    [SerializeField] float minX, maxX;
    protected enum PolarityState{ CYAN, ORANGE, PURPLE };

    [SerializeField]
    floatVariable playerHP;
    float maxHP = 20;
   

    void Start()
    {
        playerHP.floatValue = maxHP;
    }

    // Movimiento script
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(mousePos);
        float posYlimited = Mathf.Clamp(mousePos.y, minY, maxY);
        float posXlimited = Mathf.Clamp(mousePos.x, minX, maxX);
        transform.position = new Vector3(posXlimited, posYlimited, 0);
    }


    public void TakeDamage(float damageAmmount)
    {
        playerHP.floatValue -= damageAmmount;
    }
}
