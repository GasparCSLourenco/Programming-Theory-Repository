using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerControl : MonoBehaviour
{
	private CharacterController controller;
	private Vector3 playerVelocity;
	private bool groundedPlayer;
	[SerializeField]
	private float playerSpeed = 2.0f;
	private float gravityValue = -9.81f;

	private PlayerControls playerControls;
	float direction = 0;
	private float horizontalBound = 2.0f;

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
			direction = playerControls.Player.Movement.ReadValue<Vector2>().x;
		}

		gameObject.transform.Rotate(0, 0, 5 * direction);
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