using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public GameObject GamemasterExecutor;
    public GameObject PickUpObject;
    public int LayerMask;
    public float ThrowForce;
    public Vector2 throwingVector;

    // Use this for initialization
    void Start ()
	{
	    GamemasterExecutor = GameObject.Find("GameMaster");
	    LayerMask = 256;
	    throwingVector = new Vector2(0, 0);
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

        //Check if the use key is pressed. Space only, tho
        if (Input.GetKeyDown(KeyCode.Space))
            UseFunction(LayerMask, ThrowForce);

	    if (PickUpObject != null)
	        PickUpObject.transform.position = transform.position + Vector3.up * 1.8f;
    }

    void MoveFunction(float speed)
    {
        //Do the boogie~
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    void UseFunction(int mask, float force)
    {
        //Check which direction to throw
        if (GamemasterExecutor.GetComponent<GamestateManager>().movedRight)
        {
            throwingVector = new Vector2(ThrowForce, ThrowForce*1.5f);
            Debug.Log("ThrowVector: " + throwingVector);
        }
        else
        { 
            throwingVector = new Vector2(-ThrowForce, ThrowForce*1.5f);
            Debug.Log("ThrowVector: " + throwingVector);
        }

        //Do the throwing
        if (PickUpObject != null)
        {
            PickUpObject.GetComponent<Rigidbody2D>().isKinematic = false;
            PickUpObject.GetComponent<Rigidbody2D>().velocity = throwingVector;
            PickUpObject = null;
        }
        //do the picking up
        else if (PickUpObject == null && Physics2D.OverlapCircle(transform.position, 2, mask) != null)
        {
            PickUpObject = Physics2D.OverlapCircle(transform.position, 2, mask).gameObject;

        }
    }
}
