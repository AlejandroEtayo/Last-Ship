using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro; // Para TextMesh Pro


public class Movimiento : MonoBehaviour
{
    public InputValue inputValue;  
    public int lateral;    //Cuanto se ha movido el jugador a los lados
    public int carril;     //En que carril se encuentra el record del jugador
    public Vector3 posicionPersonaje;  //Posicion del jugador
    public Transform PosicionInicial;  //Posicion inicial del jugador
    public World world;  //Referencia al script World para poder crear el suelo
    public float velocidadMovimiento = 5f;     //Velocidad a la que se mueve el jugador
    public int posicionZ;  //En que lugar se encuentra el jugador en el eje Z

    int posicionX;  //En que lugar se encuentra el jugador en el eje X
    int posicionY;  //En que lugar se encuentra el jugador en el eje Y

    public float cooldownMovimiento = 0.2f;   //Cooldown para evitar movimientos demasiado rápidos y diagonales
    private float siguienteMovimiento = 0f;

    public int vidas = 3;      //Las vidas del jugador

    //Detectan si hay una colisión delante del personaje
    public MovimientoSensor sensorAdelante;
    public MovimientoSensor sensorAtras;
    public MovimientoSensor sensorIzquierda;
    public MovimientoSensor sensorDerecha;

    private Rigidbody rb;  //Referencia al Rigidbody del jugador para poder moverlo con físicas
    private Vector3 destino;    //Destino al que se mueve el jugador
    private Vector3 destinoAnterior;

    private int posicionXAnterior;
    private int posicionZAnterior;

    private bool movimientoEnCurso;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Se guardala posición inicial del jugador
        destino = rb.position;
        // Se guarda la posición anterior del jugador
        destinoAnterior = destino;

        posicionX = Mathf.RoundToInt(rb.position.x);
        posicionZ = Mathf.RoundToInt(rb.position.z);

        posicionZAnterior = posicionZ;
        posicionXAnterior = posicionX;

        // Se guarda la altura inicial
        destino.y = rb.position.y;
    }

    //private void Update()
    //{
        
    //}

    void FixedUpdate()
    {
        if (movimientoEnCurso && DireccionBloqueada(destino - rb.position))
        {
            CancelarMovimiento();
            return;
        }
        if (!movimientoEnCurso)
        {
            Vector3 velocidad = rb.linearVelocity;
            velocidad.x = 0f;
            velocidad.z = 0f;
            rb.linearVelocity = velocidad;
            return;
        }

        Vector3 diferencia = destino - rb.position;

        // Si aparece un obstáculo en la dirección del movimiento,
        // cancelamos el desplazamiento.
        if (DireccionBloqueada(diferencia))
        {
            CancelarMovimiento();
            return;
        }

        Vector3 siguientePosicion = Vector3.MoveTowards(
            rb.position,
            new Vector3(destino.x, rb.position.y, destino.z),
            velocidadMovimiento * Time.fixedDeltaTime
        );

        rb.MovePosition(siguientePosicion);

        // El movimiento ha terminado.
        if (Mathf.Abs(destino.x - siguientePosicion.x) < 0.001f &&
            Mathf.Abs(destino.z - siguientePosicion.z) < 0.001f)
        {
            movimientoEnCurso = false;

            Vector3 velocidad = rb.linearVelocity;
            velocidad.x = 0f;
            velocidad.z = 0f;
            rb.linearVelocity = velocidad;
        }
    }
    private bool DireccionBloqueada(Vector3 diferencia)
    {
        if (diferencia.z > 0.01f)
            return sensorAdelante != null && sensorAdelante.bloqueado;

        if (diferencia.z < -0.01f)
            return sensorAtras != null && sensorAtras.bloqueado;

        if (diferencia.x < -0.01f)
            return sensorIzquierda != null && sensorIzquierda.bloqueado;

        if (diferencia.x > 0.01f)
            return sensorDerecha != null && sensorDerecha.bloqueado;

        return false;
    }
    private void CancelarMovimiento()
    {
        // Volvemos a la última casilla válida,
        // manteniendo la altura actual para conservar la gravedad.
        rb.position = new Vector3(
            destinoAnterior.x,
            rb.position.y,
            destinoAnterior.z
        );

        // Restauramos las coordenadas lógicas.
        posicionX = posicionXAnterior;
        posicionZ = posicionZAnterior;

        destino = rb.position;
        destinoAnterior = destino;

        movimientoEnCurso = false;

        // Eliminamos el impulso horizontal, no la caída vertical.
        Vector3 velocidad = rb.linearVelocity;
        velocidad.x = 0f;
        velocidad.z = 0f;
        rb.linearVelocity = velocidad;
    }



    private bool PuedeMoverse()
    {
        if (Time.time < siguienteMovimiento)
            return false;

        siguienteMovimiento = Time.time + cooldownMovimiento;
        return true;
    }

    public void Posicion()
    {

        destino = new Vector3(posicionX, rb.position.y, posicionZ);
        movimientoEnCurso = true;
        Debug.Log("El personaje se ha movido: " + destino);

        //posicionPersonaje = new Vector3(posicionX, 0, posicionZ);               //Se actualiza la posición del jugador en los dos ejes (X y Z)
        //transform.position = posicionPersonaje;                                 //Se transforma la posición del jugador a la posición actual
        //Debug.Log(transform.position = posicionPersonaje);
    }


    public void OnAvanzar(InputValue input)                //El jugador avanza de carril en carril y el record máximo no se borra al retroceder
    {
        Debug.Log("Se ha pulsado W");

        Debug.Log("Movimiento en curso: " + movimientoEnCurso);

        Debug.Log("Sensor delantero bloqueado: " +
            (sensorAdelante != null && sensorAdelante.bloqueado));

        if (movimientoEnCurso)
            return;

        if (!PuedeMoverse())
            return;

        GuardarPosicionAnterior();

        if (sensorAdelante != null && sensorAdelante.bloqueado)
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
        if (movimientoEnCurso)
            return;
        if (!PuedeMoverse())
            return;

        GuardarPosicionAnterior();

        if (sensorAtras != null && sensorAtras.bloqueado)
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
        if (movimientoEnCurso)
            return;
        if (!PuedeMoverse())
            return;

        GuardarPosicionAnterior();

        if (sensorIzquierda != null && sensorIzquierda.bloqueado)
            return;


        posicionX--;
        Debug.Log("El personaje se mueve a la izquierda");
        Posicion();
    }

    public void OnDerecha(InputValue input)
    {
        if (movimientoEnCurso)
            return;
        if (!PuedeMoverse())
            return;

        GuardarPosicionAnterior();

        if (sensorDerecha != null && sensorDerecha.bloqueado)
            return;

        posicionX++;
        Debug.Log("El personaje se mueve a la derecha");
        Posicion();
    }
    private void GuardarPosicionAnterior()
    {
        destinoAnterior = destino;
        posicionXAnterior = posicionX;
        posicionZAnterior = posicionZ;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!movimientoEnCurso)
            return;

        // Si chocamos físicamente con un obstáculo,
        // cancelamos el movimiento pendiente.
        Transform objeto = collision.transform;

        while (objeto != null)
        {
            if (objeto.CompareTag("Obstaculo"))
            {
                CancelarMovimiento();
                return;
            }

            objeto = objeto.parent;
        }
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
        if (posicionY < 0.7)
        {
            Debug.Log("El personaje ha caído al vacío");
        }
        vidas--;

        if (vidas == 0)
        {
            Debug.Log("Personaje muere");
            transform.position = PosicionInicial.position;
        }
    }
}
