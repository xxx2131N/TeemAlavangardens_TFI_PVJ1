using UnityEngine;

public class BalaNaveN2 : MonoBehaviour
{
    public float velocidad = 25f;
    public float duracion = 5f;

    void Start()
    {
        Destroy(gameObject, duracion);
    }

    void Update()
    {
        transform.Translate(
            Vector3.forward * velocidad * Time.deltaTime
        );
    }
}
