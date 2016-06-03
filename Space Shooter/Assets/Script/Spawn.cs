using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject insecto;
    public Vector2 spawnValues;
    public int cantidadEnemigos;
    public float tiempoReaparicion;
    public float comienzo;
    public float descanso;
    int rotaciony = 180;
    
	// Use this for initialization
	void Start () {
        StartCoroutine (SpawnWaves());
	}


    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(comienzo);
        while (true)
        {
            for (int j = 0; j < 10; j++)
            {

            }
            for (int i = 0; i <cantidadEnemigos; i++)
            {
                Vector2 posicionSpawn = new Vector2(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y));
                Quaternion rot = transform.rotation;
                float y = rot.eulerAngles.y;
                rot = Quaternion.Euler(0, rotaciony, 0);
                Instantiate(insecto, posicionSpawn, rot);
                yield return new WaitForSeconds(tiempoReaparicion);
            }
            yield return new WaitForSeconds(descanso);
        }
        
    }
}
