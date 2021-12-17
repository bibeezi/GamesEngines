# Procedurally Generated Art on Planets

**Name:** Bianca Claudette Palileo

**Student Number:** C18326906

**Class Group:** DT228/4 or TU856/4


# Description of the project
The project shows randomized planets with all different terrain and designs, all procedurally generated.

The picture painted in code is about an astronaut wandering space and seeing beautiful planets in the void.

The universe is contained in a galaxy sphere with stars and contains nebulas.

<!-- The planets are to orbit around each other in a 3D environment and spin. -->

## Video
[Recording]()


# Instructions for use
The player can simply let the astronaut guide themselves around the universe.
Otherwise, the player can press space and control the astronaut slowly around with W, A, S, D keys and look around with the mouse.

*The movement is quite slow because it is hard to move in space and the astronaut uses velocity to move through space*


# How it works
## Astronaut
The astronaut has a toggle between moving on their own (AI) and controlling themselves (player controls) using the [SPACE] key.
##### AstroToggle.cs
```cs
void Update()
{
    if(Input.GetKeyUp("space"))
    {
        StartCoroutine(delayToggle());
    }
}
```

A coroutine is used to allow for the appearance of space movement (slow movement)
```cs
IEnumerator delayToggle()
{
    yield return new WaitForSeconds(1);
    
    controller.enabled = !controller.enabled;
    movement.enabled = !movement.enabled;
}
```


The astronaut moves on it's own by getting a walkpoint, rotating and moving towards that walkpoint, when the walkpoint is close enough to the astronaut or the astronaut is finished rotating to the walkpoint, the walkpoint changes.
##### AstroMovement.cs
```cs
void Update()
{   
    rigidbody.AddForce(transform.forward * speed * Time.deltaTime);

    if (Vector3.Angle(walkpoint - transform.position, transform.forward) < 5f)
    {
        walkpoint = GetWalkPoint();
    }
    else
    {
        transform.localRotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, walkpoint - transform.position, lookSpeed * Time.deltaTime, 0.0f), Vector3.up);
    }

    Vector3 distanceToWalkpoint = transform.position - walkpoint;

    if(distanceToWalkpoint.magnitude < 5f)
    {
        walkpoint = GetWalkPoint();
    }
}
```
The walkpoint is set by using Random.Range() on the x, y and z co-ordinates.
```cs
private Vector3 GetWalkPoint()
{
    // Calculate random point in range
    float randomX = Random.Range(-walkPointRange, walkPointRange);
    float randomY = Random.Range(-walkPointRange, walkPointRange);
    float randomZ = Random.Range(-walkPointRange, walkPointRange);

    return new Vector3(randomX, randomY, randomZ);
}
```
The astronaut can be controlled by the character by using the W, A, S, D keys and look around the scene using the mouse.
##### AstroController.cs
```cs
void Update()
{
    float mouseX = Input.GetAxis("Mouse X");
    float mouseY = Input.GetAxis("Mouse Y");
    float x = Input.GetAxis("Horizontal");
    float z = Input.GetAxis("Vertical");

    angleX = angleX + (mouseX % 1);
    angleY = angleY + (mouseY % 1);
    
    transform.localRotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-angleY, angleX, 0), lookSpeed * Time.deltaTime);

    if(x > 0)
    {
        rigidbody.AddForce(transform.right * speed * Time.deltaTime);
    }
    else if(x < 0)
    {
        rigidbody.AddForce(-transform.right * speed * Time.deltaTime);
    }
    if(z > 0)
    {
        rigidbody.AddForce(transform.forward * speed * Time.deltaTime);
    }
    else if(z < 0)
    {
        rigidbody.AddForce(-transform.forward * speed * Time.deltaTime);
    }
}
```
### Galaxy
The background consists of a particle system for the stars and a new camera set the Environment's Background Type to be Solid Color and Background to black, to create the void. Along with this, the new camera had to contain a script to follow the rotation of the main camera, and the main camera's Environment's Background Type also has to be Solid Color and Background to black.
##### Follow.cs
```cs
void Update()
{
    transform.rotation = target.rotation;
}
```
### Nebulas
To create the nebulas, a particle system was used and the settings were changed using the respective ParticleSystem modules. The nebulas have three distinct shapes; Donut, SingleSidedEdge and Circle. The shape was chosen for a nebula using the Random.Range() on the distinct shapes. GenerateNebula() returns a nebula randomized settings for the radius, orbitalX, orbitalY and orbitalZ velocities and, the amount of colours and colours.
##### NebulaGenerator.cs
```cs
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
```
The Gradient for the nebula is set by creating between 3 to 6 GradientColorKeys using the Random.Range(), and also using Random.Range() function to create a new Color in the RGB parameters for each GradientColorKey. The GradientColorKeys, and 2 GradientAlphaKeys at 100% to the start and end of the gradient are then set to the gradient's keys. Lastly the gradient is set to the gradient in the nebula's ColorOverLifetime module's color parameter.
```cs
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
```
The nebula spawner creates a specified amount of nebulas (10) in the scene and Instantiates() the nebulas in a random position using the Random.Range() for the x, y and z co-ordinates.
###### NebulaSpawner.cs
```cs
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
```
This spawner is different to the planets because nebulas can only spawn outside of the universe which is the size of a cube of scale (100, 100, 100). The positions were chosen by choosing either x, y or z co-ordinate to take a value above the universe's respective scale in addition to an offset, and the other co-ordinates will take any value between the universe's scale and it's negative value.
```cs
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
```
### Planets
*Shape*
*Terrain*
*Colour*
*Spawner*

