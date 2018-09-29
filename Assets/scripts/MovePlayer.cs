using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {

	public float MoveSpeed = 1;

    private Light lamp;
    public Rigidbody body;
    private SpriteRenderer sprite;
    private Vector3 startPosition;

    private float startLightX;
    private bool moving = true;

    public void moveToStartPosition()
    {
        transform.position = startPosition;
    }

	void Start () {
        startPosition = transform.position;
        body = GetComponent<Rigidbody>();
        lamp = GetComponentInChildren<Light>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        startLightX = Mathf.Abs(transform.position.x - lamp.transform.position.x);
	}

    void Update()
    {
        if (moving)
        {
            var distance = Provider.GetCursor().transform.position - transform.position + new Vector3(0, 2.5F, 0);
            if (distance.magnitude < 2.0F)
            {
                distance = new Vector3(0, 0, 0);
            }
            var normalized = Vector3.Normalize(distance);
            var delta = Vector3.Scale(normalized, new Vector3(1F, 1F));
            body.AddForce(delta * MoveSpeed);
            if (delta.x != 0)
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
