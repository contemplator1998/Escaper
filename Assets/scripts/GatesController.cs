using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
			SceneManager.LoadScene("MainScene");
			// tam kogda novaya scena zagruzaetsya слетают все ссылки в префабах походу
			//Debug.Log (Provider.getGeneralController ());
			//Provider.getGeneralController().onTryingFinish();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
