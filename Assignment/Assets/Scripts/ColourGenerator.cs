using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourGenerator
{
    ColourSettings colourSettings;
    Texture2D texture;
    const int textureResolution = 50;

    public void UpdateColourSettings(ColourSettings colourSettings)
    {
        this.colourSettings = colourSettings;
        texture = new Texture2D(textureResolution, 1);
    }

    public void UpdateHeights(Heights heights)
    {
        colourSettings.planetMaterial.SetVector("_heights", new Vector4(heights.Min, heights.Max));
    }

    public void UpdateColours()
    {
        Color[] colours = new Color[textureResolution];

        for (int i = 0; i < textureResolution; i++)
        {
            colours[i] = colourSettings.planetGradient.Evaluate(i / (textureResolution - 1f));
        }

        texture.SetPixels(colours);
        texture.Apply();

        colourSettings.planetMaterial.SetTexture("_texture", texture);
        colourSettings.getColour();
    }
}
