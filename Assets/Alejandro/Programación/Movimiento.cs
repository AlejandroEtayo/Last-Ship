using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Movimiento : MonoBehaviour
{
    public int lateral;    //Cuanto se ha movido el jugador a los lados
    public int carril;     //En que carril se encuentra el jugador
    public Vector3 posicionPersonaje;  //Posicion del jugador

    int posicionZ;  //En que lugar se encuentra el jugador en el eje Z
    void Start()
    {
    }
    void Update()                         //CONTROLES
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Avance();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Retroceder();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Lados(1);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Lados(-1);
        }
    }

    public void Avance()                //El jugador avanza de carril en carril y el record máximo no se borra la retroceder
    {
        posicionZ++;
        if (posicionZ > carril)
        {
            carril = posicionZ;
        }
    }
    public void Retroceder()           //El jugador tiene un límite máximo de cuatro carriles para retroceder, este límite depende del record máximo que haya alcanzado el jugador
    {
        if (posicionZ > carril-4)
        {
            posicionZ--;
        }
    }
    public void Lados(int direccion)           //El jugador tiene un límite máximo de seis pasos tanto a la izquierda como a la derecha gracias al clamp, la direccion pide hacia donde se ha movido el jugador y realiza la operación con la variable lateral 
    {
       lateral+= direccion;
        lateral = Mathf.Clamp(lateral, -6, 6);
    }

}
