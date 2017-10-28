using UnityEngine;
using System.Collections;

public class HousetriggerScript : MonoBehaviour
{
    public GameObject GamestateManager;

    void Start()
    {
        GamestateManager = GameObject.Find("GameMaster");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            GamestateManager.GetComponent<GamestateManager>().seenHouse = true;

    }
}
