using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroController : MonoBehaviour
{
    public GameObject astronaut;
    public float speed = 100f;
    public float lookSpeed = 1f;
    public Transform transform;

    void Start()
    {
        Cursor.visible = false;
        transform = gameObject.transform;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // transform.Rotate(Vector3.up, mouseX);
        // transform.Rotate(Vector3.left, mouseY);

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(transform.position + new Vector3(mouseX, mouseY, 0), Vector3.up), lookSpeed * Time.deltaTime);
    }
}
