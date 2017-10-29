using UnityEngine;

public class FadeScript : MonoBehaviour
{
    public bool doFade = false;
    public float fadeAmount = 1.05f;

    void Awake()
    {
        if (GetComponent<MeshRenderer>().enabled == false)
            GetComponent<MeshRenderer>().enabled = true;
    }

    void Update()
    {
        if (doFade)
        {
            fadeAmount -= Time.deltaTime * 0.25f;
            FadeMethod();
        }

        if (fadeAmount <= -0.05f)
        {
            Destroy(gameObject);
        }
    }

    public void FadeMethod()
    { 
        GetComponent<Renderer>().material.color = new Color(255, 255, 255, fadeAmount);
    }
}
