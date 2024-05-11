


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{

	public List<BadUnit> badList = new List<BadUnit>();
	public List<GoodUnit> goodList = new List<GoodUnit>();



	public float time;

	public int Points;
	int damageRandomizer;
	int spawnRate = 7;
	float repeatRate = 2;
	// Start is called before the first frame update
	void Start()
	{
		time = Time.time;
		InvokeRepeating("SpawnEnemy", 1, repeatRate);
		InvokeRepeating("SpawnFriend", 1, 5);

	}

	// Update is called once per frame
	void Update()
	{
		if (Time.time - time > 30)
		{
			CancelInvoke("SpawnEnemy");
			InvokeRepeating("SpawnEnemy", 1, repeatRate - 0.3f);
			time = Time.time;
			spawnRate--;
		}
	}


	void SpawnEnemy()
	{
		BadUnit unit = badList[Random.Range(0, badList.Count - 1)];

		damageRandomizer = Random.Range(0, 11);
		var newUnit = Instantiate(unit, new Vector3(0, .45f, 22), unit.transform.rotation);

		if (damageRandomizer > spawnRate)
		{
			newUnit.gameObject.GetComponent<MeshRenderer>().material.color = Color.black;
			newUnit.gameObject.GetComponent<BadUnit>().dealsDamage = true;
		}


	}

	void SpawnFriend()
	{
		GoodUnit unit = goodList[Random.Range(0, goodList.Count - 1)];
		Instantiate(unit, new Vector3(Random.Range(-2f, 2f), .45f, 22), unit.transform.rotation);
	}
	public void ChangePoint(int points)
	{
		Points += points;
	}
}
