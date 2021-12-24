using UnityEngine;

public class FreeCamera : MonoBehaviour
{
    public float sensitivity = 1f;
    void Update ()
    {
        var c = Camera.main.transform;
        c.Rotate(0, Input.GetAxis("Mouse X")* sensitivity, 0);
        if (Input.GetMouseButtonDown(0))
            Cursor.lockState = CursorLockMode.Locked;
    }
}