using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyControl : SoundEnemy {

    bool initialized = false;
    Vector3 startPosition;
    Vector3 direction;
    public Rigidbody rb;
    float angle = 0;
	public float speed = 6.0f;
	public float gravity = 20.0f;
	CharacterController characterController;

    public void moveToStartPosition()
    {
        if (initialized)
        {
            rb.transform.localPosition = startPosition;
            Debug.Log("Became " + rb.transform.localPosition + " " + initialized);
        }
    }

    void setRandomDirection()
    {
        angle += Random.Range(-1.0F, 1.0F);
        direction = Vector3.Normalize(new Vector3(Mathf.Cos(angle), 0.0f, Mathf.Sin(angle))) * speed;
		Debug.Log ("lol");
    }
    void setRandomDirectionSlight()
    {
        angle += Random.Range(-0.05F, 0.05F);
		direction = Vector3.Normalize(new Vector3(Mathf.Cos(angle), 0.0f, Mathf.Sin(angle))) * speed;
    }

	// Use this for initialization
	void Start () {
        base.Start();
		characterController = GetComponent<CharacterController>();
        initialized = true;
        startPosition = rb.transform.localPosition;
        Debug.Log("Was " + startPosition);
        setRandomDirection();
	}

	// Update is called once per frame
    void Update()
    {
        base.Update();
        speed = 1.0F + Provider.GetLightController().getLightSpeed() * 2.0F;
        setRandomDirectionSlight();
		direction.y -= gravity * Time.deltaTime;
		characterController.Move(direction * Time.deltaTime);
    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.name == Provider.GetPlayer().name)
        {
            Provider.GetController().onKilled(gameObject);
        }
		if (col.gameObject.name == "cube")
		{
			setRandomDirection();
		}
		Debug.Log (col.gameObject.name);
    }
}
