using UnityEngine;
using System.Collections;

public class MoveCursor : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
        var distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        var pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
        transform.position = new Vector3(pos_move.x, pos_move.y, 0);
    }
}