# List of classes/assets in the project

| Class/asset | Source |
|-----------|-----------|
| AstroController.cs | Self written |
| AstroMovement.cs | Self written |
| AstroToggle.cs | Self written |
| ColourGenerator.cs | From [Procedural Planets (E04 shader)](https://www.youtube.com/watch?v=itnLOlQ2QFo) |
| ColourSettings.cs | Modified [Procedural Planets (E02 settings editor)](https://www.youtube.com/watch?v=LyV7cEQyZMk&t=1s) |
| FollowCamera.cs | Self written |
| Heights.cs | From [Procedural Planets (E04 shader)](https://www.youtube.com/watch?v=itnLOlQ2QFo) |
| NebulaGenerator.cs | Self written |
| NebulaSpawner.cs | Self written |
| Noise.cs | From [Procedural Planets (E03 layered noise)](https://www.youtube.com/watch?v=uY9PAcNMu8s) |
| NoiseFilter.cs | From [Procedural Planets (E03 layered noise)](https://www.youtube.com/watch?v=uY9PAcNMu8s) |
| NoiseSettings.cs | Modified from [Procedural Planets (E03 layered noise)](https://www.youtube.com/watch?v=uY9PAcNMu8s) |
| Planet.cs | Modified from [Procedural Planets (E01 the sphere)](https://www.youtube.com/watch?v=QN39W020LqU) |
| PlanetSpawner.cs | Self written |
| TerrainFaces.cs | From [Procedural Planets (E01 the sphere)](https://www.youtube.com/watch?v=QN39W020LqU) |
| TerrainGenerator.cs | From [Procedural Planets (E02 settings editor)](https://www.youtube.com/watch?v=LyV7cEQyZMk&t=1s) |
| TerrainShapeSettings.cs | From [Procedural Planets (E02 settings editor)](https://www.youtube.com/watch?v=LyV7cEQyZMk&t=1s) |
| PlanetEditor.cs | From [Procedural Planets (E02 settings editor)](https://www.youtube.com/watch?v=LyV7cEQyZMk&t=1s) |


# References:
* [Procedural Planets (E01 the sphere)](https://www.youtube.com/watch?v=QN39W020LqU)
* [Procedural Planets (E02 settings editor)](https://www.youtube.com/watch?v=LyV7cEQyZMk&t=1s)
* [Procedural Planets (E03 layered noise)](https://www.youtube.com/watch?v=uY9PAcNMu8s)
* [Procedural Planets (E04 shader)](https://www.youtube.com/watch?v=itnLOlQ2QFo)

# What I am most proud of in the assignment:
I am most proud of generating the nebulas' and planets' shapes and colours randomly and spawning them in random points in the galaxy range using scripts to do so, rather than changing values in the editors themselves.

I am also proud of this project because it is my first Unity project.

Lastly, I am proud of being able to incorporate code from references and link them to my own work (where I learned and used, inheritance, Unity classes, coroutines, spawners, character controls and physics, particle systems, procedural generation and simplex noise!) to make a cool visual project.


# Proposal:
<!-- For my Games Engines project, I would like to build a universe that uses procedurally generated art for the planet textures. -->
For my Games Engines project, I would like to build a universe that use procedurally generated terrain, colour and textures for the planet.

The user will be able to:
<!-- * reset/create a new universe with a button. -->
<!-- * change how the universe would look and move by changing the list of variables using scrollbars. -->
* move through the universe as an astronaut and look around to see the nebulas, stars and planets.
* float through the universe by toggling controls.

## Example:
[Planets Asset Example](https://assetstore.unity.com/packages/3d/environments/sci-fi/procedural-planets-95581)

![Procedurally Generated Planet](https://assetstorev1-prd-cdn.unity3d.com/package-screenshot/b8a6573a-7541-4bf2-8c00-78c37f0ad0a4.webp)

<!-- ### Procedurally Generated Art Examples:
![ProcedurallyGeneratedArt1](https://user-images.githubusercontent.com/44236242/138449536-ba7e1356-97f7-4d1c-82ef-cd05056b827b.jpg)
![ProcedurallyGeneratedArt2](https://user-images.githubusercontent.com/44236242/138449548-31a6e617-bf43-42ed-8819-54f43aa0cd3f.jpg)
![ProcedurallyGeneratedArt3](https://user-images.githubusercontent.com/44236242/138449556-1b5c8b1e-c6c1-4cac-b1e4-889bc0af82fd.png) -->
