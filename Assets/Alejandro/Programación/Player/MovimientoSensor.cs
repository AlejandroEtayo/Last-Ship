using System.Collections.Generic;
using UnityEngine;

public class MovimientoSensor : MonoBehaviour
{
    private HashSet<Collider> obstaculos = new HashSet<Collider>();

    public bool bloqueado
    {
        get { return obstaculos.Count > 0; }
    }
    private bool EsJugador(Transform objeto)
    {
        while (objeto != null)
        {
            if (objeto.CompareTag("Player"))
                return true;
            objeto = objeto.parent;
        }
        return false;   
    }
    private bool EsObstaculo(Transform objeto)
    {
        while (objeto != null)
        {
            if (objeto.CompareTag("Obstaculo"))
                return true;
            objeto = objeto.parent;
        }
        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Sensor " + name +
            " detecta: " + other.name +
            " | Tag: " + other.tag);

        if (EsJugador(other.transform))
            return;

        if (!EsObstaculo(other.transform))
            return; 

            obstaculos.Add(other);

            Debug.Log("Obstáculo detectado: " + other.name);
    }


    private void OnTriggerExit(Collider other)
    {
        obstaculos.Remove(other);
    }

    private void OnDisable()
    {
        obstaculos.Clear();
    }
    //private HashSet<Collider> obstaculos = new HashSet<Collider>();

    //    public bool bloqueado
    //    {
    //        get { return obstaculos.Count > 0; }
    //    }

    //    private void OnTriggerEnter(Collider other)
    //    {
    //        if (other.CompareTag("Player"))
    //            return;

    //        obstaculos.Add(other);
    //    }

    //    private void OnTriggerExit(Collider other)
    //    {
    //        obstaculos.Remove(other);
    //    }
    // }
}

