using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("GameManager")]
    [SerializeField] GameManagerSO GM;


    public List<GameObject> travelPoints = new List<GameObject>();
    public int currentTarget, newTarget;
    public int maxRange = 0;
    public float timeToMove = 5;
    bool hasReached = false;
    public bool reachedFirst = false;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        maxRange = travelPoints.Count;
    }

    
    void FixedUpdate()
    {

        if(!hasReached && !GM.isPause)
        {
            MoveTarget();
        }
        else
        {
            SelectTarget();
        }

        
    }

    void SelectTarget()
    {
        if(hasReached) 
        {
            newTarget = Random.Range(0, maxRange);
            if(newTarget == currentTarget)
            {
                return;
            }
            else
            {
                currentTarget = newTarget;
                hasReached = false;
            }
        }
        else
        {
            return;
        }
    }

    void  MoveTarget()
    {
        transform.position = Vector3.SmoothDamp(transform.position, travelPoints[currentTarget].transform.position,ref velocity, timeToMove);
        if(Vector3.Distance(transform.position, travelPoints[currentTarget].transform.position) <= 0.01)
        {
            if(!reachedFirst)
            {
                reachedFirst = true;
            }
            hasReached = true;
        }
    }
    
}
