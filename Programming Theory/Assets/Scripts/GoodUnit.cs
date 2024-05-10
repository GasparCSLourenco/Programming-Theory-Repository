using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodUnit : Unit
{

    public int pointDiff = 500;
    private float speedDiff = 3.5f;

	public override void Move()
	{
		throw new System.NotImplementedException();
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(0, 0, Time.deltaTime * (moveSpeed - speedDiff));
    }
}
