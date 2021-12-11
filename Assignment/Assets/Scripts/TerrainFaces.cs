using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainFaces
{
    Mesh mesh;
    int resolution;
    Vector3 localVector;
    Vector3 axisA;
    Vector3 axisB;
    ShapeGenerator shapeGenerator;

    public TerrainFaces(ShapeGenerator shapeGenerator, Mesh mesh, int resolution, Vector3 localVector) 
    {
        this.shapeGenerator = shapeGenerator;
        this.mesh = mesh;
        this.resolution = resolution;
        // localVector goes up locally
        this.localVector = localVector;

        // axisA goes right locally
        axisA = new Vector3(localVector.y, localVector.z, localVector.x);
        // cross product is the perpendicular of the two vectors that start from (0, 0, 0)
        //  therefore, axis B goes towards locally.
        axisB = Vector3.Cross(localVector, axisA);
    }

    public void ConstructMesh()
    {
        Vector3[] vertices = new Vector3[resolution * resolution];
        // the amount of vertices for each triangle
        //  is each sqaure (resolution (vertices per line) - 1)
        //  squared so the amount of squares is 2D,
        //  multiplied by 2 since there are two triangles per square and
        //  multiplied by 3 since each triangle has 3 vertices.
        int[] triangleVertices = new int[(resolution - 1) * (resolution - 1) * 6];
        int triangleVertex = 0;
        
        for(int y = 0; y < resolution; y++)
        {
            for(int x = 0; x < resolution; x++)
            {
                int i = x + y * resolution;
                // when x is 0, it is in the first vertex of the mesh
                // divided by resolution - 1 because there is no need to create triangles
                //  on the last vertex
                Vector2 vertex = new Vector2(x, y) / (resolution - 1);
                // starts at (-1, 1, -1) vertex and ends at (1, 1, 1) vertex
                Vector3 pointOnUnitCube = localVector + (vertex.x - 0.5f) * 2 * axisA + (vertex.y - 0.5f) * 2 * axisB;
                // the vertices are changed to be between -1.0 and 1.0 to create an almost spherical shape
                Vector3 pointOnUnitSphere = pointOnUnitCube.normalized;
                vertices[i] = shapeGenerator.CalculatePointOnPlanet(pointOnUnitSphere);

                // Create the triangles starting from a vertex
                //  except the very right vertex
                if(x != resolution - 1 && y != resolution - 1)
                {
                    triangleVertices[triangleVertex] = i;
                    triangleVertices[triangleVertex + 1] = i + resolution + 1;
                    triangleVertices[triangleVertex + 2] = i + resolution;

                    triangleVertices[triangleVertex + 3] = i;
                    triangleVertices[triangleVertex + 4] = i + 1;
                    triangleVertices[triangleVertex + 5] = i + resolution + 1;
                    triangleVertex += 6;
                }
            }
        }

        // clear previous data of mesh
        mesh.Clear();
        // set vertices and triangles of mesh
        mesh.vertices = vertices;
        mesh.triangles = triangleVertices;
        // reset perpendicular of each triangle
        mesh.RecalculateNormals();
    }
}
