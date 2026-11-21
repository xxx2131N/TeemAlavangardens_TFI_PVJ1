using UnityEngine;

public class rotacion : MonoBehaviour
{
    public float velocidadR=300;
    void Update()
    {
        transform.Rotate(0,0,velocidadR * Time.deltaTime);
    }
}
