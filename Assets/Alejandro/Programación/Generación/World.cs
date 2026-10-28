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

        GameObject prefab = suelo[Random.Range(0, suelo.Length)];

        // El centro de cada carril se sitúa a una unidad del anterior.
        Vector3 posicion = new Vector3(
            0f,
            0f,
            carril * longitudCarril
        );

        Instantiate(prefab, posicion, Quaternion.identity);

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
