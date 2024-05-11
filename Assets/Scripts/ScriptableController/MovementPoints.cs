using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "MovementList", menuName = "Assets/MovementList", order = 1)]
public class MovementPoints : ScriptableObject
{
    public List<GameObject> movePoints = new List<GameObject>();
}
