using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NebulaSpawner : MonoBehaviour
{
    public float universeSize = 100f;
    public ParticleSystem nebula;
    public int nebulaAmount = 10;
    List<Vector3> nebulaRanges;
    public NebulaGenerator nebulaGenerator;

    void Start()
    {
        nebulaGenerator = GetComponent<NebulaGenerator>();

        for(int i = 0; i < nebulaAmount; i++)
        {
            nebula = nebulaGenerator.GenerateNebula(nebula);
         
            float nebulaX1 = Random.Range(universeSize, universeSize + 50f);
            float nebulaX2 = Random.Range(-universeSize, -universeSize - 50f);
            float nebulaY1 = Random.Range(universeSize, universeSize + 50f);    
            float nebulaY2 = Random.Range(-universeSize, -universeSize - 50f);    
            float nebulaZ1 = Random.Range(universeSize, universeSize + 50f);
            float nebulaZ2 = Random.Range(-universeSize, -universeSize - 50f);

            Vector3 nebulaPosition = new Vector3(
                Random.Range(0, 2) == 0 ? nebulaX1 : nebulaX2,
                Random.Range(0, 2) == 0 ? nebulaY1 : nebulaY2,
                Random.Range(0, 2) == 0 ? nebulaZ1 : nebulaZ2
            );

            Instantiate(nebula, nebulaPosition, Quaternion.identity);
        }
    }
}
