﻿using UnityEngine;
using System.Collections;

public class MoveCursor : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
		transform.position = new Vector3(Provider.GetPlayer().transform.position.x + (Input.mousePosition.x - 960)/50, Provider.GetPlayer().transform.position.y - 2, Provider.GetPlayer().transform.position.z + (Input.mousePosition.y - 540)/50);
    }
}