using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorFIFO : MonoBehaviour
{
    public static GestorFIFO Instancia;

    public float tiempoReciclaje = 5f;

    private Queue<GameObject> carriles = new Queue<GameObject>();
    private Queue<GameObject> obstaculos = new Queue<GameObject>();

    private void Awake()
    {
        Instancia = this;
    }

    public void Guardar(GameObject objeto)
    {
        ElementoReciclable elemento =
            objeto.GetComponent<ElementoReciclable>();

        if (elemento == null || elemento.enCola)
            return;

        elemento.enCola = true;
        objeto.SetActive(false);

        if (elemento.tipo == ElementoReciclable.TipoElemento.Carril)
            carriles.Enqueue(objeto);
        else
            obstaculos.Enqueue(objeto);
    }

    public GameObject ObtenerCarril()
    {
        if (carriles.Count == 0)
            return null;

        GameObject objeto = carriles.Dequeue();
        objeto.GetComponent<ElementoReciclable>().enCola = false;

        return objeto;
    }

    public GameObject ObtenerObstaculo()
    {
        if (obstaculos.Count == 0)
            return null;

        GameObject objeto = obstaculos.Dequeue();
        objeto.GetComponent<ElementoReciclable>().enCola = false;

        return objeto;
    }

    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(tiempoReciclaje);

            // Aquí se pueden consultar las colas y registrar
            // cuántos elementos hay disponibles para reutilizar.
            Debug.Log(
                "Carriles en FIFO: " + carriles.Count +
                " | Obstáculos en FIFO: " + obstaculos.Count
            );
        }
    }
}
