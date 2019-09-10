/*
 * This scipt is the base for all shooting objects.
 * A button 'fire1' must be set in the unity controller
 * for this script to work.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFire : MonoBehaviour
{
    public bool triggerDown; //Determine if the player is pressing the fire button
    public Bullet bullet; //The type of bullet 
    public Transform gun; //Where the bullets will fire from 
    public GameObject crossHair; //Distance and directions the bullets will go
    public float delay = .5f; //The delay between shots
    private float shootDelay = 0.0f;
    public int ammo = 50; //The ammount of ammo 

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
            Bullet newBullet = Instantiate(bullet, gun.position, gun.rotation) as Bullet;
            newBullet.crossHair = crossHair;
            shootDelay = Time.time + delay;
            ammo--;
        }
    }
}
