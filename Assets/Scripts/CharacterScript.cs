using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class CharacterScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public string nextScene;
    private bool inAir;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Vertical") * Vector3.forward * Time.deltaTime * moveSpeed);
        transform.Translate(Input.GetAxis("Horizontal") * Vector3.right * Time.deltaTime * moveSpeed);
        //mouse control
        gameObject.transform.Rotate(-transform.eulerAngles.x, Input.GetAxis("Mouse X"), -transform.eulerAngles.z);
        //respawn
        if (transform.localPosition.y < -10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.Space) && !inAir){
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up*5, ForceMode.Impulse);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Beam"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (collision.collider.CompareTag("Finish"))
        {
            SceneManager.LoadScene(nextScene);
        }else
        {
            inAir = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        inAir = true;
    }
}
