using UnityEngine;
using UnityEngine.UI;

public class GamemasterExecutor : MonoBehaviour
{
    public GameObject Canvas;
    public Text DisplayText;
    public GameObject playerObject;
    private int a;
    private int b;
    private float time1;
    private float time2;

    // Use this for initialization
    void Start ()
	{
	    Canvas = GameObject.Find("Canvas");
	    DisplayText = Canvas.GetComponentInChildren<Text>();
	    updateUIText("");

        playerObject = GameObject.Find("Player");

	    a = 0;
	    time1 = 0;
	}
	
	// Update is called once per frame
    void Update()
    {
        //Fade on first input
        if (!GetComponent<GamestateManager>().fadeInDone)
            fadeHandler();

        //Let the player do shit. Also introduce yourself
        if (GetComponent<GamestateManager>().fadeInDone)
        {
            if (playerObject != null && !playerObject.GetComponent<PlayerMovement>().enabled)
                playerObject.GetComponent<PlayerMovement>().enabled = true;
            firstEvent();
        }

        if (playerObject == null)
        {
            loseEvent();
        }
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

    void loseEvent()
    {
        string[] loseEventStrings ={
            "Oh.",
            "Couldn't take the pressure?",
            "Ah well.",
            "You can't escape your sins."};

        if (b < loseEventStrings.Length - 1)
            time2 += Time.deltaTime;

        if (time2 >= 3f && b < loseEventStrings.Length - 1)
        {
            b++;
            time2 = 0;
        }

        updateUIText(loseEventStrings[b]);
    }

    void firstEvent()
    {
        string[] firstEventStrings ={
            "",
            "Ah, welcome back.",
            "You remember your purpose, of course.",
            "Go pick up that book."};

        if (a < firstEventStrings.Length-1)
            time1 += Time.deltaTime;

        if (time1 >= 3f && a < firstEventStrings.Length-1)
        {
            a++;
            time1 = 0;
        }

        updateUIText(firstEventStrings[a]);
    }


}
