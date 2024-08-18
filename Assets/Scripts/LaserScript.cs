using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    private GameObject beam;
    private float opacity = 0f;
    private int time;

    void Start()
    {
        beam = GameObject.Find("Beam");
        beam.SetActive(false);
        time = Random.Range(1, 5);
        StartCoroutine(ControlLaser());
    }

    IEnumerator ControlLaser()
    {
        while (true) 
        {
            yield return new WaitForSeconds(time); 

            
            while (opacity < 1f)
            {
                opacity += 0.1f;
                gameObject.GetComponent<MeshRenderer>().material.color = new Color(0.8f, 1, 0.01f, opacity);
                yield return new WaitForSeconds(0.1f); 
            }

            beam.SetActive(true); 
            yield return new WaitForSeconds(3f);
            beam.SetActive(false); 

            opacity = 0f;
            gameObject.GetComponent<MeshRenderer>().material.color = new Color(0.8f, 1, 0.01f, opacity);

            time = Random.Range(5, 10);
        }
    }
}
