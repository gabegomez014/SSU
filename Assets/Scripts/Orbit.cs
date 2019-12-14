using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{

    [SerializeField]
    private float a = 10;       // a is for the semi-major axis, which defines the size of the orbit
    [SerializeField]
    private float e = 10;       // e is for the eccentricity, which defines the shape of the orbit
    [SerializeField]
    private float v = 10;       // v is for the true anamoly, which is the angle between the current position of the orbiting object and the location in orbit at the periapsis
    [SerializeField]
    private float perihelion = 10; // The perihelion is the closest distance a planet is from it's sun (in 10^6 km)
    [SerializeField]
    private float meanOrbitalVelocity = 10;     // The average orbital velocity in km/s
    [SerializeField]
    private float anamolyIncrement = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, perihelion);
    }

    // Update is called once per frame
    void Update()
    {
        // This is currently being implemented with Keplerian orbit equations
        // For the moment, doing this without any angle on the orbit
        float numerator = a * (1 - Mathf.Pow(e, 2));
        float denominator = 1 + e * (Mathf.Cos(v));
        float distance = numerator / denominator;

        transform.position = new Vector3(transform.position.x, transform.position.y, distance);
        print("The distance is " + distance);

        v += anamolyIncrement;

        if (v >= 360)
        {
            v = 0;
        }
    }
}
