using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class IluminationController : MonoBehaviour
{
    public Volume volume;

    private bool change;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainCamera") {
            change = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "MainCamera")
        {
            change = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (change)
        {
            volume.weight = Mathf.Clamp(volume.weight + Time.deltaTime, 0f, 1f);
        }
        else {
            volume.weight = Mathf.Clamp(volume.weight - Time.deltaTime, 0f, 1f);
        }
    }
}
