using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    public LevelManager LM;

    private void OnTriggerEnter(Collider other)
    {
        if (LM != null)
        {
            LM.PassLevel();
        }

    }

}
