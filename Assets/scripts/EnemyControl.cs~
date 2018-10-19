using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class EnemyControl : SoundEnemy {

    bool initialized = false;
    Vector3 startPosition;
	Vector3 direction = new Vector3(0.0f, 0.0f, 0.0f);
    public Rigidbody rb;
    float angle = 0;
	public float speednpc = 0.15f;
	public float gravity = 0.0f;
	CharacterController characterController;

    public void moveToStartPosition()
    {
        if (initialized)
        {
            rb.transform.localPosition = startPosition;
            Debug.Log("Became " + rb.transform.localPosition + " " + initialized);
        }
    }

	IEnumerator setRandomDirection()
    {
		yield return new WaitForSeconds(0.2f);
        angle += Random.Range(-2.0F, 2.0F);
        direction = Vector3.Normalize(new Vector3(Mathf.Cos(angle), 0.0f, Mathf.Sin(angle)));
		//Debug.Log (direction.x);
		StartCoroutine(setRandomDirection());
    }
    void setRandomDirectionSlight()
    {
        angle += Random.Range(-0.05F, 0.05F);
		direction = Vector3.Normalize(new Vector3(Mathf.Cos(angle), 0.0f, Mathf.Sin(angle)));
    }

	// Use this for initialization
	void Start () {
        base.Start();
		characterController = GetComponent<CharacterController>();
        initialized = true;
        startPosition = rb.transform.localPosition;
        Debug.Log("Was " + startPosition);
		StartCoroutine(setRandomDirection());
	}

	// Update is called once per frame
    void Update()
    {
        base.Update();
        setRandomDirectionSlight();
		direction.y -= gravity * Time.deltaTime;
		Debug.Log (speednpc*(0.8F - Provider.GetLightController().getLightSpeed() * 0.6F));
		characterController.Move(direction*speednpc*(1.0F - Provider.GetLightController().getLightSpeed() * 0.7F));
    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.name == Provider.GetPlayer().name)
        {
            Provider.GetController().onKilled(gameObject);
        }
    }
}
