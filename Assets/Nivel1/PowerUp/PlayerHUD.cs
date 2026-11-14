using UnityEngine;
using System.Collections;

public class PlayerHUD : MonoBehaviour
{
    private int vida= 10;
    private EnemyController enemy;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CurarVida(int cantidad)
    {
        vida += cantidad;
        if (vida > 10)
        {
            vida = 10;
        }
    }
    public void RecibirDaño(int cantidad)
    {
        vida -= cantidad;
        if (vida <= 0)
        {
            GameManager.instance.GameOver();
            Debug.Log("Jugador ha muerto");
        }
    }
}
