using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NebulaSpawner : MonoBehaviour
{
    public ParticleSystem nebula;
    public int nebulaAmount = 1;

    void Start()
    {
        for(int i = 0; i < nebulaAmount; i++)
        {
            Instantiate(nebula, new Vector3(120, 0, 100), Quaternion.identity);
        }
    }
}
