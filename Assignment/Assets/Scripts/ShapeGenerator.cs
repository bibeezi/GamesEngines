using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeGenerator
{
    TerrainShapeSettings shapeSettings;
    Noise noise;

    public ShapeGenerator(TerrainShapeSettings shapeSettings)
    {
        this.shapeSettings = shapeSettings;
        noise = new Noise(shapeSettings.noiseSettings);
    }

    public Vector3 CalculatePointOnPlanet(Vector3 pointOnUnitSphere)
    {
        float elevation = noise.Evaluate(pointOnUnitSphere);
        return pointOnUnitSphere * shapeSettings.planetRadius * (1 + elevation);
    }
}
