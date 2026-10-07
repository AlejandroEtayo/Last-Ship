using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class Movimiento : MonoBehaviour
{
    public int lateral;    //Cuanto se ha movido el jugador a los lados
    public int carril;     //En que carril se encuentra el jugador
    public Vector3 posicionPersonaje;  //Posicion del jugador

    int posicionZ;  //En que lugar se encuentra el jugador en el eje Z

    int posicionX;  //En que lugar se encuentra el jugador en el eje X

    public int vidas = 3;      //Las vidas del jugador
    void Start()
    {

    }
    void Update()
    {

    }

    public void Posicion()
    {
        posicionPersonaje = new Vector3(posicionX, 0, posicionZ);   //Se actualiza la posición del jugador en los dos ejes (X y Z)
        transform.position = posicionPersonaje;   //Se transforma la posición del jugador a la posición actual
        Debug.Log(transform.position = posicionPersonaje);
    }


    public void OnAvanzar(InputValue input)                //El jugador avanza de carril en carril y el record máximo no se borra la retroceder
    {
        posicionZ++;
        if (posicionZ > carril)
        {


            carril = posicionZ;
        }
        Posicion();
    }
    public void OnRetroceder(InputValue input)           //El jugador tiene un límite máximo de cuatro carriles para retroceder, este límite depende del record máximo que haya alcanzado el jugador
    {
        if (posicionZ > carril - 4)
        {

            posicionZ--;
        }
        else if (posicionZ < carril - 4)
        {


            vidas = 0;
        }
        Posicion();
    }
    public void OnIzquierda(InputValue input)           //El jugador tiene un límite máximo de seis pasos tanto a la izquierda como a la derecha gracias al clamp, la direccion pide hacia donde se ha movido el jugador y realiza la operación con la variable lateral 
    {


        posicionX--;

        Posicion();

    }
    public void OnDerecha(InputValue input)
    {

        posicionX++;
        Posicion();

    }
    public void Curar()
    {
        if (vidas < 3)
        {

            vidas++;
        }
    }
    public void Dano()
    {
        vidas--;

        if(vidas == 0)
        {
            Debug.Log("Personaje muere");
        }
    }
}
