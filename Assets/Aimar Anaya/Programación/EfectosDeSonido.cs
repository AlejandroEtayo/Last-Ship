using UnityEngine;

public class EfectosDeSonido : MonoBehaviour
{
    public static EfectosDeSonido instance;

    [Header("Sonidos")]
    public AudioClip laser;
    public AudioClip naveMovimiento;
    public AudioClip asteroide;
    public AudioClip motorEstropeado;

    void Awake()
    {
        instance = this;
    }

    public void SonarLaser(Vector3 posicion)
    {
        AudioSource.PlayClipAtPoint(laser, posicion);
    }

    public void SonarNaveMovimiento(Vector3 posicion)
    {
        AudioSource.PlayClipAtPoint(naveMovimiento, posicion);
    }

    public void SonarAsteroide(Vector3 posicion)
    {
        AudioSource.PlayClipAtPoint(asteroide, posicion);
    }

    public void SonarMotorEstropeado(Vector3 posicion)
    {
        AudioSource.PlayClipAtPoint(motorEstropeado, posicion);
    }
}
