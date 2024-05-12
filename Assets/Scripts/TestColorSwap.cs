using System.Collections;
using UnityEngine;

public class TestColorSwap : MonoBehaviour
{
    public bool isChanging;
    public int colorNumber;
    float changeRate;
    public float time;
    SpriteRenderer currentSprite;
    public Color currentColor = new(1,1,1);
    public Color newColor;
    Color white = new(1, 1, 1);
    Color red = new(0.9333333f, 0.1098039f, 0.1411765f);
    Color blue = new(0, 1, 1);
    Color yellow = new(1, 0.8941177f, 0.2980392f);


    void Awake()
    {
        currentSprite = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        currentSprite.color = currentColor;


        switch (colorNumber)
        {
            case 0:
            {
                StartChange(white);
                break;
            }
                
            case 1:
            {
                StartChange(red);
                break;
            }
                
            case 2:
            {
                StartChange(blue);
                break;
            }
                
            case 3:
            {
                StartChange(yellow);
                break;
            }
            default:
            {
                StartChange(white);
                break;
            }
        }
        
    }

    void StartChange(Color tempColor)
    {
        isChanging = true;
        changeRate += Time.deltaTime / time; // * gameTime;

        currentColor = Color.Lerp(currentColor, tempColor, changeRate);
        if(changeRate >= 1f)
        {
            changeRate = 0;
            currentColor = tempColor;
            isChanging = false;
        }
        
    }

}
