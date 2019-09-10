/*
 * The base bullet for any gun type. Changing the
 * speed value here and the delay in the RapidFire 
 * script can create a new gun type. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject crossHair;//The distance and the location for the bullet to travel
    private Vector3 end;
    public float speed = 4f; //The speed at which the bullet travels
    // Start is called before the first frame update
    void Start()
    {
        end = crossHair.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, end, Time.deltaTime * speed);
        if (transform.position == end)
            Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
