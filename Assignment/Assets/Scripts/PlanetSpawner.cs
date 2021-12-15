using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    public float universeSize = 1000f;
    public int planetAmount = 10;
    public GameObject planet;

    void Start()
    {
        for(int i = 0; i < planetAmount; i ++)
        {
            float planetX = Random.Range(-universeSize, universeSize);
            float planetY = Random.Range(-universeSize, universeSize);    
            float planetZ = Random.Range(-universeSize, universeSize);

            Vector3 planetPosition = new Vector3(planetX, planetY, planetZ);

            Instantiate(planet, planetPosition, Quaternion.identity);
        }
            
    }
}
