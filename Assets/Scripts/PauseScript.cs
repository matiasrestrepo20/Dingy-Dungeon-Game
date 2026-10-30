using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject panelPausa;
    public GameObject panelConfiguracion;

    void Start()
    {
        panelPausa.SetActive(false);
        panelConfiguracion.SetActive(false);
    }

    public void Pausar()
    {
        if (Time.timeScale == 0f) return;

        panelPausa.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Continuar()
    {
        panelPausa.SetActive(false);
        panelConfiguracion.SetActive(false);
        Time.timeScale = 1f;
    }

    public void AbrirConfiguracion()
    {
        panelConfiguracion.SetActive(true);
    }

    public void CerrarConfiguracion()
    {
        panelConfiguracion.SetActive(false);
    }

    public void VolverAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuPrincipal");
    }
}