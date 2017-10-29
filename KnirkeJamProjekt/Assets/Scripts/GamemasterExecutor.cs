using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GamemasterExecutor : MonoBehaviour
{
    public GameObject Canvas;
    public Text DisplayText;
    public GameObject playerObject;
    private readonly int[] counters = {0, 0, 0, 0, 0, 0, 0, 0, 0};
    private readonly float[] timers = {0, 0, 0, 0, 0, 0, 0, 0, 0};
    private readonly bool[] doneEvents = {false, false, false, false, false, false, false, false};

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
        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();

        //Fade on first input
        if (!GetComponent<GamestateManager>().fadeInDone)
            fadeHandler();

        if (playerObject == null)
        {
            loseEvent();
        }
        else
        {
            //Let the player do shit. Also introduce yourself
            //FUCKING DISGUSTING CHAIN OF EVENTS, BLUUUUUURRRRGGGGHHHH
            if (!doneEvents[0] && GetComponent<GamestateManager>().fadeInDone)
            {
                if (playerObject != null && !playerObject.GetComponent<PlayerMovement>().enabled)
                    playerObject.GetComponent<PlayerMovement>().enabled = true;
                firstEvent();
            }
            else if (!doneEvents[1] && GetComponent<GamestateManager>().booksPickedUp.Count == 1)
            {
                secondEvent();
            }
            else if (!doneEvents[2] && GetComponent<GamestateManager>().booksPickedUp.Count == 1)
            {
                thirdEvent();
            }
            else if (!doneEvents[3] && GetComponent<GamestateManager>().seenHouse)
            {
                fourthEvent();
            }
            else if (!doneEvents[4] && GetComponent<GamestateManager>().booksPickedUp.Count == 2)
            {
                fifthEvent();
            }
            else if (!doneEvents[5] && GetComponent<GamestateManager>().booksPickedUp.Count == 2)
            {
                sixthEvent();
            }
            else if (!doneEvents[6] && GetComponent<GamestateManager>().seenAdversary)
            {
                seventhEvent();
            }
            else if (!doneEvents[7] && GetComponent<GamestateManager>().booksPickedUp[2])
            {
                eightthEvent();
            }
        }

        if (doneEvents[7] && Input.anyKey)
            Application.Quit();
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

        timers[0] += Time.deltaTime;

        if (timers[0] >= 2f && counters[0] < loseEventStrings.Length - 1)
        {
            counters[0]++;
            timers[0] = 0;
        }

        updateUIText(loseEventStrings[counters[0]]);

        if (counters[0] >= loseEventStrings.Length - 1 && Input.anyKey && timers[0] >= 2f)
            Application.Quit();
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

        if (GetComponent<GamestateManager>().booksPickedUp[1])
            doneEvents[4] = true;
    }

    void sixthEvent()
    {
        string[] sixthEventStrings ={
            "Just one more book for the day.",
            "A criminal has it.",
            "They will try to defend the book.",
            "Do not be dissuaded.",
            "You will simply need to convince them to hand it over."};

        if (counters[6] < sixthEventStrings.Length - 1)
            timers[6] += Time.deltaTime;


        if (timers[6] >= 2f && counters[6] < sixthEventStrings.Length - 1)
        {
            counters[6]++;
            timers[6] = 0;
        }

        updateUIText(sixthEventStrings[counters[6]]);

        if (counters[6] == sixthEventStrings.Length - 1)
            doneEvents[5] = true;
    }

    void seventhEvent()
    {
        bool firstDone = false;
        string[] seventhEventFirstStrings ={
            "There.",
            "Go on. Take their book.",
            "Do it. Hit them if you must."};

        string[] seventEventSecondStrings = {
            "Hit them.",
            "Hit them!",
            "HIT THEM",
            "Well done. Go and burn the book."
        };

        timers[7] += Time.deltaTime;

        if (timers[7] >= 2f && counters[7] < seventhEventFirstStrings.Length - 1)
        {
            counters[7]++;
            timers[7] = 0;
        }

        updateUIText(seventhEventFirstStrings[counters[7]]);

        if (counters[7] == seventhEventFirstStrings.Length - 1 && timers[7] >= 2f)
            firstDone = true;

        if (firstDone /*&& GetComponent<GamestateManager>().hitCounter != 0*/)
        {
            updateUIText(seventEventSecondStrings[GetComponent<GamestateManager>().hitCounter]);

            if (GetComponent<GamestateManager>().hitCounter == 3)
                doneEvents[6] = true;
        }
    }

    void eightthEvent()
    {
        bool firstDone = false;
        string[] eightthEventStrings ={
            "Well done.",
            "We are done for now",
            "Did you enjoy it?",
            "You could have ended it at any time, you know.",
            "At least then I'd know you were weak.",
            "Goodbye now. Think on what you've done."};

       timers[8] += Time.deltaTime;


        if (timers[8] >= 2f && counters[8] < eightthEventStrings.Length - 1)
        {
            counters[8]++;
            timers[8] = 0;
        }

        updateUIText(eightthEventStrings[counters[8]]);

        if (counters[8] == eightthEventStrings.Length - 1 && timers[8] >= 2f)
            doneEvents[7] = true;
    }
}
