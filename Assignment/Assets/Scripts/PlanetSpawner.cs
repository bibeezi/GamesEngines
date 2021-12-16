using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    public float universeSize = 100f;
    public int planetAmount = 10;
    public GameObject planet;

    public List<GameObject> gameObjects = new List<GameObject>();

    public bool positionPlanets = true;

    IEnumerator MovePlanets(List<GameObject> planets){
        for(int i = 0; i < planetAmount; i++){
            planets[i].transform.position = new Vector3(0, 0, 0);
        }

        positionPlanets = false;

        yield return new WaitForSeconds(1);
    }

    void Start()
    {
        for(int i = 0; i < planetAmount; i++)
        {
            gameObjects.Add(Instantiate(planet));
        }

        for(int j = 0; j < planetAmount; j++)
        {
            float planetX = Random.Range(-universeSize, universeSize);
            float planetY = Random.Range(-universeSize, universeSize);    
            float planetZ = Random.Range(-universeSize, universeSize);

            Vector3 planetPosition = new Vector3(planetX, planetY, planetZ);

            gameObjects[j].transform.position = planetPosition;
        }
    }

    void Update(){
        if(positionPlanets){
            StartCoroutine(MovePlanets(gameObjects));
        }
    }
}
