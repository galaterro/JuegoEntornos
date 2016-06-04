using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject enemigo1;
    public GameObject enemigo2;
    public Vector2 spawnValues;
    public int cantidadEnemigos;
    public float tiempoReaparicion;
    public float comienzo;
    public float descanso;
    int numeroOleada=1;
    int rotacionyEnemigo1 = 180;
    int rotacionzEnemigo2 = 90;
    
    
	// Use this for initialization
	void Start () {
        StartCoroutine (SpawnWaves());
	}


    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(comienzo);
        while (true)
        {
            if (numeroOleada == 1)
            {
                for (int i = 0; i < cantidadEnemigos; i++)
                {
                    Vector2 posicionSpawn = new Vector2(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y));
                    Quaternion roty = transform.rotation;
                    roty = Quaternion.Euler(0, rotacionyEnemigo1, 0);
                    Instantiate(enemigo1, posicionSpawn, roty);
                    yield return new WaitForSeconds(tiempoReaparicion);
                    
                }
                numeroOleada++;
                yield return new WaitForSeconds(descanso);
            }
            else if (numeroOleada == 2)
            {
                for (int i = 0; i < cantidadEnemigos; i++)
                {
                    Vector2 posicionSpawn = new Vector2(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y));
                    Quaternion roty = transform.rotation;
                    roty = Quaternion.Euler(0, rotacionyEnemigo1, 0);
                    Quaternion rotz = transform.rotation;
                    //float z = rotz.eulerAngles.z;
                    rotz = Quaternion.Euler(0, 0, rotacionzEnemigo2);
                    Instantiate(enemigo1, posicionSpawn, roty);
                    Instantiate(enemigo2, posicionSpawn, rotz);
                    yield return new WaitForSeconds(tiempoReaparicion);
                }
            }
            numeroOleada++;
            yield return new WaitForSeconds(descanso);
        }
        
    }
}
