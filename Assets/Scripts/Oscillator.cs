using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 2f;


    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveObstacles();
    }

    void MoveObstacles()
    {
        if (period <= Mathf.Epsilon) { return; }

        float cycles = Time.time / period; // continually growning over time
        const float tau = Mathf.PI * 2; // constant 6.283

        float rawSinWave = Mathf.Sin(cycles * tau); //result -1 to 1

        movementFactor = (rawSinWave + 1f) / 2f; // recalculated to make rawSinWave go from 0 to 1

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
