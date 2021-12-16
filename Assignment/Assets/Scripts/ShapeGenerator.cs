using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeGenerator
{
    TerrainShapeSettings shapeSettings;
    NoiseFilter[] noiseFilters;

    public ShapeGenerator(TerrainShapeSettings shapeSettings)
    {
        this.shapeSettings = shapeSettings;
        noiseFilters = new NoiseFilter[shapeSettings.noiseLayers.Length];
        
        for (int i = 0; i < noiseFilters.Length; i++)
        {
            noiseFilters[i] = new NoiseFilter(shapeSettings.noiseLayers[i].noiseSettings);
        }
    }

    public Vector3 CalculatePointOnPlanet(Vector3 pointOnUnitSphere)
    {
        float elevation = 0;
        for (int i = 0; i < noiseFilters.Length; i++)
        {
            if(shapeSettings.noiseLayers[i].enabled)
            {
                elevation += noiseFilters[i].Evaluate(pointOnUnitSphere);
            }
        }

        return pointOnUnitSphere * shapeSettings.planetRadius * (1 + elevation);
    }
}
