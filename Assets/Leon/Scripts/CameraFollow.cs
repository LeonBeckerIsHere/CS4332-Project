using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    float smoothSpeed = 0.1f;
    [SerializeField]
    Vector3 offset = new Vector3(0.0f, 10.0f, -10.0f);
    [SerializeField]
    float panLength =5.0f;
    public GameObject player;
    Camera cam;
    Vector3 playerCoords2D;
    //This is the vector distance the camera maintains from the player at all times
    
    float mouseXNormalized;
    float mouseYNormalized;
    Vector3 cursorDistance;
    void Start(){
        cam = GetComponent<Camera>();

        //Setup the camera
        gameObject.transform.rotation = new Quaternion(0.0f,0.0f,0.0f,1.0f);
        gameObject.transform.Rotate(new Vector3(1.0f,0.0f,0.0f),53.13f);
        gameObject.transform.position = player.transform.position+offset;

        playerCoords2D = cam.WorldToScreenPoint(player.transform.position);
    }

    void repositionCameraOnPlayer(){
        //Updates every frame to follow the player
        Vector3 desiredPosition = player.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }

    void getNormalizedMouseCoordinates(){
        //TODO: refactor this section to be apart of a player input script
        //Get cursor distance from the player and normalize it
        cursorDistance = Input.mousePosition - playerCoords2D;

        mouseXNormalized = 2 * cursorDistance.x / Screen.width;
        mouseYNormalized = 2 * cursorDistance.y / Screen.height;
    }

    void panCamera(float screenX, float screenY){
        //Camera pans but the movement of the camera along the z-axis is not properly normalized since the player is not exactly at the center of the y axis on the screen
        offset = Vector3.Lerp(offset,new Vector3(screenX*panLength,10, -10 + screenY*panLength),smoothSpeed);
    }

    private void FixedUpdate(){
        repositionCameraOnPlayer();

        getNormalizedMouseCoordinates();

        //TODO: use the normalized cursor distance to move the camera in the direction vector of the cursor from the player
        panCamera(mouseXNormalized, mouseYNormalized);
    }
}
