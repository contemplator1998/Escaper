using UnityEngine;
using System.Collections;

public class movePlayer : MonoBehaviour {

    public Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
    void Update()
    {
        var cursor = GameObject.Find("Cursor");
        var distance = cursor.transform.position - transform.position;
        if (distance.magnitude < 1)
        {
            distance = new Vector3(0, 0, 0);
        }
        var normalized = Vector3.Normalize(distance);

        var delta = Vector3.Scale(normalized, new Vector3(1F, 1F));
        rb.AddForce(delta);
    }
}
