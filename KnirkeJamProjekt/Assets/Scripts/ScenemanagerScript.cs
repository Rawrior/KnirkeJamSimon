using UnityEngine;
using System.Collections;

public class ScenemanagerScript : MonoBehaviour
{
    public GameObject houseObject;

    public void spawnActTwo()
    {
        Instantiate(houseObject, new Vector3(10, 6, 7), houseObject.transform.rotation);
        houseObject = GameObject.Find("HouseMaster(Clone)");
    }

    public void spawnActThree()
    {
        Destroy(houseObject.gameObject);
    }
}
