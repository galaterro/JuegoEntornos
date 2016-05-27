using UnityEngine;
using System.Collections;

public class Daño_Por_Colision : MonoBehaviour {

    void OnCollisionEnter2D()
    {
        Debug.Log("Collision!");
    }

    void OnTriggerEnter2D()
    {
        Debug.Log("Trigger!");
    }
}
