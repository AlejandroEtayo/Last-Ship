using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GestorFIFO gestorFIFO;
    private void OnTriggerEnter(Collider other)
    {
        ElementoReciclable elemento =
            other.GetComponentInParent<ElementoReciclable>();

        if (elemento == null)
            return;

        GestorFIFO.Instancia.Guardar(elemento.gameObject);
    }
}