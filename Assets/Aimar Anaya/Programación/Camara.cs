using UnityEngine;

public class CamaraSeguimiento : MonoBehaviour
{
    [Header("Movimiento Automático")]
    public float velocidadAvance = 2f;

    void Update()
    {
        transform.Translate(Vector3.forward * velocidadAvance * Time.deltaTime, Space.World);
    }
}
