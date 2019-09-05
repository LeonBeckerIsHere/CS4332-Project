using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFire : MonoBehaviour
{
    public bool triggerDown;
    public MachineGunBullet bullet;
    public Transform gun;
    public GameObject crossHair;
    public float delay = .04f;

    // Update is called once per frame
    private void Start()
    {
        
    }
    void Update()
    {
        //Dectecting if the user is pressing the fire button
        if (Input.GetButtonDown("Fire1"))
            triggerDown = true;
        else if(Input.GetButtonUp("Fire1"))
            triggerDown = false;
        //If the user is firing
        if (triggerDown)
        {
            MachineGunBullet newBullet = Instantiate(bullet, gun.position, gun.rotation) as MachineGunBullet;
            newBullet.crossHair = crossHair;
        }
    }

    

}
