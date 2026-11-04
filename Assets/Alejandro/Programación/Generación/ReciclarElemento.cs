using UnityEngine;


public class ReciclarElemento : MonoBehaviour
{
    public enum TipoElemento
    {
        Carril,
        Obstaculo,
        Enemy,
        DeathZone,
    }

    public TipoElemento tipo;

    [HideInInspector]
    public bool enCola = false;
}