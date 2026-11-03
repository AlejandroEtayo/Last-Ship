using UnityEngine;

//Con este script se puede marcar un elemento como reciclable, para que el gestor de elementos pueda reutilizarlo en lugar de destruirlo y crear uno nuevo.
public class ElementoReciclable : MonoBehaviour
{
    public enum TipoElemento
    {
        Carril,
        Obstaculo,
        DeathZone,
        Enemy,
    }

    public TipoElemento tipo;

    [HideInInspector]
    public bool enCola = false;
}

