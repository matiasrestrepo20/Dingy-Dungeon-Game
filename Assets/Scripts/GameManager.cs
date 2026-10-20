using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TextMeshProUGUI textoMonedas;
    public TextMeshProUGUI textoPociones;
    public TextMeshProUGUI textoPuntos;
    public TextMeshProUGUI textoGameOver;
    public TextMeshProUGUI textoVictoria;
    public TextMeshProUGUI textoHistoria;

    private int monedas = 0;
    private int pociones = 0;
    private int puntos = 0;
    private int totalMonedas = 0;
    private int totalPociones = 0;
    private bool juegoTerminado = false;
    private bool juegoIniciado = false;

    private static bool historiaMostrada = false;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        totalMonedas = FindObjectsByType<Coin>(FindObjectsSortMode.None).Length;
        totalPociones = FindObjectsByType<Potion>(FindObjectsSortMode.None).Length;

        textoGameOver.gameObject.SetActive(false);
        textoVictoria.gameObject.SetActive(false);
        ActualizarTextos();

        if (historiaMostrada)
        {
            juegoIniciado = true;
            textoHistoria.gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            textoHistoria.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    void Update()
    {
        if (!juegoIniciado)
        {
            if (Input.anyKeyDown)
            {
                juegoIniciado = true;
                historiaMostrada = true;
                textoHistoria.gameObject.SetActive(false);
                Time.timeScale = 1f;
            }
            return;
        }

        if (juegoTerminado && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
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

    public void GameOver()
    {
        juegoTerminado = true;
        textoGameOver.gameObject.SetActive(true);
    }

    public void Victoria()
    {
        juegoTerminado = true;
        textoVictoria.gameObject.SetActive(true);
    }

    void ActualizarTextos()
    {
        if (textoMonedas != null) textoMonedas.text = "Monedas: " + monedas + "/" + totalMonedas;
        if (textoPociones != null) textoPociones.text = "Pociones: " + pociones + "/" + totalPociones;
        if (textoPuntos != null) textoPuntos.text = "Puntos: " + puntos;
    }
}