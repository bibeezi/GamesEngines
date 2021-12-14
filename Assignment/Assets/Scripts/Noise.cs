using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noise
{
    NoiseSettings noiseSettings;

    public Noise(NoiseSettings noiseSettings)
    {
        this.noiseSettings = noiseSettings;
    }

    public float Evaluate(Vector3 point)
    {
        point += noiseSettings.rotate;
        float noiseValue = Mathf.PerlinNoise(point.x * noiseSettings.roughness, point.y * noiseSettings.roughness);
        return noiseValue * noiseSettings.strength;
    }
}
