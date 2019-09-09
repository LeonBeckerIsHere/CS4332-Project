using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Player))]
public class PlayerInput : MonoBehaviour
{
    Player player;
    [SerializeField]
    Camera cam;

    void Start()
    {
        player = GetComponent<Player>();
        player.SetPlayerCoords2D(cam.WorldToScreenPoint(player.transform.position));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionalInput = new Vector3(Input.GetAxis("Horizontal"),0.0f,Input.GetAxis("Vertical"));
        player.SetMoveDirection(directionalInput);

        player.SetLookDirection(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.Jump();
        }

    }

}
