using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroToggle : MonoBehaviour
{
    AstroMovement movement;
    AstroController controller;

    IEnumerator delayToggle()
    {
        yield return new WaitForSeconds(1);
        
        controller.enabled = !controller.enabled;
        movement.enabled = !movement.enabled;
    }

    void Start()
    {
        movement = gameObject.GetComponent<AstroMovement>();    
        controller = gameObject.GetComponent<AstroController>();
    }

    void Update()
    {
        if(Input.GetKeyUp("space"))
        {
            StartCoroutine(delayToggle());
        }
    }
}
