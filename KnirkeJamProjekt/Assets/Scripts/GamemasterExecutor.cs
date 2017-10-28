using UnityEngine;
using UnityEngine.UI;

public class GamemasterExecutor : MonoBehaviour
{
    public GameObject Canvas;
    public Text DisplayText;
    public GameObject playerObject;
    private readonly int[] counters = {0, 0, 0, 0, 0};
    private readonly float[] timers = {0, 0, 0, 0, 0};

    // Use this for initialization
    void Start ()
	{
	    Canvas = GameObject.Find("Canvas");
	    DisplayText = Canvas.GetComponentInChildren<Text>();
	    updateUIText("");

        playerObject = GameObject.Find("Player");
	}
	
	// Update is called once per frame
    void Update()
    {
        //Fade on first input
        if (!GetComponent<GamestateManager>().fadeInDone)
            fadeHandler();

        //Let the player do shit. Also introduce yourself
        //FUCKING DISGUSTING CHAIN OF EVENTS, BLUUUUUURRRRGGGGHHHH
        if (GetComponent<GamestateManager>().fadeInDone && GetComponent<GamestateManager>().booksPickedUp.Count == 0)
        {
            if (playerObject != null && !playerObject.GetComponent<PlayerMovement>().enabled)
                playerObject.GetComponent<PlayerMovement>().enabled = true;
            firstEvent();
        }
        else if (GetComponent<GamestateManager>().booksPickedUp.Count == 1 && !GetComponent<GamestateManager>().booksPickedUp[0])
        {
            secondEvent();
        }
        else if (GetComponent<GamestateManager>().booksPickedUp.Count == 1 && GetComponent<GamestateManager>().booksPickedUp[0])
        {
            thirdEvent();
        }
        else if (GetComponent<GamestateManager>().booksPickedUp.Count == 1 && GetComponent<GamestateManager>().seenHouse)
        {
            fourthEvent();
        }
        ////Just keep adding more as necessary
        //else if (GetComponent<GamestateManager>().booksPickedUp.Count == 1)
        //{

        //}

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

        if (counters[0] < loseEventStrings.Length - 1)
            timers[0] += Time.deltaTime;

        if (timers[0] >= 2f && counters[0] < loseEventStrings.Length - 1)
        {
            counters[0]++;
            timers[0] = 0;
        }

        updateUIText(loseEventStrings[counters[0]]);
    }

    //Just copy this for however many you gotta dooooo
    void firstEvent()
    {
        string[] firstEventStrings ={
            "",
            "Ah, welcome back.",
            "You remember your purpose, of course.",
            "Go pick up that book."};

        if (counters[1] < firstEventStrings.Length-1)
            timers[1] += Time.deltaTime;

        if (timers[1] >= 2f && counters[1] < firstEventStrings.Length-1)
        {
            counters[1]++;
            timers[1] = 0;
        }

        updateUIText(firstEventStrings[counters[1]]);
    }

    void secondEvent()
    {
        string[] secondEventStrings ={
            "Good.",
            "Now go back and throw it in the fire.",
            "It contains forbidden material."};

        if (counters[2] < secondEventStrings.Length - 1)
            timers[2] += Time.deltaTime;

        if (timers[2] >= 2f && counters[2] < secondEventStrings.Length - 1)
        {
            counters[2]++;
            timers[2] = 0;
        }

        updateUIText(secondEventStrings[counters[2]]);
    }

    void thirdEvent()
    {
        string[] thirdEventStrings ={
            "Very good.",
            "There are still more forbidden books.",
            "Go find them. They must all be burned.",
            ""};

        if (counters[3] < thirdEventStrings.Length - 1)
            timers[3] += Time.deltaTime;

        if (timers[3] >= 2f && counters[3] < thirdEventStrings.Length - 1)
        {
            counters[3]++;
            timers[3] = 0;
        }

        updateUIText(thirdEventStrings[counters[3]]);
    }

    void fourthEvent()
    {
        string[] fourthEventStrings ={
            "Very good.",
            "There are still more forbidden books.",
            "Go find them. They must all be burned.",
            ""};

        if (counters[4] < fourthEventStrings.Length - 1)
            timers[4] += Time.deltaTime;

        if (timers[4] >= 2f && counters[4] < fourthEventStrings.Length - 1)
        {
            counters[4]++;
            timers[4] = 0;
        }

        updateUIText(fourthEventStrings[counters[4]]);
    }
}
