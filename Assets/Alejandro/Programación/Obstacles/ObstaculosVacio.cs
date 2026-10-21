using System.Collections.Generic;
using UnityEngine;

public class ObstaculosVacio : MonoBehaviour
{
    public GameObject voids;
    public int numeroDeVacios = 4;

    void Start()
    {
        List<int> posiciones = new List<int>();

        // Creamos 25 posiciones posibles
        for (int i = 0; i < 25; i++)
        {
            posiciones.Add(i);
        }

        // Elegimos posiciones aleatorias sin repetir
        for (int i = 0; i < numeroDeVacios; i++)
        {
            int aleatorio = Random.Range(0, posiciones.Count);
            int posicion = posiciones[aleatorio];

            posiciones.RemoveAt(aleatorio);

            // Distribuimos los vacios a lo largo del carril
            float x = transform.position.x - 12f + posicion;

            Vector3 lugar = new Vector3(
                x,
                transform.position.y + 0.5f,
                transform.position.z
            );

            Instantiate(voids, lugar, Quaternion.identity, transform);
        }
    }
}
