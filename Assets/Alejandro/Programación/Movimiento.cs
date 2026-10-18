using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Movimiento : MonoBehaviour
{
    public InputValue inputValue;  
    public int lateral;    //Cuanto se ha movido el jugador a los lados
    public int carril;     //En que carril se encuentra el jugador
    public Vector3 posicionPersonaje;  //Posicion del jugador
    public Transform PosicionInicial;  //Posicion inicial del jugador
    public World world;  //Referencia al script World para poder crear el suelo
    public float velocidadMovimiento = 5f;     //Velocidad a la que se mueve el jugador
    int posicionZ;  //En que lugar se encuentra el jugador en el eje Z

    int posicionX;  //En que lugar se encuentra el jugador en el eje X

    public int vidas = 3;      //Las vidas del jugador

    //Detectan si hay una colisión delante del personaje
    public MovimientoSensor sensorAdelante;
    public MovimientoSensor sensorAtras;
    public MovimientoSensor sensorIzquierda;
    public MovimientoSensor sensorDerecha;

    private Rigidbody rb;  //Referencia al Rigidbody del jugador para poder moverlo con físicas
    private Vector3 destino;    //Destino al que se mueve el jugador

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Se guardala posición inicial del jugador
        destino = rb.position;

        posicionX = Mathf.RoundToInt(rb.position.x);
        posicionZ = Mathf.RoundToInt(rb.position.z);

        // Se guarda la altura inicial
        destino.y = rb.position.y;
    }
    void FixedUpdate()
    {
        // Se calcula la posición sin alterar la altura del jugador
        Vector3 siguientePosicion = Vector3.MoveTowards(rb.position, new Vector3(destino.x, rb.position.y, destino.z), velocidadMovimiento * Time.fixedDeltaTime);

        // se mueve el Rigibody
        rb.MovePosition(siguientePosicion);
    }

    public void Posicion()
    {

        destino = new Vector3(posicionX, rb.position.y, posicionZ);
        Debug.Log("El personaje se ha movido: " + destino);

        //posicionPersonaje = new Vector3(posicionX, 0, posicionZ);               //Se actualiza la posición del jugador en los dos ejes (X y Z)
        //transform.position = posicionPersonaje;                                 //Se transforma la posición del jugador a la posición actual
        //Debug.Log(transform.position = posicionPersonaje);
    }


    public void OnAvanzar(InputValue input)                //El jugador avanza de carril en carril y el record máximo no se borra al retroceder
    {
        if (sensorAdelante.bloqueado)
            return;

        Debug.Log("El personaje Avanza");

        posicionZ++;
        if (posicionZ > carril)
        {
            carril = posicionZ;
            world.CrearSuelo();
        }
        Posicion();
    }
    public void OnRetroceder(InputValue input)           //El jugador tiene un límite máximo de cuatro carriles para retroceder, este límite depende del record máximo que haya alcanzado el jugador
    {
        if (sensorAtras.bloqueado)
            return;

        Debug.Log("El personaje Retrocede");

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
    public void OnIzquierda(InputValue input)           //El jugador se mueve lateralmente hasta que el mapa se lo impida
    {
        if (sensorIzquierda.bloqueado)
            return;

        posicionX--;
        Debug.Log("El personaje se mueve a la izquierda");
        Posicion();
    }

    public void OnDerecha(InputValue input)
    {
        if (sensorDerecha.bloqueado)
            return;

        posicionX++;
        Debug.Log("El personaje se mueve a la derecha");
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

        if (vidas == 0)
        {
            Debug.Log("Personaje muere");
            transform.position = PosicionInicial.position;
        }
    }
}
