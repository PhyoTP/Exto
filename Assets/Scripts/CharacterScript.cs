using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class CharacterScript : MonoBehaviour
{
    public float moveSpeed;
    // public AudioClip clip;
    // private bool death = false;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Vertical") * Vector3.forward * Time.deltaTime * moveSpeed);
        transform.Translate(Input.GetAxis("Horizontal") * Vector3.right * Time.deltaTime * moveSpeed);
        //mouse control
        gameObject.transform.Rotate(-transform.eulerAngles.x, Input.GetAxis("Mouse X"), -transform.eulerAngles.z);
        //respawn
        // if (transform.localPosition.y < -10 && !death)
        // {
        //     //AudioSource.PlayClipAtPoint(clip, transform.position);
        //     print("bong");
        //     death = true;
        // }
        if (transform.localPosition.y < -10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.Space)){
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up*5, ForceMode.Impulse);
        }
    }
}
