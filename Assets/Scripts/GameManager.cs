using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TextMeshProUGUI textoMonedas;
    public TextMeshProUGUI textoPociones;
    public TextMeshProUGUI textoPuntos;

    private int monedas = 0;
    private int pociones = 0;
    private int puntos = 0;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        ActualizarTextos();
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

    void ActualizarTextos()
    {
        if (textoMonedas != null) textoMonedas.text = "Monedas: " + monedas;
        if (textoPociones != null) textoPociones.text = "Pociones: " + pociones;
        if (textoPuntos != null) textoPuntos.text = "Puntos: " + puntos;
    }
}