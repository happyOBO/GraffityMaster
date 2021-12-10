using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayController : MonoBehaviour
{
    Material _material;
    void Start()
    {
        _material = gameObject.GetComponent<Renderer>().material;
        Debug.Log(_material.mainTexture);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
