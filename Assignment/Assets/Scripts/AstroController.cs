using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroController : MonoBehaviour
{
    public GameObject astronaut;
    public float lookSpeed = 100f;
    public Transform transform;
    public float angleX = 0;
    public float angleY = 0;

    void Start()
    {
        Cursor.visible = false;
        transform = gameObject.transform;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        angleX = angleX + mouseX;
        angleY = angleY + mouseY;

        Quaternion smoothRotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-angleY, angleX, 0), lookSpeed * Time.deltaTime);
        transform.localRotation = smoothRotation;
    }
}
