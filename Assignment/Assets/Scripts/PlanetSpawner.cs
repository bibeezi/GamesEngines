using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    public float universeSize = 100f;
    public int planetAmount = 10;
    public GameObject planet;
    public Planet script;
    public List<GameObject> planets;
    // public List<GameObject> gameObjects = new List<GameObject>();
    public bool positionPlanets = true;

    IEnumerator MovePlanets(List<GameObject> planets){
        for(int i = 0; i < planetAmount; i++){
            planets[i].transform.position = new Vector3(
                Random.Range(-universeSize, universeSize), 
                Random.Range(-universeSize, universeSize), 
                Random.Range(-universeSize, universeSize)
            );
        }

        positionPlanets = false;
            
        yield return new WaitForSeconds(1);
    }

    void Awake()
    {
        // for(int i = 0; i < planetAmount; i++)
        // {
        //     float planetX = Random.Range(-universeSize, universeSize);
        //     float planetY = Random.Range(-universeSize, universeSize);    
        //     float planetZ = Random.Range(-universeSize, universeSize);

        //     Vector3 planetPosition = new Vector3(planetX, planetY, planetZ);
            // Planet planet = new Planet();


        for (int i = 0; i < planetAmount; i++)
        {
            GameObject planet = new GameObject("Planet " + i);
            script = planet.AddComponent<Planet>();

            TerrainShapeSettings terrainShapeSettings = new TerrainShapeSettings();
            terrainShapeSettings.planetRadius = Random.Range(3f, 10f);
            terrainShapeSettings.noiseLayers = new TerrainShapeSettings.NoiseLayer[2];

            for (int j = 0; j < terrainShapeSettings.noiseLayers.Length; j++)
            {
                TerrainShapeSettings.NoiseLayer newLayer = new TerrainShapeSettings.NoiseLayer();
                newLayer.enabled = true;

                NoiseSettings noiseSettings = new NoiseSettings();

                noiseSettings.numLayers = 5;
                noiseSettings.amount = 0.94f;
                if(j == 0)
                {
                    noiseSettings.height = Random.Range(0.15f, 0.2f);
                    noiseSettings.roughness = Random.Range(2f, 2.5f);
                    noiseSettings.rotate = new Vector3(Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100));
                    noiseSettings.connection = Random.Range(-0.25f, 0f);
                    noiseSettings.protrusion = Random.Range(0.1f, 0.5f);
                }
                else if(j == 1)
                {
                    noiseSettings.height = Random.Range(0.35f, 0.5f);
                    noiseSettings.roughness = Random.Range(2.5f, 3f);
                    noiseSettings.rotate = new Vector3(Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100));
                    noiseSettings.connection = Random.Range(0f, 0.25f);
                    noiseSettings.protrusion = Random.Range(0.5f, 1f);
                }

                newLayer.noiseSettings = noiseSettings;
                
                terrainShapeSettings.noiseLayers[j] = newLayer;
            }

            ColourSettings colourSettings = new ColourSettings();
            colourSettings.planetGradient = new Gradient();
            colourSettings.planetMaterial = new Material(Resources.Load<Shader>("Planet"));
            // colourSettings.planetMaterial = Resources.Load<Material>("PlanetMaterial");


            script.ConstructNewPlanet(100, terrainShapeSettings, colourSettings);

            planets.Add(planet);
        }
            

            // ColourSettings colourSettings = new ColourSettings();


            // planetPrefab.GetComponent<Planet>().terrainShapeSettings = terrainShapeSettings;
            // planetPrefab.GetComponent<Planet>().colourSettings = colourSettings;
            

            // TerrainShapeSettings.NoiseLayer nl1 = new TerrainShapeSettings.NoiseLayer();
            // TerrainShapeSettings.NoiseLayer nl2 = new TerrainShapeSettings.NoiseLayer();

            // nl1.noiseSettings = new NoiseSettings();
            // nl1.enabled = true;
            // nl1.noiseSettings.numLayers = 1;
            // // planetPrefab.GetComponent<Planet>().terrainShapeSettings.noiseLayers[0] = nl1;
            // // planetPrefab.GetComponent<Planet>().terrainShapeSettings.noiseLayers[0].noiseSettings.numLayers = 1;

            // // var script = planetPrefab.GetComponent<Planet>();


            // Debug.Log(planetPrefab.GetComponent<Planet>().terrainShapeSettings.noiseLayers);

            // planetPrefab.GetComponent<Planet>().GeneratePlanet();

        //     planetPrefab.transform.position = planetPosition;
        // }

        // for(int i = 0; i < planetAmount; i++)
        // {
        //     gameObjects.Add(Instantiate(planetPrefab));
        // }

        // for(int j = 0; j < planetAmount; j++)
        // {
        //     float planetX = Random.Range(-universeSize, universeSize);
        //     float planetY = Random.Range(-universeSize, universeSize);    
        //     float planetZ = Random.Range(-universeSize, universeSize);

        //     Vector3 planetPosition = new Vector3(planetX, planetY, planetZ);

        //     gameObjects[j].transform.position = planetPosition;
        // }
    }

    void Update(){
        if(positionPlanets){
            StartCoroutine(MovePlanets(planets));
        }
    }
}
