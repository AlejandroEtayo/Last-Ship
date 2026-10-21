using System.Collections.Generic;
using UnityEngine;

public class MovimientoSensor : MonoBehaviour
{
    private HashSet<Collider> obstaculos = new HashSet<Collider>();

    public bool bloqueado
    {
        get { return obstaculos.Count > 0; }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            return;

        if (!other.CompareTag("Obstaculo"))
            return;

        obstaculos.Add(other);
        Debug.Log("Obstáculo detectado: " + other.name);
    }

    private void OnTriggerExit(Collider other)
    {
        obstaculos.Remove(other);
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

