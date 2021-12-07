using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroMovement : MonoBehaviour
{
    public float speed = 1f;
    public GameObject astronaut;
    public Rigidbody rigidbody;
    public Vector3 walkpoint;
    bool walkpointSet = false;
    public int walkPointRange;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = astronaut.GetComponent<Rigidbody>();
        walkPointRange = 50;
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = transform.forward * speed * Time.deltaTime;
        // if(!walkpointSet)
        // {
        //     GetWalkPoint();
        // }
        // else {

        //     transform.position = Vector3.MoveTowards(transform.position, walkpoint, speed * Time.deltaTime);

        //     Vector3 distanceToWalkpoint = transform.position - walkpoint;

        //     Debug.Log(distanceToWalkpoint.magnitude);

        //     if(distanceToWalkpoint.magnitude < 1f)
        //     {
        //         walkpointSet = false;
        //     }
        // }
    }

    private void GetWalkPoint()
    {
        Debug.Log("getting walkpoint");
        // Calculate random point in range
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomY = Random.Range(-walkPointRange, walkPointRange);
        float randomZ = Random.Range(-walkPointRange, walkPointRange);

        walkpoint = new Vector3(randomX, randomY, randomZ);

        walkpointSet = true;
    }
}
