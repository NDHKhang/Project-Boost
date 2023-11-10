using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinner : MonoBehaviour
{
    [SerializeField] float spinnerY = 0.5f;

    // Update is called once per frame
    void Update()
    {
       // float spinnerY = 0.5f;
        transform.Rotate(0, spinnerY, 0);
    }
}
