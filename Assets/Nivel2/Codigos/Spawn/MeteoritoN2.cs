using UnityEngine;

public class MeteoritoN2 : MonoBehaviour
{
    public float velocidad = 15f;
    public float tiempoVida = 20f;

    private Vector3 direccion;

    void Start()
    {
        float x = Random.Range(-1f, 1f);
        float z = Random.Range(-1f, 1f);

        direccion = new Vector3(x, 0f, z).normalized;

        Destroy(gameObject, tiempoVida);
    }

    void Update()
    {
        transform.position += direccion * velocidad * Time.deltaTime;
    }
}
