using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroMovement : MonoBehaviour
{
    public Rigidbody rigidbody;
    public Vector3 walkpoint;
    public float speed = 100f;
    public float lookSpeed = 0.1f;
    bool walkpointSet = false;
    public int walkPointRange;

    void Start()
    {
        walkPointRange = 50;
        walkpoint = GetWalkPoint();
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {   
        rigidbody.AddForce(transform.forward * speed * Time.deltaTime);

        if (Vector3.Angle(walkpoint - transform.position, transform.forward) < 5f)
        {
            walkpoint = GetWalkPoint();
        }
        else
        {
            transform.localRotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, walkpoint - transform.position, lookSpeed * Time.deltaTime, 0.0f), Vector3.up);
        }

        Vector3 distanceToWalkpoint = transform.position - walkpoint;

        if(distanceToWalkpoint.magnitude < 5f)
        {
            walkpoint = GetWalkPoint();
        }

        // if(transform.position.x > walkPointRange - 10 || transform.position.y > walkPointRange - 10 || transform.position.z > walkPointRange - 10) 
        // {
        //     lookSpeed = lookSpeed + 0.01f;
        // }
        // else if(transform.position.x < -walkPointRange + 10 || transform.position.y < -walkPointRange - 10 || transform.position.z < -walkPointRange - 10)
        // {
        //     lookSpeed = lookSpeed + 0.01f;
        // }
        // else 
        // {
        //     lookSpeed = 0.1f;
        // }
    }

    private Vector3 GetWalkPoint()
    {
        // Calculate random point in range
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomY = Random.Range(-walkPointRange, walkPointRange);
        float randomZ = Random.Range(-walkPointRange, walkPointRange);

        return new Vector3(randomX, randomY, randomZ);
    }
}
