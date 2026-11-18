using UnityEngine;

//Función para meter a los asteroides en un bucle infinito de posciones y su velocidad de movimiento
public class Spawn_Enemies : MonoBehaviour
{
    // Velocidad de movimiento
    public float speed = 5.0f;
    // Dirección del movimiento
    public Vector3 direccion = Vector3.left;
    void Update()
    {
        // Mueve el objeto de forma constante e independiente de los FPS
        transform.Translate(direccion.normalized * speed * Time.deltaTime);
    }
}
