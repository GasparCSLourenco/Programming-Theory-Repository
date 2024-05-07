using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadUnit : Unit
{
    [SerializeField]
	private float moveSpeed;
    [SerializeField]
    private float strafeSpeed;

    float horizontalBound = 2.0f;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public override void Move()
	{
		gameObject.transform.Translate(1*Time.deltaTime*strafeSpeed,0,strafeSpeed*Time.deltaTime*moveSpeed);
	}
}
