using UnityEngine;

public class World : MonoBehaviour
{
    public int carril = 0;
    public GameObject[] suelo;

    //Cantidad de carriles que se generan al inicio del juego
    public int SueloSpawn;

    private float siguienteZ = 0f;

    private const float longitudCarril = 1f;
    private void Start()
    {
        for (int i = 0; i < SueloSpawn; i++)
        {
            CrearSuelo();
        }
    }

    public void CrearSuelo()
    {
        if (suelo == null || suelo.Length == 0)
            return;

        Vector3 posicion = new Vector3(
            0f,
            0f,
            carril * longitudCarril
        );

        GameObject nuevoCarril = null;

        // Intentar recuperar un carril reciclado
        if (GestorFIFO.Instancia != null)
        {
            nuevoCarril = GestorFIFO.Instancia.ObtenerCarril();
        }

        // Si no hay carriles reciclados, crear uno nuevo
        if (nuevoCarril == null)
        {
            GameObject prefab = suelo[Random.Range(0, suelo.Length)];

            nuevoCarril = Instantiate(
                prefab,
                posicion,
                Quaternion.identity
            );
        }
        else
        {
            nuevoCarril.transform.position = posicion;
            nuevoCarril.transform.rotation = Quaternion.identity;
            nuevoCarril.SetActive(true);
        }

        carril++;
    }

    public GameObject ObtenerOCrearCarril(Vector3 posicionGeneracion, GameObject prefabCarril)
    {
        GameObject carril = GestorFIFO.Instancia.ObtenerCarril();

        if (carril == null)
        {
            carril = Instantiate(prefabCarril);
        }

        carril.transform.position = posicionGeneracion;
        carril.transform.rotation = Quaternion.identity;
        carril.SetActive(true);

        return carril;
    }
}
