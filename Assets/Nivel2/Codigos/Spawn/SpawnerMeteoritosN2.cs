using UnityEngine;

public class SpawnerMeteoritosN2 : MonoBehaviour
{
    public GameObject meteoritoPrefab;

    public float rangoX = 10f;
    public float rangoZ = 6f;

    public float tiempoMin = 1.5f;
    public float tiempoMax = 3f;

    void Start()
    {
        Invoke(nameof(GenerarMeteorito), 1f);
    }

    void GenerarMeteorito() 
    {
        float x = Random.Range(-rangoX, rangoX);
        float z = Random.Range(-rangoZ, rangoZ);

        Vector3 posicion = transform.position + new Vector3(x, 0f, z);

        Instantiate(meteoritoPrefab, posicion, Quaternion.identity);

        Invoke(nameof(GenerarMeteorito), Random.Range(tiempoMin, tiempoMax));
    }

}
