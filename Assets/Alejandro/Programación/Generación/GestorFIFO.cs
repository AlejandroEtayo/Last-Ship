
using System.Collections.Generic;
using UnityEngine;


public class GestorFIFO : MonoBehaviour
{
    public static GestorFIFO Instancia;

    private Queue<GameObject> carriles = new Queue<GameObject>();
    private Queue<GameObject> obstaculos = new Queue<GameObject>();

    private void Awake()
    {
        if (Instancia == null)
        {
            Instancia = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // GUARDAR ELEMENTOS
    public void Guardar(GameObject objeto)
    {
        ReciclarElemento elemento =
            objeto.GetComponent<ReciclarElemento>();

        if (elemento == null || elemento.enCola)
            return;

        elemento.enCola = true;

        objeto.SetActive(false);

        if (elemento.tipo == ReciclarElemento.TipoElemento.Carril)
        {
            carriles.Enqueue(objeto);
        }
        else if (elemento.tipo == ReciclarElemento.TipoElemento.Obstaculo)
        {
            obstaculos.Enqueue(objeto);
        }
    }

    // RECUPERAR CARRIL
    public GameObject ObtenerCarril()
    {
        if (carriles.Count == 0)
            return null;

        GameObject objeto = carriles.Dequeue();

        objeto.GetComponent<ReciclarElemento>().enCola = false;

        return objeto;
    }

    // RECUPERAR OBSTACULO
    public GameObject ObtenerObstaculo()
    {
        if (obstaculos.Count == 0)
            return null;

        GameObject objeto = obstaculos.Dequeue();

        objeto.GetComponent<ReciclarElemento>().enCola = false;

        return objeto;
    }

    // INFORMACION DE LAS COLAS
    public int CantidadCarriles()
    {
        return carriles.Count;
    }

    public int CantidadObstaculos()
    {
        return obstaculos.Count;
    }
}
