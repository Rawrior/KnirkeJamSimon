using UnityEngine;
using System.Collections;

public class FirePulser : MonoBehaviour
{
	// Update is called once per frame
	void Update ()
	{
	    transform.localScale = new Vector3(Mathf.Abs(Mathf.Sin(Time.timeSinceLevelLoad))+1f, Mathf.Abs(Mathf.Sin(Time.timeSinceLevelLoad))+1f, 0);
	}
}
