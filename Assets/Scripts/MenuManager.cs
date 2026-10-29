using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject panelCreditos;

    void Start()
    {
        panelCreditos.SetActive(false);
    }

    public void Jugar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }

    public void AbrirCreditos()
    {
        panelCreditos.SetActive(true);
    }

    public void CerrarCreditos()
    {
        panelCreditos.SetActive(false);
    }

    public void Salir()
    {
        Application.Quit();
    }
}