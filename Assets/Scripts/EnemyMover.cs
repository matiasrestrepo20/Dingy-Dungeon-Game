using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public float velocidad = 4f;
    public float distancia = 3f;
    public bool horizontal = false;

    private Vector3 inicio;

    void Start()
    {
        inicio = transform.position;
    }

    void Update()
    {
        float desplazamiento = Mathf.PingPong(Time.time * velocidad, distancia * 2) - distancia;

        if (horizontal)
        {
            transform.position = inicio + new Vector3(desplazamiento, 0, 0);
        }
        else
        {
            transform.position = inicio + new Vector3(0, desplazamiento, 0);
        }
    }
}