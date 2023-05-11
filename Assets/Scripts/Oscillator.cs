using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 posStart;
    [SerializeField] Vector3 vecMove;
    [SerializeField] [Range(0,1)] float fMoveFac;
    [SerializeField] float period = 2f;

    // Start is called before the first frame update
    void Start()
    {
        posStart = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon)
        {
            return;
        }
        
        float cycles = Time.time / period;

        const float tau = Mathf.PI * 2; // constant val of 2*3.14159
        float rawSinWave = Mathf.Sin(cycles * tau); // -1 -> 1
        
        fMoveFac = (rawSinWave + 1f)/2f; // recalculated 0 -> 1

        Vector3 offset = vecMove *  fMoveFac;
        transform.position = posStart + offset;
    }
}
