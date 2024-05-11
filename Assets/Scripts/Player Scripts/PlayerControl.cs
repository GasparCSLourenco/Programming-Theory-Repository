using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerControl : MonoBehaviour
{
	private PlayerControls playerControls;
	private CharacterController controller;
	private Vector3 playerVelocity;
	private bool groundedPlayer;
	[SerializeField]
	private float playerSpeed = 2.0f;
	private float gravityValue = -9.81f;
	float direction = 0;
	private float horizontalBound = 2.0f;

	public GameManager gameManager;
	public int PlayerLives { get; private set; } = 3;


	private void Awake()
	{
		controller = gameObject.GetComponent<CharacterController>();
		playerControls = new PlayerControls();

	}

	void OnEnable()
	{
		playerControls?.Enable();
	}

	private void OnDisable()
	{
		playerControls?.Disable();
	}

	void Update()
	{
		MovePlayer(); //Abstraction 
		Spin();
		BoundMovement();

	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Enemy"))
		{
			gameManager.ChangePoint(other.GetComponent<BadUnit>().pointDiff);
			Destroy(other.gameObject);

			if (other.GetComponent<BadUnit>().dealsDamage)
			{
				gameManager.GetComponent<LivesUI>().RemoveLife();
				PlayerLives--;
				SoundHandler soundHandler = gameManager.GetComponent<SoundHandler>();

				soundHandler.PlayDmgSound();
			}
		}
		else if (other.CompareTag("Friend"))
		{
			gameManager.ChangePoint(other.GetComponent<GoodUnit>().pointDiff);
			Destroy(other.gameObject);

			SoundHandler soundHandler = gameManager.GetComponent<SoundHandler>();

			soundHandler.PlayPointPickupSound();
		}
	}

	private void MovePlayer()
	{
		groundedPlayer = controller.isGrounded;
		if (groundedPlayer && playerVelocity.y < 0)
		{
			playerVelocity.y = 0f;
		}

		Vector3 move = new Vector3(playerControls.Player.Movement.ReadValue<Vector2>().x, 0, playerControls.Player.Movement.ReadValue<Vector2>().y);

		controller.Move(move * Time.deltaTime * playerSpeed);

		if (move != Vector3.zero)
		{
			gameObject.transform.forward = move;
		}

		playerVelocity.y += gravityValue * Time.deltaTime;
	}

	void Spin()
	{
		if (playerControls.Player.Movement.ReadValue<Vector2>().x != 0)
		{
			direction = playerControls.Player.Movement.ReadValue<Vector2>().x; //Reads the x value of player movement. Left -> x<0 | Right -> x>0
		}

		gameObject.transform.Rotate(0, 0, 5 * direction); //Change direction of spin based on player rotation
	}

	void BoundMovement()
	{
		if (transform.position.x > horizontalBound)
		{
			transform.position = new(horizontalBound, transform.position.y, transform.position.z);
		}
		else if (transform.position.x < -horizontalBound)
		{
			transform.position = new(-horizontalBound, transform.position.y, transform.position.z);
		}
	}
}
