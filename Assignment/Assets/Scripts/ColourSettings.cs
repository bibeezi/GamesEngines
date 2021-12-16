using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A Scriptable Object stores data that can be accessed by reference from all Prefabs
[CreateAssetMenu()]
public class ColourSettings : ScriptableObject {
    
    public Gradient planetGradient;
    public Material planetMaterial;

    public int colourAmount;
    GradientColorKey[] gradientColorKeys;
    GradientColorKey gradientColorKey;

    public void getColour()
    {
        colourAmount = Random.Range(3, 6);
        gradientColorKeys = new GradientColorKey[colourAmount];
        Gradient gradient = new Gradient();

        for(int i = 0; i < colourAmount; i++)
        {
            if(i == 0)
            {
                Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                gradientColorKey = new GradientColorKey(color, (float) i);
            }
            else if(i == colourAmount)
            {
                Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                gradientColorKey = new GradientColorKey(color, 1f);
            }
            else
            {
                Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                gradientColorKey = new GradientColorKey(color, Random.Range(0f, 1f));
            }
            
            gradientColorKeys[i] = gradientColorKey;
        }

        gradient.SetKeys(gradientColorKeys, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(1.0f, 1.0f) });

        planetGradient = gradient;
    }
}