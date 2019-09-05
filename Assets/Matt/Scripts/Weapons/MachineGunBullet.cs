using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunBullet : MonoBehaviour
{
    public GameObject crossHair;
    private Vector3 end;
    public float speed = 4f;
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
}
