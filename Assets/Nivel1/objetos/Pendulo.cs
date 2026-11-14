using UnityEngine;

public class Pendulo : MonoBehaviour
{
    private float velocidad =50;
    private float anguloActual;
    private float limite =45f;

    void Start()
    {
        anguloActual = Random.Range(-limite, limite);
    }
    void Update()
    {
        anguloActual += velocidad * Time.deltaTime;
        if(anguloActual >= limite || anguloActual <= -limite)
        {
            velocidad *= -1;
            anguloActual = Mathf.Clamp(anguloActual, -limite, limite);
        }
        transform.localRotation = Quaternion.Euler( anguloActual,0,0);
    }
}
