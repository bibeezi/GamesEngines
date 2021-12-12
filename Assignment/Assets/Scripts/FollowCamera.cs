using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = target.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = target.rotation;
    }
}
