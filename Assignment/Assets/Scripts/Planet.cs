using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    // 256 is the maximum amount of vertices a mesh can have
    [Range(2,256)]
    public int resolution = 10;
    int faces = 6;
    // Save in the editor and hide in the inspector
    [SerializeField, HideInInspector]
    MeshFilter[] meshFilters;
    TerrainFaces[] terrainFaces;

    // Unity calls this function when the script is loaded or a value
    //  changes in the inspector
    private void OnValidate()
    {
        Initialize();
        GenerateMesh();
    }
    
    void Initialize() 
    {
        if(meshFilters == null || meshFilters.Length == 0)
        {
            meshFilters = new MeshFilter[faces];
        }
        terrainFaces = new TerrainFaces[faces];
        Vector3[] directions = { Vector3.up, Vector3.down, Vector3.left, Vector3.right, Vector3.forward, Vector3.back };

        for (int i = 0; i < faces; i++)
        {
            if(meshFilters[i] == null)
            {
                GameObject mesh = new GameObject("mesh");
                mesh.transform.parent = transform;
                
                mesh.AddComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Standard"));
                meshFilters[i] = mesh.AddComponent<MeshFilter>();
                meshFilters[i].sharedMesh = new Mesh();
            }
            
            terrainFaces[i] = new TerrainFaces(meshFilters[i].sharedMesh, resolution, directions[i]);
        }
    }

    void GenerateMesh()
    {
        foreach(TerrainFaces face in terrainFaces)
        {
            face.ConstructMesh();
        }
    }
}
