using UnityEngine;
using System.Collections;

public class GamemasterExecutor : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!GetComponent<GamestateManager>().fadeInDone)
            fadeHandler();
    }

    void fadeHandler()
    {
        if (Input.anyKeyDown)
        {
            GetComponentInChildren<FadeScript>().doFade = true;
        }

        if (transform.childCount == 0)
        {
            GetComponent<GamestateManager>().fadeInDone = true;
        }
    }
}
