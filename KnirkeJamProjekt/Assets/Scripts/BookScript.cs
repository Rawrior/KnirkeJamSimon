using UnityEngine;
using System.Collections;

public class BookScript : MonoBehaviour
{
    public GameObject GamestateManager;
    public GameObject SceneManager;
    public int thisBookNumber;

    void Start()
    {
        GamestateManager = GameObject.Find("GameMaster");
        SceneManager = GameObject.Find("SceneManager");
        thisBookNumber = GamestateManager.GetComponent<GamestateManager>().booksPickedUp.Count;
    }

    public void addBook()
    {
        if (GamestateManager.GetComponent<GamestateManager>().booksPickedUp.Count - 1 != thisBookNumber)
        {
            GamestateManager.GetComponent<GamestateManager>().booksPickedUp.Add(false);
            transform.name = transform.name + thisBookNumber;
        }
    }

    void OnDestroy()
    {
        GamestateManager.GetComponent<GamestateManager>().booksPickedUp[0] = true;

        if (GamestateManager.GetComponent<GamestateManager>().booksPickedUp.Count == 1)
            SceneManager.GetComponent<ScenemanagerScript>().spawnActTwo();
        else if (GamestateManager.GetComponent<GamestateManager>().booksPickedUp.Count == 2)
            SceneManager.GetComponent<ScenemanagerScript>().spawnActThree();
    }
}
