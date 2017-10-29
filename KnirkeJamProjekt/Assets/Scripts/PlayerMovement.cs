using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public GameObject GamemasterExecutor;


    // Use this for initialization
    void Start ()
	{
	    GamemasterExecutor = GameObject.Find("GameMaster");

    }
	
	// Update is called once per frame
	void Update ()
	{
        
        //Move left. Also make sure we can't move double speed.
	    if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            MoveFunction(-speed);
            GamemasterExecutor.GetComponent<GamestateManager>().movedLeft = true;
            GamemasterExecutor.GetComponent<GamestateManager>().movedRight = false;
        }

        //Move right. Chill out bruh, go slow :~)
	    if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
	    {
	        MoveFunction(speed);
	        GamemasterExecutor.GetComponent<GamestateManager>().movedRight = true;
	        GamemasterExecutor.GetComponent<GamestateManager>().movedLeft = false;
	    }
    }

    void MoveFunction(float speed)
    {
        //Do the boogie~
        //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed, 0), ForceMode2D.Force);
        transform.Translate(new Vector3(speed, 0, 0)*Time.deltaTime, Space.World);
    }
}
