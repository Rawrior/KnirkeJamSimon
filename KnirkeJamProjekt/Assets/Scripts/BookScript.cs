using UnityEngine;
using System.Collections;

public class BookScript : MonoBehaviour
{
    public GameObject GamestateManager;
    public int thisBookNumber;

    void Start()
    {
        GamestateManager = GameObject.Find("GameMaster");
        thisBookNumber = GamestateManager.GetComponent<GamestateManager>().booksPickedUp.Count;
    }

    public void addBook()
    {
        if (GamestateManager.GetComponent<GamestateManager>().booksPickedUp.Count - 1 != thisBookNumber)
        {
            GamestateManager.GetComponent<GamestateManager>().booksPickedUp.Add(true);
            transform.name = transform.name + thisBookNumber;
        }
    }

}
