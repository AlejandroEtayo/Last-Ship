using UnityEngine;

public class MoverObstaculo : MonoBehaviour
{
    public float velocidad = 5f;

    // Dirección fija hacia la derecha
    public Vector3 direccion = Vector3.right;

    void Update()
    {
        // 1. Mueve el coche continuamente de izquierda a derecha (eje X)
        transform.Translate(direccion * velocidad * Time.deltaTime);

        // 2. Si la posición X supera 20 (ya se ha salido de la pantalla por la derecha), desaparece
        if (transform.position.x > 20f)
        {
            Destroy(gameObject);
        }
    }
}
