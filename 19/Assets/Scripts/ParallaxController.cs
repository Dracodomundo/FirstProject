using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [SerializeField] private Transform[] layers;
    [SerializeField] private float[] coeff;

    private int LayersCount;
    // Start is called before the first frame update
    void Start()
    {
        LayersCount = layers.Length;

    }

    // Update is called once per frame
    void Update()
    {
       
        for (int i =0; i<LayersCount; i++)
        {
            layers[i].position = transform.position * coeff[i];
        }
    }
}
