using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoundaryScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponentInParent<PlayerController>() != null)
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
