using System;
using UnityEngine;
using System.Collections;

public class AdversaryTriggerScript : MonoBehaviour
{
    public GameObject GamestateManager;

    public byte alphaValue;

    void Start()
    {
        GamestateManager = GameObject.Find("GameMaster");
    }

    void Update()
    {
        alphaValue = Convert.ToByte(255 - GamestateManager.GetComponent<GamestateManager>().hitCounter * 85);
        GetComponent<Renderer>().material.color = new Color32(216, 42, 203, alphaValue);

        if (GetComponent<Renderer>().material.color.a == 0)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            GamestateManager.GetComponent<GamestateManager>().seenAdversary = true;
    }
}
