using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroMovement : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody rigidbody;

    private void FixedUpdate() {
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        rigidbody.MovePosition(rigidbody.position + forwardMove);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
