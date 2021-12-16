using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A Scriptable Object stores data that can be accessed by reference from all Prefabs
[CreateAssetMenu()]
public class ColourSettings : ScriptableObject {
    
    public Color planetColour;
    public Material planetMaterial;
}