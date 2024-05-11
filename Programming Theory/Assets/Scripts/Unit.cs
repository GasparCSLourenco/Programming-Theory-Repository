using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
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
        DeSpawn();
    }

	public abstract void Move();

	public virtual void DeSpawn()
	{
		if (transform.position.z < -10)
		{
			Destroy(gameObject);
		}
	}
    
}
