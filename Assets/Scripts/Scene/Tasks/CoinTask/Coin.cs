using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public LevelManager levelManager;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.GetComponentInParent<PlayerController>() != null)
        {
            AddCoin();
            DestroyCoin();
        }
    }
    private void AddCoin()
    {
        if (levelManager.coinTask != null)
        {
            levelManager.coinTask.PlayerCoins ++ ;
            levelManager.coinTask.setComplete();
        }

        
    }

    private void DestroyCoin()
    {
        GameObject.Destroy(gameObject);
    }
}
