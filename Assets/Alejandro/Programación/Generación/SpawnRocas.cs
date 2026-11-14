using UnityEngine;
using UnityEngine.UIElements;

//Función para generar rocas (obstáculos) en el juego
public class SpawnRocas : MonoBehaviour
{
    //Array de prefabs de obstáculos (rocas) se meten los prefabs en el inspector de Unity
    public GameObject[] ObstaculoRoca;
    private GameObject rocaGenerada;
    //limites de posiciones para generar los obstáculos
    [SerializeField] public int posicionInicial;
    [SerializeField] public int posicionFinal;

    //Probabilidad de generar un obstáculo en cada posición (0 a 1)
    [Range(0f, 1f)]
    [SerializeField] public float probabilidadObstaculo;
    void Start()
    {
        GenerarCubos();
    }

    void GenerarCubos()
    {
        // Elegimos al menos una posición libre
        //int posicionLibre = Random.Range(posicionInicial, posicionFinal);

        for (int i = posicionInicial; i <= posicionFinal; i++)
        {
            if (Random.Range(0f, 1f) <= probabilidadObstaculo)
            {
                GameObject prefab = ObstaculoRoca[Random.Range(0, ObstaculoRoca.Length)];
                // Posición X medida desde el extremo izquierdo
                float x = i + 0.5f - 12.5f;

                // Altura de la superficie + mitad del obstáculo
                float y = 0.6f;
                Vector3 posicion = transform.position + transform.right * x + transform.up * y;
                GameObject rocaGenerada = Instantiate(prefab, posicion, transform.rotation);
                rocaGenerada.transform.SetParent(transform, true);
                continue;
            }
            else
            {
                continue;
            }
            //// Garantizamos que exista un hueco
            ////if (i == posicionLibre)
            ////continue;

            //if (Random.value <= probabilidadObstaculo)
            //    {
            //    GameObject prefab = ObstaculoRoca[Random.Range(0, ObstaculoRoca.Length)];

            //    // Posición X medida desde el extremo izquierdo
            //    float x = i + 0.5f - 12.5f;

            //    // Altura de la superficie + mitad del obstáculo
            //    float y = 0.6f;

            //    Vector3 posicion = transform.position + transform.right * x + transform.up * y;

            //    Instantiate(prefab, posicion, transform.rotation);
        }
        Debug.LogWarning("Se han generado los obstáculos");
    }
}
       


 