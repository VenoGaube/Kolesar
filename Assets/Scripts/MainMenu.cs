using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    void Update () {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void PlayLevel01(){
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("Level01");
    }

    public void PlayLevel02(){
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("Level02");
    }

    public void QuitGame(){
        Application.Quit();
    }
}
