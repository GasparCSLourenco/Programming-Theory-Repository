using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlane : MonoBehaviour
{

    [SerializeField] private float planeSpeed = 3.0f;

    public float PlaneSpeed => planeSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.Translate(0,0,-1*Time.deltaTime*planeSpeed);
        ResetPlanePosition();
    }

    void ResetPlanePosition()
    {
        if (gameObject.transform.position.z <= -30.0f)
        {
            gameObject.transform.position = new Vector3 (0,0, 120);
        }
    }


}
