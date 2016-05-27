using UnityEngine;
using System.Collections;

public class mover_Disparo : MonoBehaviour {

    float speed = 30f;

    /*
	// Use this for initialization
	void Start () {
        //GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
	*/
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(speed * Time.deltaTime, 0, 0);
        pos += transform.rotation * velocity;
        transform.position = pos;
	}
}
