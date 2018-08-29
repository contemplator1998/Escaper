using UnityEngine;
using System.Collections;

public class EnemyControl : SoundEnemy {

    bool initialized = false;
    Vector3 startPosition;
    Vector3 direction;
    public Rigidbody rb;
    float angle = 0;
	float speed = 1.5F;

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
        direction = Vector3.Normalize(new Vector3(Mathf.Cos(angle), Mathf.Sin(angle))) * speed;
    }
    void setRandomDirectionSlight()
    {
        angle += Random.Range(-0.2F, 0.2F);
		direction = Vector3.Normalize(new Vector3(Mathf.Cos(angle), Mathf.Sin(angle))) * speed;
    }

	// Use this for initialization
	void Start () {
        base.Start();
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
        rb.AddForce(direction);
    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.name == Provider.GetPlayer().name)
        {
            Provider.GetController().onKilled(gameObject);
        }
        setRandomDirection();
    }
}
