﻿using UnityEngine;
using System.Collections;

public class Mover_Nave : MonoBehaviour {


    // Creamos variables para las teclas
    public KeyCode up; // Hace que la nave suba
    public KeyCode down; // Hace que la nave baje
    public KeyCode right; // Hace que la nave se mueva a la derecha
    public KeyCode left; // Hace que la nave se mueva a la izquierda
    public KeyCode disparar; // Hace que la nave dispare


    float speed;  // Variable que controla la velocidad
    float finalSpeed; // Es la velocidad final

    //public GameObject shot; // Crea un objeto de tipo shot que se crea al disparar y muestra una bala
    //public Transform shotSpawn; // Es el spawn del disparo
   // public float fireRate; // Es la variable de la velocidad de disparos
    //private float nextFire; // Es la variable que calcula el siguiente disparo



    //Copiao

    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);

    public GameObject bulletPrefab;
    int bulletLayer;

    public float fireDelay = 0.25f;
    float cooldownTimer = 0;

    

    // Use this for initialization
    void Start()
    {
        speed = 0.3f; // Es la velocidad a la que se mueve la nave

    }

    // Update is called once per frame
    void Update()
    {
        mover();
        bulletLayer = gameObject.layer;
        // dispararNave();
    }


    // Función que coge la tecla pulsada y limita que la nave se salga de la pantalla
    public void mover()
    {
        if (Input.GetKey(right))
        {
            if (transform.localPosition.x > 7.99)
            {
                finalSpeed = 0;
            }
            else
            {
                finalSpeed = speed;
            }
            transform.Translate(finalSpeed,0,0);
        }
        if (Input.GetKey(left))
        {
            if (transform.localPosition.x < -8.07)
            {
                finalSpeed = 0;
            }
            else
            {
                finalSpeed = speed;
            }
            transform.Translate(-finalSpeed,0,0);
        }
        if (Input.GetKey(up))
        {
            if (transform.localPosition.y > 4.35)
            {
                finalSpeed = 0;
            }
            else
            {
                finalSpeed = speed;
            }
            transform.Translate(0, finalSpeed, 0);
        }
        if (Input.GetKey(down))
        {
            if (transform.localPosition.y < -4.54)
            {
                finalSpeed = 0;
            }
            else
            {
                finalSpeed = speed;
            }
            transform.Translate(0,-finalSpeed, 0);
        }

        //Copiao

        cooldownTimer -= Time.deltaTime;

        if (Input.GetButton("Fire1") && cooldownTimer <= 0)
        {
            // SHOOT!
            cooldownTimer = fireDelay;

            Vector3 offset = transform.rotation * bulletOffset;

            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bulletGO.layer = bulletLayer;
        }

    }
    // Funcion que hace que dispare la nave

    /* public void dispararNave()
     {
         if (Input.GetKey(disparar) && Time.time > nextFire)
         {
             nextFire = Time.time + fireRate;
             Instantiate(shot, shotSpawn.position, shotSpawn.rotation); //Para que salgan varios disparos, hay que instanciarlo, pasandole un objeto, la posicion y la rotacion.


         }
     }*/

}