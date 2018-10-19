using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternativeMove : MonoBehaviour {

	CharacterController characterController;

	public float speed = 1.0f;
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;
	private Vector3 startPosition;

	private Vector3 moveDirection = Vector3.zero;

	public void moveToStartPosition()
	{
		transform.position = startPosition;
	}

	void Start()
	{
		characterController = GetComponent<CharacterController>();
	}

	void Update()
	{
		var distance = Provider.GetCursor().transform.position - transform.position;
		if (distance.magnitude < 2.0F)
		{
			distance = new Vector3(0, 0, 0);
		}
		var normalized = Vector3.Normalize(distance);
		//distance = new Vector3 (Input.GetAxis ("Horizontal"), 0.0f, Input.GetAxis ("Vertical"));
		distance *= speed;
//			if (Input.GetButton("Jump"))
//			{
//				moveDirection.y = jumpSpeed;
//			}
		distance.y -= gravity;
		characterController.Move (distance / 400);
	}
}