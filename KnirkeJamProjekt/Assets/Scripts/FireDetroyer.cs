using UnityEngine;

public class FireDetroyer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("An object entere the trigger. Name: " + other.gameObject.name);
        Destroy(other.gameObject);
    }
}
