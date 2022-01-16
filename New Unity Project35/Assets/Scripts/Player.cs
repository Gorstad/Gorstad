using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
     [SerializeField] float Speed = 4.5f;
     [SerializeField] float XClamp = 4f;
     [SerializeField] float YClamp = 2.5f;
     [SerializeField] float XRotFactor = -10;
     [SerializeField] float YRotFactor = 10;
     [SerializeField] float xMoveRot = 5;
     [SerializeField] float yMoveRot = 5;
     [SerializeField] float zMoveRot = 5;
     [SerializeField] GameObject [] guns;
     
     bool ControlEnabled = true;
   
     float xMove;
     float yMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(ControlEnabled)
       {
       MoveShip();
       RotateShip();
       Fire();
       }
       
    }
    void MoveShip()
    {
       xMove = CrossPlatformInputManager.GetAxis("Horizontal");
       yMove = CrossPlatformInputManager.GetAxis("Vertical");
       float xOffset = xMove * Speed * Time.deltaTime;
       float yOffset = yMove * Speed * Time.deltaTime;
       
       float newXPos = transform.localPosition.x + xOffset;
       float clampXPos = Mathf.Clamp(newXPos, -XClamp, XClamp);
       float newYPos = transform.localPosition.y + yOffset;
       float clampYPos = Mathf.Clamp(newYPos, -YClamp, YClamp);


		transform.localPosition = new Vector3(clampXPos,clampYPos,transform.localPosition.z);
    }
    void RotateShip()
    {
       float xRot = transform.localPosition.y * XRotFactor + yMove * xMoveRot;
       float yRot = transform.localPosition.x * YRotFactor + xMove * yMoveRot;
       float zRot =  xMove * zMoveRot;
       transform.localRotation = Quaternion.Euler(xRot,yRot,zRot);
    }
     void Fire()
     {
        if(CrossPlatformInputManager.GetButton("Fire"))
        {
           ActiveLazer();
        }
        else
        {
           DeactiveLazer();
        }
     }
     void ActiveLazer()
     {
        foreach(GameObject gun in guns)
        {
           gun.GetComponent<ParticleSystem>().enableEmission = true;
        }
     }
     void DeactiveLazer()
     {
        foreach(GameObject gun in guns)
        {
           gun.GetComponent<ParticleSystem>().enableEmission = false;
        }
     }
    void OnPlayerDeath()
    {
       ControlEnabled = false;
     
    }
}
