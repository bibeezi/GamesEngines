using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeGenerator
{
    TerrainShapeSettings shapeSettings;

    public ShapeGenerator(TerrainShapeSettings shapeSettings)
    {
        this.shapeSettings = shapeSettings;
    }

    public Vector3 CalculatePointOnPlanet(Vector3 pointOnUnitSphere)
    {
        return pointOnUnitSphere * shapeSettings.planetRadius;
    }
}
