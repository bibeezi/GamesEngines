using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    public float universeSize = 100f;
    public int planetAmount = 10;
    // public GameObject generatedPlanet;
    public GameObject planetPrefab;
    public List<GameObject> gameObjects = new List<GameObject>();
    public bool positionPlanets = true;

    IEnumerator MovePlanets(){
        // for(int i = 0; i < planetAmount; i++){
        //     planets[i].transform.position = new Vector3(0, 0, 0);
        //     planets[i].AddComponent<Planet>();
        // }

        // positionPlanets = false;
            
        yield return new WaitForSeconds(1);

        for(int i = 0; i < planetAmount; i++)
        {
            float planetX = Random.Range(-universeSize, universeSize);
            float planetY = Random.Range(-universeSize, universeSize);    
            float planetZ = Random.Range(-universeSize, universeSize);

            Vector3 planetPosition = new Vector3(planetX, planetY, planetZ);

            GameObject planetPrefab = new GameObject();
            // Planet planet = new Planet();
            TerrainShapeSettings terrainShapeSettings = new TerrainShapeSettings();
            ColourSettings colourSettings = new ColourSettings();

            terrainShapeSettings.noiseLayers = new TerrainShapeSettings.NoiseLayer[2];

            planetPrefab.AddComponent<Planet>();
            planetPrefab.GetComponent<Planet>().terrainShapeSettings = terrainShapeSettings;
            planetPrefab.GetComponent<Planet>().colourSettings = colourSettings;


            planetPrefab.GetComponent<Planet>().GeneratePlanet();

            planetPrefab.transform.position = planetPosition;

            // gameObjects.Add(Instantiate(planetPrefab, planetPosition, Quaternion.identity));
        }
    }

    void Start()
    {

        // GameObject planetPrefab = new GameObject();
        // Planet planet = new Planet();
        
        // for(int i = 0; i < planetAmount; i++)
        // {
        //     float planetX = Random.Range(-universeSize, universeSize);
        //     float planetY = Random.Range(-universeSize, universeSize);    
        //     float planetZ = Random.Range(-universeSize, universeSize);

        //     Vector3 planetPosition = new Vector3(planetX, planetY, planetZ);

        //     GameObject planetPrefab = new GameObject();
        //     Planet planet = new Planet();
        //     TerrainShapeSettings terrainShapeSettings = new TerrainShapeSettings();
        //     ColourSettings colourSettings = new ColourSettings();

        //     planetPrefab.AddComponent<Planet>();
        //     planetPrefab.GetComponent<Planet>().terrainShapeSettings = terrainShapeSettings;
        //     planetPrefab.GetComponent<Planet>().colourSettings = colourSettings;

        //     planetPrefab.transform.position = planetPosition;

            // gameObjects.Add(Instantiate(planetPrefab, planetPosition, Quaternion.identity));
        // }

        StartCoroutine(MovePlanets());
    }

    // void Update(){
    //     if(positionPlanets){
    //         StartCoroutine(MovePlanets(gameObjects));
    //     }
    // }
}
