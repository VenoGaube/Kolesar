using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SedanMovement : MonoBehaviour
{
    //List of your waypoints
    public Transform[] Waypoints;
 
    // How fast the object will move
    public float SpeedMovement;
 
    // The required distance before the object will move to the next waypoint
    public float RequiredDistance = 1.0f;
 
    // Current index in the waypoints array
    private int CurrentWaypointID = 0;

    public Vector3 startPosition;

    public float speedRotation = 1.0f;
   
    void Update (){
        //Get the distance between the object and waypoint
        float distance = Vector3.Distance(Waypoints[CurrentWaypointID].position, transform.position);
 
        //Moves the object toward the waypoint
        transform.position = Vector3.MoveTowards(transform.position, Waypoints[CurrentWaypointID].position, Time.deltaTime * SpeedMovement);
        
        Vector3 targetDirection = Waypoints[CurrentWaypointID].position - transform.position;

        // The step size is equal to speed times frame time.
        float singleStep = speedRotation * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Draw a ray pointing at our target in
        Debug.DrawRay(transform.position, newDirection, Color.red);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
       
        //Updates the current waypoint
        if(distance <= RequiredDistance){
            CurrentWaypointID = (CurrentWaypointID + 1) % Waypoints.Length;
            if(CurrentWaypointID == 0){
                transform.position = startPosition;
            }
        }


             
    }
}


