using UnityEngine;
using TMPro; // Para TextMesh Pro
public class Score : MonoBehaviour
{
    public int MaxScore;
    public int PosActual;

    public TextMeshProUGUI PuntuacionTexto;

    // Referencia al script de movimiento
    public Movimiento jugador;

    void Start()
    {
        MaxScore = jugador.carril;
    }

    void Update()
    {
        // Obtener la posición actual del jugador desde el script de movimiento
        PosActual = (int)jugador.posicionZ;

        // Actualizar el récord si se supera
        if (PosActual > MaxScore)
        {
            MaxScore = PosActual;
        }

        // Mostrar el récord en la interfaz
        PuntuacionTexto.text = MaxScore.ToString();
    }
}



