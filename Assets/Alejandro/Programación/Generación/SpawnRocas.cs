using UnityEngine;

//Función para generar rocas (obstáculos) en el juego
public class SpawnRocas : MonoBehaviour
{
    public GameObject[] ObstaculoRoca;
    private GameObject rocaGenerada;
    public int posicionInicial = 5;
    public int posicionFinal = 15;

    [Range(0f, 1f)]
    public float probabilidadObstaculo = 0.5f;

    void Start()
    {
        GenerarCubos();
    }

    void GenerarCubos()
    {
        // Elegimos al menos una posición libre
        int posicionLibre = Random.Range(posicionInicial, posicionFinal + 1);

        for (int i = posicionInicial; i <= posicionFinal; i++)
        {
            // Garantizamos que exista un hueco
            if (i == posicionLibre)
                continue;

            // Decidimos aleatoriamente si generar un obstáculo
            if (Random.value <= probabilidadObstaculo)
            {
                GameObject prefab = ObstaculoRoca[Random.Range(0, ObstaculoRoca.Length)];

                Vector3 posicionLocal = new Vector3(
                    i - 12.5f,
                    0.65f,
                    0
                );

                GameObject cubo = Instantiate(prefab, transform.TransformPoint(posicionLocal), Quaternion.identity);
                cubo.transform.localScale = prefab.transform.lossyScale;
                rocaGenerada = cubo;
            }
        }
    }
}
 