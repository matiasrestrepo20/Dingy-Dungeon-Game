using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TextMeshProUGUI textoMonedas;

    private int monedas = 0;

    void Awake()
    {
        Instance = this;
    }

    public void SumarMoneda()
    {
        monedas++;
        textoMonedas.text = "Monedas: " + monedas;
    }
}