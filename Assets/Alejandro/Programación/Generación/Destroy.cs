using UnityEngine;

public class Destroy : MonoBehaviour
{
    //public GestorFIFO gestorFIFO;
    private void OnTriggerEnter(Collider other)
    {
        ReciclarElemento elemento =
            other.GetComponentInParent<ReciclarElemento>();

        if (elemento == null)
            return;

        GestorFIFO.Instancia.Guardar(elemento.gameObject);
    }
}   