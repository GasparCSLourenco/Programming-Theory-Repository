using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
	public static float moveSpeed { get; set; } //Encapsulation
	protected static float horizontalBound = 2f;

	public float HorizontalBound => horizontalBound;

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

	public abstract void Despawn();

}
