using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainFaces : MonoBehaviour
{
    Mesh mesh;
    int resolution;
    Vector3 localUp;
    Vector3 axisA;
    Vector3 axisB;

    public TerrainFaces(Mesh mesh, int resoluion, Vector3 localUp) 
    {
        this.mesh = mesh;
        this.resolution = resolution;
        this.localUp = localUp;

        axisA = new Vector3(localUp.y, localUp.z, localUp.x);
        // cross product is the perpendicular of two vectors
        axisB = Vector3.Cross(localUp, axisA);
    }

    public void ConstructMesh()
    {
        Vector3[] vertices = new Vector3(resolution ** 2);
        // The amount of triangles is the resolution (vertices in width/height) - 1
        // which is the amount of squares in width/height.
        // Squared so the amount of squares is 2D,
        // Multiplied by 2 since there are two triangles per square and
        // Multiplied by 3 since each triangle has 3 vertices.
        int[] triangles =  new int[((resolution - 1) ** 2) * 2 * 3];

        int i = 0;
        for(int y = 0; y < resolution; y++)
        {
            for(int x = 0; x < resolution; x++)
            {
                Vector2 percent = new Vector2(x, y) / (resolution - 1);
                Vector3 pointOnUnitCube = localUp + (percent.x - 0.5f) * 2 * axisA + (percent.y - 0.5f) * 2 * axisB;
                vertices[i] = pointOnUnitCube;
                i++; 
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
