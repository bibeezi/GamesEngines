using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseFilter
{
    Noise noise = new Noise();
    NoiseSettings noiseSettings;

    public NoiseFilter(NoiseSettings noiseSettings)
    {
        this.noiseSettings = noiseSettings;
    }

    public float Evaluate(Vector3 point)
    {
        float noiseValue = 0;
        float frequency = noiseSettings.amount;
        float amplitude = 1;

        for(int i = 0; i < noiseSettings.numLayers; i++)
        {
            float newPoint = noise.Evaluate(point * frequency + noiseSettings.rotate);
            noiseValue += (newPoint + 1) * 0.5f * amplitude;
            frequency *= noiseSettings.roughness;
            amplitude *= noiseSettings.connection;
        }

        noiseValue = Mathf.Max(0, noiseValue - noiseSettings.protrusion);

        return noiseValue * noiseSettings.height;
    }
}
