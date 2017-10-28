using UnityEngine;
using UnityEngine.UI;

public class GamemasterExecutor : MonoBehaviour
{
    public GameObject Canvas;
    public Text DisplayText;
    public GameObject playerObject;
    private int i;
    private float time;

    // Use this for initialization
    void Start ()
	{
	    Canvas = GameObject.Find("Canvas");
	    DisplayText = Canvas.GetComponentInChildren<Text>();
	    updateUIText("");

        playerObject = GameObject.Find("Player");

	    i = 0;
	    time = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Fade on first input
        if (!GetComponent<GamestateManager>().fadeInDone)
            fadeHandler();
        
        //Let the player do shit. Also introduce yourself
        if (GetComponent<GamestateManager>().fadeInDone)
            {firstEvent(); playerObject.GetComponent<PlayerMovement>().enabled = true;}
    }

    void updateUIText(string text)
    {
        DisplayText.text = text;
    }

    void fadeHandler()
    {
        if (Input.anyKeyDown)
            GetComponentInChildren<FadeScript>().doFade = true;

        if (transform.childCount == 0)
            GetComponent<GamestateManager>().fadeInDone = true;
    }

    void firstEvent()
    {
        string[] firstEventStrings ={
            "",
            "Ah, welcome back.",
            "You remember your purpose, of course.",
            "Go pick up that book."};

        if (i < firstEventStrings.Length-1)
            time += Time.deltaTime;

        if (time >= 3f && i < firstEventStrings.Length-1)
        {
            i++;
            time = 0;
        }

        updateUIText(firstEventStrings[i]);
    }


}
