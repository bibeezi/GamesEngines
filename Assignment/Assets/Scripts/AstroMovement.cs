using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroMovement : MonoBehaviour
{
    public float speed = 100f;
    public float lookSpeed = 0.2f;
    public GameObject astronaut;
    public Rigidbody astrobody;
    public Vector3 walkpoint;
    bool walkpointSet = false;
    public int walkPointRange;

    // Start is called before the first frame update
    void Start()
    {
        astrobody = astronaut.GetComponent<Rigidbody>();
        walkPointRange = 50;
    }

    // Update is called once per frame
    void Update()
    {
        astrobody.velocity = transform.forward * speed * Time.deltaTime;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(walkpoint, Vector3.up), lookSpeed * Time.deltaTime);

        if(!walkpointSet)
        {
            GetWalkPoint();
        }
        else {

            Vector3 distanceToWalkpoint = transform.position - walkpoint;

            if(distanceToWalkpoint.magnitude < 5f)
            {
                
                walkpointSet = false;
            }

            if(transform.position.x > walkPointRange - 10 || transform.position.y > walkPointRange - 10 || transform.position.z > walkPointRange - 10) 
            {
                lookSpeed = lookSpeed + 0.01f;
            }
            else if(transform.position.x < -walkPointRange + 10 || transform.position.y < -walkPointRange - 10 || transform.position.z < -walkPointRange - 10)
            {
                lookSpeed = lookSpeed + 0.01f;
            }
            else 
            {
                lookSpeed = 0.2f;
            }
        }
    }

    private void GetWalkPoint()
    {
        // Debug.Log("getting walkpoint");
        // Calculate random point in range
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomY = Random.Range(-walkPointRange, walkPointRange);
        float randomZ = Random.Range(-walkPointRange, walkPointRange);

        walkpoint = new Vector3(randomX, randomY, randomZ);

        walkpointSet = true;
    }
}
