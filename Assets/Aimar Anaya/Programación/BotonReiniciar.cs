using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonReiniciar : MonoBehaviour
{
    public void Reintentar()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("EscenaPrincipal");
    }
}
