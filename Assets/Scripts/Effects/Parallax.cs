using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    enum MoveDir {UP, DOWN, LEFT, RIGHT}   
    [SerializeField] MoveDir moveMode;


    [SerializeField] float moveInterval = 0;
    [SerializeField] float maxMovement;

    void FixedUpdate()
    {
        switch (moveMode)
        {
            case MoveDir.UP:
            {
                transform.position = new Vector2(0, transform.position.y + moveInterval);
                if (transform.position.y > maxMovement)
                {
                    transform.position = new Vector2(0,0);
                }
            
                break;
            }

            case MoveDir.DOWN:
            {
                transform.position = new Vector2(0, transform.position.y + -moveInterval);
                if (transform.position.y < -maxMovement)
                {
                    transform.position = new Vector2(0,0);
                }
            
                break;
            }

            case MoveDir.LEFT:
            {
                transform.position = new Vector2(transform.position.x + -moveInterval, 0);
                if (transform.position.x < -maxMovement)
                {
                    transform.position = new Vector2(0,0);
                }
            
                break;
            }

            case MoveDir.RIGHT:
            {
                transform.position = new Vector2(transform.position.x + moveInterval, 0);
                if (transform.position.x > maxMovement)
                {
                    transform.position = new Vector2(0,0);
                }
            
                break;
            }


        }

    }
}
