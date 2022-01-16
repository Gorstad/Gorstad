using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys : MonoBehaviour
{
  [SerializeField] GameObject DeathFx;
  [SerializeField] Transform parent;
  [SerializeField] int ScoreAdd;
  [SerializeField] int HP = 2;
  Score scoreBoard;
    void Start()
    {
      scoreBoard = FindObjectOfType<Score>();
      AddNonTriggerCollider();  
    }

    // Update is called once per frame
    void AddNonTriggerCollider()
    {
       Collider boxCollider = gameObject.AddComponent<BoxCollider>();
    }
    void OnParticleCollision(GameObject other)
    {
      
     HP--;
     if(HP<=0)
     {
       Death();
     }
       
    }
    void Death()
    {
       scoreBoard.ScoreHit(ScoreAdd);
       GameObject fx = Instantiate(DeathFx,transform.position, Quaternion.identity);
       fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
