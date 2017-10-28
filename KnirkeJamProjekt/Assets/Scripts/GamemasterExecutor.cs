using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GamemasterExecutor : MonoBehaviour
{
    public GameObject Canvas;
    public Text DisplayText;

	// Use this for initialization
	void Start ()
	{
	    Canvas = GameObject.Find("Canvas");
	    DisplayText = Canvas.GetComponentInChildren<Text>();

	    DisplayText.text = "";
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
