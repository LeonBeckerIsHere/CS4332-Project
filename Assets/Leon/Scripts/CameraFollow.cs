using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    Vector3 offset = new Vector3(0.0f,10.0f,-10.0f);
    // Start is called before the first frame update
    void Start(){
        gameObject.transform.rotation = new Quaternion(0.0f,0.0f,0.0f,1.0f);
        gameObject.transform.Rotate(new Vector3(1.0f,0.0f,0.0f),53.13f);
        gameObject.transform.position = player.transform.position+offset;
    }
    // Update is called once per frame
    void Update(){
        gameObject.transform.position = player.transform.position +offset;
    }
}
