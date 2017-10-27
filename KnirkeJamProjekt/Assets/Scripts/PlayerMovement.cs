using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
        //Move left
        MoveFunction(KeyCode.A, -5);
        MoveFunction(KeyCode.LeftArrow, -5);
        //Move right
        MoveFunction(KeyCode.D, 5);
        MoveFunction(KeyCode.RightArrow, 5);
    }

    void MoveFunction(KeyCode key, float speed)
    {
        //Do the boogie~
        if (Input.GetKey(key))
            transform.Translate(speed, 0, 0);
    }
}
