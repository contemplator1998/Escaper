using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatesController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == Provider.GetPlayer().gameObject.name)
        {
            Provider.GetController().onTryingFinish();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
