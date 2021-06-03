using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponentInParent<PlatformSegment>() is PlatformSegment)
        {
            other.GetComponentInParent<Platform>().Break();
        }
    }
}
