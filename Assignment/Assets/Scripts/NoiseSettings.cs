using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NoiseSettings 
{    
    [Range(1, 8)]
    public int numLayers;
    public float height = 1;
    public float amount = 1;
    public float roughness = 2;
    public Vector3 rotate;
    public float connection = 0.5f;
    public float protrusion;
}