using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourGenerator
{
    ColourSettings colourSettings;

    public ColourGenerator(ColourSettings colourSettings)
    {
        this.colourSettings = colourSettings;
    }

    public void UpdateHeights(Heights heights)
    {
        colourSettings.planetMaterial.SetVector("_heights", new Vector4(heights.Min, heights.Max));
    }
}
