using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A Scriptable Object stores data that can be accessed by reference from all Prefabs
[CreateAssetMenu()]
public class TerrainShapeSettings : ScriptableObject 
{
    public float planetRadius = 1f;
    public NoiseLayer[] noiseLayers;

    [System.Serializable]
    public class NoiseLayer
    {
        public bool enabled = true;
        public NoiseSettings noiseSettings;
    }

    void Start()
    {
        noiseLayers = new NoiseLayer[2];
    }
}