using UnityEngine;

public class PantallaGameOver : MonoBehaviour
{
    void LateUpdate()
    {
        // Convierte la posición del jugador a coordenadas de pantalla (Viewport)
        // 0 es el borde izquierdo/abajo, 1 es el borde derecho/arriba
        Vector3 posicionPantalla = Camera.main.WorldToViewportPoint(transform.position);

        // Si se sale por abajo o los lados
        if (posicionPantalla.x < -0.01f || posicionPantalla.x > 1.05f ||
            posicionPantalla.y < -0.01f || posicionPantalla.y > 1.05f)
        {
            // Detiene por completo el tiempo del juego (Congela todo)
            Time.timeScale = 0f;
        }
    }
}
