using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BadUnit : Unit
{

	[SerializeField]
	private float strafeSpeed;

	float horizontalBound;
	[SerializeField]
	private float speedDiff;

	public int pointDiff;


	public BadUnit()
	{
		horizontalBound = 2.0f;

		pointDiff = -1000;
	}



	// Start is called before the first frame update
	void Start()
	{
		speedDiff = Random.Range(1.0f, 5.0f);
	}

	// Update is called once per frame
	void Update()
	{
		Move();
	}

	public override void Move()
	{
		if (transform.position.x > horizontalBound || transform.position.x < -horizontalBound)
		{
			strafeSpeed *= -1;
		}
		gameObject.transform.Translate(Time.deltaTime * strafeSpeed, 0, Time.deltaTime * (moveSpeed - speedDiff));
	}
}
