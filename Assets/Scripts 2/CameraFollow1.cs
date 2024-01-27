using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float resetSpeed = 0.5f;
    public float cameraSpeed = 0.3f;

    public Bounds cameraBounds;
    public Transform target;
    private bool followsPlayer ;

    public float offsetZ;
    public Vector3 currentVelocity;
    public Vector3 lastTargetPosition;

    public Vector3 respawnPosition;
    

    void Awake()
    {
        BoxCollider2D myCol = GetComponent<BoxCollider2D>();
        myCol.size = new Vector2(Camera.main.aspect*2f*Camera.main.orthographicSize,15f);
        cameraBounds = myCol.bounds;
 
    }

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        lastTargetPosition = target.position; 
        offsetZ = (transform.position - target.position).z;
        followsPlayer = true;   
    }

    void Update()
    {
        if(followsPlayer){
            Vector3 aheadTargetPos =target.position + Vector3.forward*offsetZ;

            if(aheadTargetPos.x >= transform.position.x){
                Vector3 newCameraPosition = Vector3.SmoothDamp(transform.position,aheadTargetPos,ref currentVelocity,cameraSpeed);
                transform.position = new Vector3(newCameraPosition.x,transform.position.y,newCameraPosition.z);
                lastTargetPosition = target.position;
            }
            else if(aheadTargetPos.x < transform.position.x){
                Vector3 newCameraPosition = Vector3.SmoothDamp(transform.position,aheadTargetPos,ref currentVelocity,cameraSpeed);
                transform.position = new Vector3(newCameraPosition.x,transform.position.y,newCameraPosition.z);
                lastTargetPosition = target.position;
            }
            //else if (aheadTargetPos.x <= transform.position.x - (Camera.main.orthographicSize)/2){
            //     Vector3 newCameraPosition = Vector3.SmoothDamp(transform.position,aheadTargetPos,ref currentVelocity,cameraSpeed);
            //     Debug.Log("Gay");
            // }
        }
        if (IsPlayerOutOfBounds())
        {
            RespawnPlayer();
        }
    }
    bool IsPlayerOutOfBounds()
    {
        // Check if the player's position is below the lower end of the camera bounds
        return target.position.y < cameraBounds.min.y;
    }

    void RespawnPlayer()
    {
        // Set the player's position to the respawn position
        target.position = respawnPosition;
        
        // You might want to perform additional actions here, such as resetting player stats or applying respawn effects.

        // Move the camera back to its original position (assuming the camera is a child of another GameObject)
        Camera.main.transform.position = Vector3.zero;
    }
}







