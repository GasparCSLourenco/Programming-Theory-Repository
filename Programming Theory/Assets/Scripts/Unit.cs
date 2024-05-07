using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [SerializeField]
    private int pointDiff;
    public GameObject pointManager;

    // Start is called before the first frame update
    void Start()
    {
        pointManager = GameObject.Find("Point Manager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.name== "Player") 
        {
            pointManager.GetComponent<PointSystem>().ChangePoint(pointDiff);
        }
	}

    public abstract void Move();
    
}
