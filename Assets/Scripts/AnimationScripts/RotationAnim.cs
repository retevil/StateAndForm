using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationAnim : MonoBehaviour
{

    public float animationSpeed = 100f;

    

    private void Start()
    {
        
    }
    private void LateUpdate()
    {
        transform.Rotate(0, animationSpeed * Time.deltaTime, 0,Space.World);
    }

}
