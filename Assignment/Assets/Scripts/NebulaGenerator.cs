using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NebulaGenerator : MonoBehaviour
{
    ParticleSystemShapeType[] shapes = { ParticleSystemShapeType.Donut, ParticleSystemShapeType.SingleSidedEdge, ParticleSystemShapeType.Circle };
    
    public int colourAmount;
    GradientColorKey[] gradientColorKeys;
    GradientColorKey gradientColorKey;

    public ParticleSystem GenerateNebula(ParticleSystem nebula)
    {
        ParticleSystem.MainModule main = nebula.main;
        ParticleSystem.EmissionModule emission = nebula.emission;
        ParticleSystem.ShapeModule shape = nebula.shape;
        ParticleSystem.VelocityOverLifetimeModule velocityOverLifetime = nebula.velocityOverLifetime;
        ParticleSystem.ColorOverLifetimeModule colourOverLifetime = nebula.colorOverLifetime;

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
        else if(shape.shapeType == ParticleSystemShapeType.SingleSidedEdge)
        {
            shape.radius = Random.Range(30, 50);
        }
        else if(shape.shapeType == ParticleSystemShapeType.Circle)
        {
            shape.radius = Random.Range(2, 10);
        }

        velocityOverLifetime.enabled = true;
        velocityOverLifetime.orbitalX = Random.Range(-0.5f, 0.5f);
        velocityOverLifetime.orbitalY = Random.Range(-0.5f, 0.5f);
        velocityOverLifetime.orbitalZ = Random.Range(-0.5f, 0.5f);

        colourOverLifetime.enabled = true;
        Gradient gradient = new Gradient();
        gradient = getColour(gradient);
        colourOverLifetime.color = new ParticleSystem.MinMaxGradient(gradient);

        return nebula;
    }

    private Gradient getColour(Gradient gradient)
    {
        colourAmount = Random.Range(3, 6);
        gradientColorKeys = new GradientColorKey[colourAmount];

        for(int i = 0; i < colourAmount; i++)
        {
            if(i == 0)
            {
                Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                gradientColorKey = new GradientColorKey(color, (float) i);
            }
            else if(i == colourAmount)
            {
                Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                gradientColorKey = new GradientColorKey(color, 1f);
            }
            else
            {
                Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                gradientColorKey = new GradientColorKey(color, Random.Range(0f, 1f));
            }
            
            gradientColorKeys[i] = gradientColorKey;
        }

        gradient.SetKeys(gradientColorKeys, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(1.0f, 1.0f) });

        return gradient;
    }
}
