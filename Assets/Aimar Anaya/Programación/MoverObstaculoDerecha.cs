using UnityEngine;

public class MoverObstaculoDerecha : MonoBehaviour
{
    public float velocidad = 5f;

    // Dirección fija hacia la izquierda (porque sale desde la derecha)
    public Vector3 direccion = Vector3.left;

    void Update()
    {
        // 1. Mueve el coche continuamente de derecha a izquierda (eje X)
        transform.Translate(direccion * velocidad * Time.deltaTime);

        // 2. Si la posición X es menor que -20 (se sale por la izquierda), desaparece
        if (transform.position.x < -20f)
        {
            Destroy(gameObject);
        }
    }
}
