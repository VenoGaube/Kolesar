using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArrowTarget : MonoBehaviour
{
    public Transform target;
    public Transform camera;

        void LateUpdate () 
    {
        // Set the position of the camera's transform to be the same as the camera's, but offset by the calculated offset distance.
        //transform.position = camera.transform.position + offset;
        transform.LookAt(target);
        Vector3 pos = Camera.main.WorldToViewportPoint (transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

}