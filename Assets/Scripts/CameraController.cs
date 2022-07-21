using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private int speed = 0;
    private int min_speed = -9;
    private int max_speed = 9;
    private int boost_speed = 4;
    private int degrees = 10;

    public Rigidbody rb;

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);

        if (Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.UpArrow)))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * (speed + boost_speed), Space.Self);
        }
        if (Input.GetKey(KeyCode.S) || (Input.GetKey(KeyCode.DownArrow)))
        {
            speed = 0;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(transform.position, transform.up, -0.1f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(transform.position, transform.up, 0.1f);
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            speed += 1;
            if (speed > max_speed)
            {
                speed = max_speed;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            speed -= 1;
            if (speed < min_speed)
            {
                speed = min_speed;
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        Destroy(col.gameObject);
    }
}