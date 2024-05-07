using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSystem : MonoBehaviour
{
    [SerializeField]
    private int points;


    public void ChangePoint(int points)
    {
        points += points;
    }
}
