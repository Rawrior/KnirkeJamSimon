using UnityEngine;

public class Camerascript : MonoBehaviour
{
    public float speed;
    public GameObject GamemasterExecutor;
    public GameObject PlayerObject;

    // Use this for initialization
    void Start ()
    {
        GamemasterExecutor = GameObject.Find("GameMaster");
        PlayerObject = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerObject!=null)
            transform.position = new Vector3(PlayerObject.transform.position.x, transform.position.y, transform.position.z);

        /*
        if (GamemasterExecutor.GetComponent<GamestateManager>().fadeInDone)
        {
            //Move left. Also make sure we can't move double speed.
            if (Input.GetKey(KeyCode.A)) MoveFunction(KeyCode.A, -speed);
            else if (Input.GetKey(KeyCode.LeftArrow)) MoveFunction(KeyCode.LeftArrow, -speed);
            //Move right. Chill out bruh, go slow :~)
            if (Input.GetKey(KeyCode.D)) MoveFunction(KeyCode.D, speed);
            else if (Input.GetKey(KeyCode.RightArrow)) MoveFunction(KeyCode.RightArrow, speed);
        }
        */
    }
    
    void MoveFunction(KeyCode key, float speed)
    {
        //Do the boogie~
        if (Input.GetKey(key))
            transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}
