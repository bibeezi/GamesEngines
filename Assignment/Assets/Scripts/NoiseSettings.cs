using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [System.Serializable]
public class NoiseSettings 
{    
    [Range(1, 8)]
    public int numLayers = 5;
    public float height = Random.Range(0.15f, 0.35f);
    public float amount = 0.94f;
    public float roughness = Random.Range(2f, 3f);
    public Vector3 rotate = new Vector3(Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100));
    public float connection = Random.Range(-0.25f, 0.25f);
    public float protrusion = Random.Range(0.1f, 1f);
}