using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDOLScript : MonoBehaviour
{
    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
