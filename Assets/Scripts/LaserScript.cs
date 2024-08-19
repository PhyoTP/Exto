using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LaserScript : MonoBehaviour
{
    public GameObject beam;
    private float progress;
    private int time;

    void Start()
    {
        time = Random.Range(1, 10);
        StartCoroutine(ControlLaser());
    }

    IEnumerator ControlLaser()
    {
        while (true) 
        {
            yield return new WaitForSeconds(time);


            progress = 0f;
            while (progress < 1f)
            {
                progress += 0.01f;
                gameObject.GetComponent<MeshRenderer>().material.color = new Color(0.8f, 1, 0.01f, progress);
                yield return new WaitForSeconds(0.01f);
            }
            progress = 0f;
            while (progress < 1f)
            {
                progress += 0.1f;
                beam.transform.position = new Vector3(-7 + (7 * progress), beam.transform.position.y, beam.transform.position.z);
                beam.transform.localScale = new Vector3(beam.transform.localScale.x, 1 + (4.5f * progress), beam.transform.localScale.z);
                yield return new WaitForSeconds(0.01f);
            }
            yield return new WaitForSeconds(3f);
            progress = 0f;
            while (progress < 1f)
            {
                progress += 0.1f;
                gameObject.GetComponent<MeshRenderer>().material.color = new Color(0.8f, 1, 0.01f, 1 - progress);
                beam.transform.position = new Vector3(-7 * progress, beam.transform.position.y, beam.transform.position.z);
                beam.transform.localScale = new Vector3(beam.transform.localScale.x, 5.5f - 4.5f * progress, beam.transform.localScale.z);
                yield return new WaitForSeconds(0.01f);
            }
            time = Random.Range(1, 10);
        }
    }
}
