using UnityEngine;

public class SpanAsteroidesAleatoriedadplus : MonoBehaviour
{
    //Variable para la lista de objetos a generar
    public GameObject[] objetos;

    public Transform LugarSpawn;
    // Punto donde aparecerá el objeto

    private GameObject AsteroideGenerado;

    public float tiempoMinimo = 7.0f;
    public float tiempoMaximo = 10.0f;

    private float tiempoRestante;
    private void Start()
    {
        GenerarAsteroide();

        tiempoRestante = Random.Range(tiempoMinimo, tiempoMaximo);
    }

    private void Update()
    {
        tiempoRestante -= Time.deltaTime;

        if (tiempoRestante <= 0)
        {
            GenerarAsteroide();

            tiempoRestante = Random.Range(tiempoMinimo, tiempoMaximo);
        }
    }


    public void GenerarAsteroide()
    {
        // Eliminar el asteroide anterior
        if (AsteroideGenerado != null)
        {
            Destroy(AsteroideGenerado);
            AsteroideGenerado = null;
        }

        if (objetos == null || objetos.Length == 0)
        {
            Debug.LogWarning("No hay objetos para generar.");
            return;
        }

        if (LugarSpawn == null)
        {
            Debug.LogWarning("Falta asignar LugarSpawn en " + gameObject.name);
            return;
        }



        int array = Random.Range(0, objetos.Length);
        AsteroideGenerado = Instantiate(objetos[array], LugarSpawn.position, LugarSpawn.rotation);

        AsteroideGenerado.transform.SetParent(transform, true);
    }
}
