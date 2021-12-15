using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NebulaGenerator : MonoBehaviour
{
    ParticleSystemShapeType[] shapes = { ParticleSystemShapeType.Donut, ParticleSystemShapeType.BoxEdge, ParticleSystemShapeType.Circle };

    public ParticleSystem GenerateNebula(ParticleSystem nebula)
    {
        ParticleSystem.MainModule main = nebula.main;
        ParticleSystem.EmissionModule emission = nebula.emission;
        ParticleSystem.ShapeModule shape = nebula.shape;
        ParticleSystem.VelocityOverLifetimeModule velocityOverLifetime = nebula.velocityOverLifetime;

        main.duration = 99999;
        main.loop = true;
        main.startLifetime = 10;
        main.startSize = 5;
        main.maxParticles = 1000;

        emission.rateOverTime = 100;

        shape.shapeType = shapes[Random.Range(0, 3)];
        if(shape.shapeType == ParticleSystemShapeType.Donut)
        {
            shape.radius = Random.Range(5, 10);
        }
        else if(shape.shapeType == ParticleSystemShapeType.BoxEdge)
        {

        }
        else if(shape.shapeType == ParticleSystemShapeType.Circle)
        {

        }

        velocityOverLifetime.enabled = true;
        velocityOverLifetime.orbitalX = Random.Range(-0.5f, 0.5f);
        velocityOverLifetime.orbitalY = Random.Range(-0.5f, 0.5f);
        velocityOverLifetime.orbitalZ = Random.Range(-0.5f, 0.5f);

        return nebula;
    }
    // ParticleSystem ps = GetComponent<ParticleSystem>();
    //     var col = ps.colorOverLifetime;
    //     col.enabled = true;

    //     Gradient grad = new Gradient();
    //     grad.SetKeys( new GradientColorKey[] { new GradientColorKey(Color.blue, 0.0f), new GradientColorKey(Color.red, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) } );

    //     col.color = grad;

// ParticleSystem.MainModule psMain = particleLauncher.main;
// ParticleSystem.ShapeModule psShape = particleLauncher.shape;
// psShape.radius = 1;
// psMain.startLifetime = 1.0f;
// psMain.startSpeed = 30;
// particleLauncher.Emit (1);
}
