using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TextMeshProUGUI textoMonedas;
    public TextMeshProUGUI textoPociones;
    public TextMeshProUGUI textoPuntos;
    public GameObject panelInstrucciones;
    public GameObject panelMuerte;
    public GameObject panelVictoria;

    private int monedas = 0;
    private int pociones = 0;
    private int puntos = 0;
    private int totalMonedas = 0;
    private int totalPociones = 0;
    private bool juegoTerminado = false;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        totalMonedas = FindObjectsByType<Coin>(FindObjectsSortMode.None).Length;
        totalPociones = FindObjectsByType<Potion>(FindObjectsSortMode.None).Length;

        panelMuerte.SetActive(false);
        panelVictoria.SetActive(false);
        ActualizarTextos();

        panelInstrucciones.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Comenzar()
    {
        panelInstrucciones.SetActive(false);
        Time.timeScale = 1f;
    }

    public void SumarMoneda()
    {
        monedas++;
        puntos += 10;
        ActualizarTextos();
    }

    public void SumarPocion()
    {
        pociones++;
        puntos += 25;
        ActualizarTextos();
    }

    public bool TieneTodasLasMonedas()
    {
        return monedas >= totalMonedas;
    }

    public void GameOver()
    {
        juegoTerminado = true;
        panelMuerte.SetActive(true);
    }

    public void Victoria()
    {
        juegoTerminado = true;
        panelVictoria.SetActive(true);
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void IrAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuPrincipal");
    }

    void ActualizarTextos()
    {
        if (textoMonedas != null) textoMonedas.text = "Monedas: " + monedas + "/" + totalMonedas;
        if (textoPociones != null) textoPociones.text = "Pociones: " + pociones + "/" + totalPociones;
        if (textoPuntos != null) textoPuntos.text = "Puntos: " + puntos;
    }
}