using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GamemasterExecutor : MonoBehaviour
{
    public GameObject Canvas;
    public Text DisplayText;
    public GameObject playerObject;
    private readonly int[] counters = {0, 0, 0, 0, 0, 0};
    private readonly float[] timers = {0, 0, 0, 0, 0, 0};
    private readonly bool[] doneEvents = {false, false, false, false, false};

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
        if (GetComponent<GamestateManager>().fadeInDone && !doneEvents[0])
        {
            if (playerObject != null && !playerObject.GetComponent<PlayerMovement>().enabled)
                playerObject.GetComponent<PlayerMovement>().enabled = true;
            firstEvent();
        }
        else if (GetComponent<GamestateManager>().booksPickedUp.Count == 1 && !doneEvents[1])
        {
            secondEvent();
        }
        else if (GetComponent<GamestateManager>().booksPickedUp.Count == 1 && !doneEvents[2])
        {
            thirdEvent();
        }
        else if (GetComponent<GamestateManager>().seenHouse && !doneEvents[3])
        {
            fourthEvent();
        }
        else if (GetComponent<GamestateManager>().booksPickedUp.Count == 2 && !doneEvents[4])
        {
            fifthEvent();
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

        if (counters[1] == firstEventStrings.Length - 1)
            doneEvents[0] = true;
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

        if (GetComponent<GamestateManager>().booksPickedUp[0])
            doneEvents[1] = true;
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

        if (counters[3] == thirdEventStrings.Length - 1)
            doneEvents[2] = true;
    }

    void fourthEvent()
    {
        string[] fourthEventStrings ={
            "There. That house.",
            "A forbidden book is inside",
            "Go and take it.",
            "You are the authority. No one will stop you.",
            "It is your duty to take the book.",
            "Go inside and take it.",
            "Take it.",
            "Take it!",
            "Take it!!",
            "TAKE IT!"};

        if (counters[4] < fourthEventStrings.Length - 1)
            timers[4] += Time.deltaTime;

        if (timers[4] >= 2f && counters[4] < fourthEventStrings.Length - 1)
        {
            counters[4]++;
            timers[4] = 0;
        }

        updateUIText(fourthEventStrings[counters[4]]);

        if (GetComponent<GamestateManager>().booksPickedUp.Count == 2)
            doneEvents[3] = true;
    }

    void fifthEvent()
    {
        string[] fifthEventStrings ={
            "Excellent.",
            "Go burn this book as well.",
            ""};
        if (counters[5] < fifthEventStrings.Length - 1)
            timers[5] += Time.deltaTime;


        if (timers[5] >= 2f && counters[5] < fifthEventStrings.Length - 1)
        {
            counters[5]++;
            timers[5] = 0;
        }

        updateUIText(fifthEventStrings[counters[5]]);

        if (counters[5] == fifthEventStrings.Length - 1)
            doneEvents[4] = true;
    }
}
