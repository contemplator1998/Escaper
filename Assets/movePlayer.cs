using UnityEngine;
using System.Collections;

public class movePlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        var cursor = GameObject.Find("Cursor");
        var normalized = Vector3.Normalize(cursor.transform.position - transform.position);
        var delta = Vector3.Scale(normalized, new Vector3(0.1F, 0.1F));
        transform.position += delta;

	}
}
