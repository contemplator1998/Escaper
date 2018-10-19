using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternativeMove : MonoBehaviour {

	CharacterController characterController;

	public float speed = 1.0f;
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;
	private Vector3 startPosition;
	private bool moving = true;
	private SpriteRenderer sprite;
	private Light lamp;
	private float startLightX;
	private Vector3 moveDirection = Vector3.zero;


	public void moveToStartPosition()
	{
		transform.position = startPosition;
	}

	void Start()
	{
		lamp = GetComponentInChildren<Light>();
		sprite = GetComponentInChildren<SpriteRenderer>();
		startPosition = transform.position;
		characterController = GetComponent<CharacterController>();
		startLightX = Mathf.Abs(transform.position.x - lamp.transform.position.x);
	}

	void Update()
	{
		if (moving) {
			var distance = Provider.GetCursor ().transform.position - transform.position;
			if (distance.magnitude < 2.0F) {
				distance = new Vector3 (0, 0, 0);
			}
			//distance = new Vector3 (Input.GetAxis ("Horizontal"), 0.0f, Input.GetAxis ("Vertical"));
			distance *= speed;
//			if (Input.GetButton("Jump"))
//			{
//				moveDirection.y = jumpSpeed;
//			}
			distance.y -= gravity;
			characterController.Move (distance / 400);
			var delta = Vector3.Scale(Vector3.Normalize (distance), new Vector3(1F, 1F));
			if (delta.x < -0.2f || delta.x > 0.2f)
			{
				var dir = delta.x > 0;
				sprite.flipX = dir;
				lamp.transform.position = new Vector3(transform.position.x + startLightX * (dir ? 1.0F : -1.0F),
					lamp.transform.position.y, lamp.transform.position.z);
			}
		}
	}
	public void startMovingPlayer()
	{
		moving = true;
	}

	public void stopMovingPlayer()
	{
		moving = false;
	}
}