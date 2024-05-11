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
	[SerializeField]
	public bool dealsDamage { get; set;}


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
		Despawn();
	}

	public override void Move()
	{
		if (transform.position.x > horizontalBound)
		{
			strafeSpeed *= -1;
			transform.position = new Vector3(horizontalBound,transform.position.y,transform.position.z);
		}
		else if(transform.position.x < -horizontalBound)
		{
			strafeSpeed *= -1;
			transform.position = new Vector3(-horizontalBound, transform.position.y, transform.position.z);
		}

		gameObject.transform.Translate(Time.deltaTime * strafeSpeed, 0, Time.deltaTime * (moveSpeed - speedDiff));

	}

	public override void Despawn()
	{
		if (transform.position.z < -5)
		{
			Destroy(gameObject);
		}
	}
}
