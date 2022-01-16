using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detonation : MonoBehaviour
{
  [SerializeField] GameObject BoomFx;
 void OnTriggerEnter(Collider other)
 {
   print("boom");
   BoomFx.SetActive(true);
  Invoke("MineDet",0.27f);
 }
 void MineDet()
 {
 Destroy(gameObject);
 }
}
