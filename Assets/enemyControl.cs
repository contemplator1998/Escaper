using UnityEngine;
using System.Collections;

public class enemyControl : MonoBehaviour {

    Vector3 direction;
    public Rigidbody rb;
    float angle = 0;

    void setRandomDirection()
    {
        angle += Random.Range(-1.0F, 1.0F);
        direction = Vector3.Normalize(new Vector3(Mathf.Cos(angle), Mathf.Sin(angle))) * 2.0F;
        rb = GetComponent<Rigidbody>();
    }
    void setRandomDirectionSlight()
    {
        angle += Random.Range(-0.2F, 0.2F);
        direction = Vector3.Normalize(new Vector3(Mathf.Cos(angle), Mathf.Sin(angle))) * 2.0F;
        rb = GetComponent<Rigidbody>();
    }

	// Use this for initialization
	void Start () {
        setRandomDirection();
	}
	
	// Update is called once per frame
    void Update()
    {
        setRandomDirectionSlight();
        rb.AddForce(direction);
    }

    void OnCollisionStay(Collision col)
    {
        setRandomDirection();
    }
}
