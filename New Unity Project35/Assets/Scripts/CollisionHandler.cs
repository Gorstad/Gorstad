using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
   [SerializeField] float LoadLevelDelay;
   [SerializeField] GameObject ExplosionFX;
    
     void OnTriggerEnter(Collider other)
    {
       print("HIt");
       StartDeath();
       ExplosionFX.SetActive(true);
       Invoke ("ReloadLevel",LoadLevelDelay);
    } 
     void StartDeath()
    {
     SendMessage("OnPlayerDeath");
     
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(1);
    }

}
