using UnityEngine;
using System.Collections;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject GamemasterExecutor;
    public GameObject PickUpObject;
    public BookScript OtherBookScript;
    public int LayerMask1;
    public int LayerMask2;
    public float ThrowForce;
    public Vector2 throwingVector;

    // Use this for initialization
    void Start ()
    {
        LayerMask1 = 256;
        LayerMask2 = 1024;
        throwingVector = new Vector2(0, 0);
        GamemasterExecutor = GameObject.Find("GameMaster");
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Check if the use key is pressed. Space only, tho
        if (Input.GetKeyDown(KeyCode.Space))
            UseFunction(LayerMask1, LayerMask2);

        if (PickUpObject != null)
            PickUpObject.transform.position = transform.position + Vector3.up * 1.8f;
    }

    void UseFunction(int mask1, int mask2)
    {
        //Check which direction to throw
        if (GamemasterExecutor.GetComponent<GamestateManager>().movedRight)
        {
            throwingVector = new Vector2(ThrowForce, ThrowForce * 1.5f);
            //Debug.Log("ThrowVector: " + throwingVector);
        }
        else
        {
            throwingVector = new Vector2(-ThrowForce, ThrowForce * 1.5f);
            //Debug.Log("ThrowVector: " + throwingVector);
        }

        //Do the throwing
        if (PickUpObject != null)
        {
            PickUpObject.GetComponent<Rigidbody2D>().isKinematic = false;
            PickUpObject.GetComponent<Rigidbody2D>().velocity = throwingVector;
            PickUpObject = null;
        }
        else if (Physics2D.OverlapCircle(transform.position, 2, mask2))
        {
            //do more stuff, but with non-books (like beating up people to take their books)
        }
        //do the picking up
        else if (PickUpObject == null && Physics2D.OverlapCircle(transform.position, 2, mask1) != null)
        {
            PickUpObject = Physics2D.OverlapCircle(transform.position, 2, mask1).gameObject;
            PickUpObject.GetComponent<BookScript>().addBook();
        }
    }
}
