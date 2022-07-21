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
        if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            transform.RotateAround(transform.position, transform.forward, 0.1f);
        }
        if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
        {
            transform.RotateAround(transform.position, transform.forward, -0.1f);
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
        if (Input.GetMouseButton(1))  // use rmb to rotate view
        {
            if (Input.GetAxis("Mouse X") > 0)
            {
                transform.RotateAround(transform.position, transform.up, Input.GetAxis("Mouse X") * degrees);
            }
            if (Input.GetAxis("Mouse X") < 0)
            {
                transform.RotateAround(transform.position, transform.up, Input.GetAxis("Mouse X") * degrees);
            }
            if (Input.GetAxis("Mouse Y") > 0)
            {
                transform.RotateAround(transform.position, transform.right, Input.GetAxis("Mouse Y") * -degrees);
            }
            if (Input.GetAxis("Mouse Y") < 0)
            {
                transform.RotateAround(transform.position, transform.right, Input.GetAxis("Mouse Y") * -degrees);
            }
        }
        if (transform.position.y < 0)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        Destroy(col.gameObject);
    }
}