using UnityEngine;
using System.Collections;

public class ScenemanagerScript : MonoBehaviour
{
    public GameObject houseObject;
    public GameObject pinkAdversaryObject;
    public GameObject bookObject;

    public void spawnActTwo()
    {
        Instantiate(houseObject, new Vector3(10, 6, 7), houseObject.transform.rotation);
        houseObject = GameObject.Find("HouseMaster(Clone)");
    }

    public void spawnActThree()
    {
        Destroy(houseObject.gameObject);
        Instantiate(pinkAdversaryObject, new Vector3(10, -1, 5), pinkAdversaryObject.transform.rotation);
        Instantiate(bookObject, new Vector3(11, -1, 5), bookObject.transform.rotation);
    }
}
