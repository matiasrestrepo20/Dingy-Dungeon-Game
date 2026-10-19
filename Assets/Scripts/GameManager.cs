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

    private int monedas = 0;
    private int pociones = 0;
    private int puntos = 0;
    private bool juegoTerminado = false;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        textoGameOver.gameObject.SetActive(false);
        textoVictoria.gameObject.SetActive(false);
        ActualizarTextos();
    }

    void Update()
    {
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
        if (textoMonedas != null) textoMonedas.text = "Monedas: " + monedas;
        if (textoPociones != null) textoPociones.text = "Pociones: " + pociones;
        if (textoPuntos != null) textoPuntos.text = "Puntos: " + puntos;
    }
}