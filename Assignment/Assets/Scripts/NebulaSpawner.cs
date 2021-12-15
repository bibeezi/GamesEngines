using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NebulaSpawner : MonoBehaviour
{
    public float universeSize = 100f;
    public float offset = 50f;

    public ParticleSystem nebula;
    public int nebulaAmount = 10;
    public NebulaGenerator nebulaGenerator;

    Vector3 nebulaPosition;
    int chosenCoordinate;

    void Start()
    {
        nebulaGenerator = GetComponent<NebulaGenerator>();

        for(int i = 0; i < nebulaAmount; i++)
        {
            nebula = nebulaGenerator.GenerateNebula(nebula);
         
            Vector3 setNebulaPosition = getNebulaPosition();            

            Instantiate(nebula, setNebulaPosition, Quaternion.identity);
        }
    }
    private Vector3 getNebulaPosition()
    {
        chosenCoordinate = Random.Range(0, 3);

        if(chosenCoordinate == 0)
        {
            float xPositive = Random.Range(universeSize, universeSize + offset);
            float xNegative = Random.Range(-universeSize, -universeSize - offset);

            nebulaPosition = new Vector3(
                Random.Range(0, 2) == 0 ? xPositive : xNegative,
                Random.Range(-universeSize, universeSize),
                Random.Range(-universeSize, universeSize)
            );
        }
        else if(chosenCoordinate == 1)
        {
            float yPositive = Random.Range(universeSize, universeSize + offset);
            float yNegative = Random.Range(-universeSize, -universeSize - offset);

            nebulaPosition = new Vector3(
                Random.Range(-universeSize, universeSize),
                Random.Range(0, 2) == 0 ? yPositive : yNegative,
                Random.Range(-universeSize, universeSize)
            );
        }
        else
        {
            float zPositive = Random.Range(universeSize, universeSize + offset);
            float zNegative = Random.Range(-universeSize, -universeSize - offset);

            nebulaPosition = new Vector3(
                Random.Range(-universeSize, universeSize),
                Random.Range(-universeSize, universeSize),
                Random.Range(0, 2) == 0 ? zPositive : zNegative
            );

        }

        return nebulaPosition;
    }
}
