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
    }
    
    void MoveFunction(KeyCode key, float speed)
    {
        //Do the boogie~
        if (Input.GetKey(key))
            transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}
