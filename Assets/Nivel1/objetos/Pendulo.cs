using UnityEngine;

public class Pendulo : MonoBehaviour
{
    private float velocidad =50;
    private float anguloActual = 0f;
    private float limite =45f;
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
