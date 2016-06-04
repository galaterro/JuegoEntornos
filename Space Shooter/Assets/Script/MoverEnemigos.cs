using UnityEngine;
using System.Collections;

public class MoverEnemigos : MonoBehaviour {

    public float interval;
    float speed = 10f;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        mover();
        morir();
	}
    void mover()
    {
        
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(speed * Time.deltaTime,0, 0);
        pos += transform.rotation * velocity;
        
        transform.position = pos;
        //Destroy(gameObject, interval);
    
    }

    void morir()
    {
        Destroy(gameObject, interval);
    }
}
