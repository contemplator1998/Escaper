using UnityEngine;
using System.Collections;

public class enemyControl : MonoBehaviour {

    Vector3 direction;
    public Rigidbody rb;
    float angle = 0;
	float speed = 1.5F;
	GameObject player;

    void setRandomDirection()
    {
        angle += Random.Range(-1.0F, 1.0F);
        direction = Vector3.Normalize(new Vector3(Mathf.Cos(angle), Mathf.Sin(angle))) * speed;
        rb = GetComponent<Rigidbody>();
    }
    void setRandomDirectionSlight()
    {
        angle += Random.Range(-0.2F, 0.2F);
		direction = Vector3.Normalize(new Vector3(Mathf.Cos(angle), Mathf.Sin(angle))) * speed;
    }

	// Use this for initialization
	void Start () {
        setRandomDirection();
		player = GameObject.Find ("Player");
	}

	// Update is called once per frame
    void Update()
    {
		if (Vector3.Magnitude (transform.position - player.transform.position) < 5.0F) {
			player.GetComponent<lightController> ().IncreaseHp ();
		}
		speed = 1.0F + player.GetComponent<lightController> ().getLightSpeed () * 2.0F;
        setRandomDirectionSlight();
        rb.AddForce(direction);
        if (direction.x != 0)
        {
            GetComponentInChildren<SpriteRenderer>().flipX = direction.x > 0;
        }
    }

    void OnCollisionStay(Collision col)
    {
        setRandomDirection();
    }
}
