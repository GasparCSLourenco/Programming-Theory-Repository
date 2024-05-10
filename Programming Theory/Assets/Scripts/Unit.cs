using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
	public static float moveSpeed { get; set; }

	// Start is called before the first frame update
	void Start()
    {
		MovePlane movePlane = new();
		moveSpeed = movePlane.PlaneSpeed;
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public abstract void Move();
    
}
