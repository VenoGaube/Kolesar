using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    CharacterController characterController;
    public float MovementSpeed;
    public float Gravity = 9.8f;
    private float handleTurnInput;
    private Camera mainCam;
    public Transform handlebars;
    private Quaternion startRot = Quaternion.Euler(0, 0, 0);
    private Quaternion targetRot = Quaternion.Euler(0, 0, 0);
    private Quaternion targetRot2 = Quaternion.Euler(0, 0, 0);
    private float speedRot = 2.5f; //speed rotation
    private float oldEulerAngles;
    private float vertical;
    private int score;
    private bool stopZnak;
    private bool jeZaustavil;
    private bool prvicVen;
    public Text scoreText;


    private void Start()
    {
        prvicVen = false;
        stopZnak = false;
        characterController = GetComponent<CharacterController>();
        mainCam = Camera.main;
        startRot = this.transform.localRotation; //initialization start rotation
        targetRot = startRot;
        targetRot *= Quaternion.Euler(0, 45, 0);
        targetRot2 = startRot;
        targetRot2 *= Quaternion.Euler(0, -45, 0);
        oldEulerAngles = transform.rotation.eulerAngles.y;
        score = 0;
        scoreText.text = "Rezultat: " + score.ToString();
        jeZaustavil = false;
    }

    void FixedUpdate()
    {
        // player movement - forward, backward, left, right

        vertical = Input.GetAxis("Vertical") * MovementSpeed;

        Vector3 camForwardFlat = new Vector3(mainCam.transform.forward.x, 0f,
                mainCam.transform.forward.z).normalized;

        if (vertical != 0)
        {
            characterController.Move((camForwardFlat * vertical) * Time.deltaTime);
        }

        oldEulerAngles = transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.LookRotation(mainCam.transform.forward, mainCam.transform.up);

        if (oldEulerAngles > transform.rotation.eulerAngles.y)
        {
            handlebars.localRotation = Quaternion.Slerp(handlebars.localRotation, targetRot2, speedRot * Time.deltaTime);
        }
        else if (oldEulerAngles < transform.rotation.eulerAngles.y)
        {
            handlebars.localRotation = Quaternion.Slerp(handlebars.localRotation, targetRot, speedRot * Time.deltaTime);
        }
        

    }

    //Upon collision with another GameObject, this GameObject will reverse direction
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Goal"))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            SceneManager.LoadScene("VictoryScreen");
        }
        else if (other.gameObject.CompareTag("Car"))
        {
            SceneManager.LoadScene("DeathScreen");
        }
        else if (other.gameObject.CompareTag("Goal2"))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            SceneManager.LoadScene("EndScreen");
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Stop"))
        {
            
            Debug.Log("STOP ZNAK!");
            stopZnak = true;
            Debug.Log(Input.GetAxis("Vertical") * MovementSpeed);
            if (Input.GetAxis("Vertical") * MovementSpeed == 0 && !jeZaustavil)
            {
                jeZaustavil = true;
                score += 10;
                scoreText.text = "Rezultat: " + score.ToString();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        stopZnak = false;
        jeZaustavil = false;
    }
}