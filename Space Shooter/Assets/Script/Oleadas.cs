using UnityEngine;
using System.Collections;

public class Oleadas : MonoBehaviour
{

    public enum SpawnState { SPAWNING, WAITING, COUNTIG };
    [System.Serializable]
    public class Wave
    {
        public string nombreOleada;
        public Transform enemigo;
        public int numeroEnemigos;
        public float velocidadAparicion;
    }

    public int rotacionyEnemigo1 = 180;
    public int rotacionzEnemigo2 = 90;
    public Wave[] waves;
    private int siguienteOleada = 0;

    public Transform[] puntosSpawn;

    public float tiempoEntreOleadas = 5f;
    private float cuentraAtrasOleada;

    private float buscadorCuentaAtras = 1f;

    private SpawnState state = SpawnState.COUNTIG;

    void Start()
    {
        cuentraAtrasOleada = tiempoEntreOleadas;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == SpawnState.WAITING)
        {
            if (!enemigosVivos())
            {
                OleadaCompleta();
            }
            else
            {
                return;
            }
        }

        if (cuentraAtrasOleada <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnOleada(waves[siguienteOleada]));
            }
        }
        else
        {
            cuentraAtrasOleada -= Time.deltaTime;
        }
    }

    void OleadaCompleta()
    {
        state = SpawnState.COUNTIG;
        cuentraAtrasOleada = tiempoEntreOleadas;
        if (siguienteOleada + 1 > waves.Length - 1)
        {
            siguienteOleada = 0;
            Debug.Log("Has completado todas las oleadas");
        }
        else
        {
            siguienteOleada++;
        }
    }

    bool enemigosVivos()
    {
        buscadorCuentaAtras -= Time.deltaTime;
        if (buscadorCuentaAtras <= 0f)
        {
            buscadorCuentaAtras = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy1") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnOleada(Wave _wave)
    {
        state = SpawnState.SPAWNING;
        for (int i = 0; i < _wave.numeroEnemigos; i++)
        {
            SpawnEnemigos(_wave.enemigo);
            yield return new WaitForSeconds(1f / _wave.velocidadAparicion);
        }
        state = SpawnState.WAITING;
        yield break;
    }

    void SpawnEnemigos(Transform _enemy)
    {    
            Quaternion roty = transform.rotation;
            roty = Quaternion.Euler(0, rotacionyEnemigo1, 0);
            Transform _sp = puntosSpawn[Random.Range(0, puntosSpawn.Length)];
            Instantiate(_enemy, _sp.position, roty);       
    }
}