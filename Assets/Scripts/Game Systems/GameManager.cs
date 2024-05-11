using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{

	public List<BadUnit> badList = new List<BadUnit>();
	public List<GoodUnit> goodList = new List<GoodUnit>();

	private string playerName;

	public float time;

	public int Points {get; private set;}
	int damageRandomizer;
	int spawnRate = 7;
	float repeatRate = 2;

	public PlayerControl player;


	// Start is called before the first frame update
	void Start()
	{
		time = Time.time;
		InvokeRepeating("SpawnEnemy", 1, repeatRate);
		InvokeRepeating("SpawnFriend", 1, 5);
		playerName = MenuHandler.Instance.playerName;
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
		GameOver();
	}


	void SpawnEnemy()
	{
		BadUnit unit = badList[Random.Range(0, badList.Count - 1)];

		damageRandomizer = Random.Range(0, 11);
		float xPosition = Random.Range(unit.HorizontalBound, unit.HorizontalBound);

		var newUnit = Instantiate(unit, new Vector3(xPosition, .45f, 22), unit.transform.rotation);

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


	void GameOver()
	{
		if (player.PlayerLives <= 0)
		{
			SoundHandler soundHandler = GetComponent<SoundHandler>();
			soundHandler.PlayDeathSound();
			MenuHandler.Instance.SaveHighScore(playerName,Points);
			SceneManager.LoadScene(0);
		}
	}
}
