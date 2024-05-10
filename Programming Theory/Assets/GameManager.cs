using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public List<BadUnit> badList = new List<BadUnit>();
    public List<GoodUnit> goodList = new List<GoodUnit>();



	public int Points;

	// Start is called before the first frame update
	void Start()
    {
		InvokeRepeating("SpawnEnemy", 1, 3);
		InvokeRepeating("SpawnFriend", 1, 3);

	}

	// Update is called once per frame
	void Update()
    {
    }


    void SpawnEnemy()
    { 
        BadUnit unit = badList[Random.Range(0,badList.Count-1)];

        Instantiate(unit, new Vector3(0, .45f, 22), unit.transform.rotation);
    }

    void SpawnFriend()
    {
        GoodUnit unit = goodList[Random.Range(0,goodList.Count-1)];
		Instantiate(unit, new Vector3(Random.Range(-2f,2f), .45f, 22), unit.transform.rotation);
	}
	public void ChangePoint(int points)
	{
		Points += points;
	}
}
