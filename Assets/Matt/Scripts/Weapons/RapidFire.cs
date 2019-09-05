using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFire : MonoBehaviour
{
    public bool triggerDown;
    public MachineGunBullet bullet;
    public Transform gun;
    public GameObject crossHair;
    public float delay = .5f;
    private float shootDelay = 0.0f;
    public int ammo = 50;

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
        if (triggerDown && Time.time > shootDelay && ammo > 0)
        {
            MachineGunBullet newBullet = Instantiate(bullet, gun.position, gun.rotation) as MachineGunBullet;
            newBullet.crossHair = crossHair;
            shootDelay = Time.time + delay;
            ammo--;
        }
    }
}
