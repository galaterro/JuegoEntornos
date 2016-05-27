using UnityEngine;
using System.Collections;

public class DestruccionPorLimite : MonoBehaviour {

    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
