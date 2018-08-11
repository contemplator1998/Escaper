﻿using UnityEngine;
using System.Collections;

public class moveCursor : MonoBehaviour {


     // Use this for initialization
     void Start () {
     
     }
     
     // Update is called once per frame
     void Update () {
		Debug.Log (Input.mousePosition.x);
         var distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
         var pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
         transform.position = new Vector3(pos_move.x, pos_move.y, 0);
     }
}
