using UnityEngine;
using TMPro; // Para TextMesh Pro
public class Score : MonoBehaviour
{
    public int PuntuacionMax;
    [SerializeField] private TextMeshPro textoPuntuacion;


    void Start()
    {
        // Inicializa el texto en 0 al empezar
        textoPuntuacion.text = "0";
    }

}
