using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroController : MonoBehaviour
{
    Transform transform;
    Rigidbody rigidbody;
    public float lookSpeed = 0.5f;
    public float speed = 30f;
    float angleX = 0;
    float angleY = 0;


    void Start()
    {
        Cursor.visible = false;
        transform = gameObject.transform;
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        angleX = angleX + (mouseX % 1);
        angleY = angleY + (mouseY % 1);
        
        transform.localRotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-angleY, angleX, 0), lookSpeed * Time.deltaTime);

        if(x > 0)
        {
            rigidbody.AddForce(transform.right * speed * Time.deltaTime);
        }
        else if(x < 0)
        {
            rigidbody.AddForce(-transform.right * speed * Time.deltaTime);
        }
        if(z > 0)
        {
            rigidbody.AddForce(transform.forward * speed * Time.deltaTime);
        }
        else if(z < 0)
        {
            rigidbody.AddForce(-transform.forward * speed * Time.deltaTime);
        }
    }
}
