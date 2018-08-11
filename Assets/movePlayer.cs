﻿using UnityEngine;
using System.Collections;

public class movePlayer : MonoBehaviour {

    public Rigidbody rb;

    private bool moving = true;
    GameObject cursor;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        cursor = GameObject.Find("Cursor");
	}
	
	// Update is called once per frame
    void Update()
    {
        if (moving)
        {
            var distance = cursor.transform.position - transform.position;
            if (distance.magnitude < 2.0F)
            {
                distance = new Vector3(0, 0, 0);
            }
            var normalized = Vector3.Normalize(distance);
            var delta = Vector3.Scale(normalized, new Vector3(1F, 1F));
            rb.AddForce(delta);
            var playerImage = GameObject.Find("player");
            if (delta.x != 0)
            {
                playerImage.GetComponent<SpriteRenderer>().flipX = delta.x > 0;
            }
        }
    }

    public void startMovingPlayer()
    {
        moving = true;
    }

    public void stopMovingPlayer()
    {
        Debug.Log("Stop");
        moving = false;
    }
}
