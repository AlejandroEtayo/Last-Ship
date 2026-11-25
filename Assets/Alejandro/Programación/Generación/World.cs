using UnityEngine;

public class World : MonoBehaviour
{
    [SerializeField] private int carril = 0;
    public GameObject[] suelo;
    public float[] probabilidadesCadaSuelo;  
    //Este array es para crear los primeros suelos donde el jugador aprende a jugar
    public GameObject[] sueloVacio;

    //Cantidad de carriles que se generan al inicio del juego
    [SerializeField] private int SueloSpawn;
    
    //Falta hacer una función donde la dificultad sea un´más asequible y visualmente clara para el jugador: un ratio de spawn de carriles gestionado pro probabilidad
    //Hacer más variantes de carril lunar para notar que es el carril más seguro
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
            GameObject[] TiposueloSelec;

            if (carril < 5) 
            {
                TiposueloSelec = sueloVacio;
            }

            else
            {
                TiposueloSelec = suelo;
            }

            if (TiposueloSelec == null || TiposueloSelec.Length == 0)
                return;

            GameObject prefab = ElegirCarril();

            if (prefab == null)
                return;

            nuevoCarril = Instantiate(prefab, posicion, Quaternion.identity);
        }
        else
        {
            nuevoCarril.transform.position = posicion;
            nuevoCarril.transform.rotation = Quaternion.identity;
            nuevoCarril.SetActive(true);
        }


        //Generar asteroides en el carril 
        SpawnEnemigos generador =
           nuevoCarril.GetComponent<SpawnEnemigos>();

        if (generador != null)
        {
            generador.GenerarObjeto();
        }

        carril++;
    }

    public GameObject ObtenerOCrearCarril(Vector3 posicionGeneracion, GameObject prefabCarril)
    {
        GameObject nuevoCarril = null;

        if (GestorFIFO.Instancia != null)
        {
            nuevoCarril = GestorFIFO.Instancia.ObtenerCarril();
        }

        if (nuevoCarril == null)
        {
            nuevoCarril = Instantiate(prefabCarril);
        }

        nuevoCarril.transform.position = posicionGeneracion;
        nuevoCarril.transform.rotation = Quaternion.identity;
        nuevoCarril.SetActive(true);

        // Generar también al recuperar por este método
        SpawnEnemigos generador =
            nuevoCarril.GetComponent<SpawnEnemigos>();

        if (generador != null)
        {
            generador.GenerarObjeto();
        }

        return nuevoCarril;
    }

    public GameObject ElegirCarril()
    {
        if (suelo == null || suelo.Length == 0)
            return null;

        if (probabilidadesCadaSuelo == null || probabilidadesCadaSuelo.Length != suelo.Length)
        {
            Debug.LogError("Los arrays de suelos y las probabilidades e estos no coinciden");
            return null;
        }

        float sumaTotal = 0f;

        foreach (float probabilidad in probabilidadesCadaSuelo)
        {
            sumaTotal += Mathf.Max(0f, probabilidad);
        }

        if (sumaTotal <= 0f)
        {
            return null;
        }

        //Elige un valor aleatorio entre 0 y la suma
        float NumAleatorio = Random.Range(0f, sumaTotal);

        for (int i = 0; i < suelo.Length; i++)
        {
            NumAleatorio -= Mathf.Max(0f, probabilidadesCadaSuelo[i]);

            if (NumAleatorio < 0f)
            {
                return suelo[i];
            }
        }

        return suelo[suelo.Length - 1];
    }
}

