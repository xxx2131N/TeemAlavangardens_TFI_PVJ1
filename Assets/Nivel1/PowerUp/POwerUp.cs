using UnityEngine;
using System.Collections;

public class POwerUp : MonoBehaviour
{
    private PlayerHUD playerHUD;
    void Start()
    {
        playerHUD = GetComponent<PlayerHUD>();
    }

    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PRed"))
        {
            other.gameObject.SetActive(false);
            PowerUpRed();
        }
        else if(other.CompareTag("PBlue"))
        {
            other.gameObject.SetActive(false);
            PowerUpBlue();
        }
        else if(other.CompareTag("PGreen"))
        {
            other.gameObject.SetActive(false);
            PowerUpGreen();
        }
        else if(other.CompareTag("Star"))
        {
            other.gameObject.SetActive(false);
            puntuacion();
        }
    }
    public void PowerUpRed()
    {
        Debug.Log("se agarro poder rojo");
        
    }
    public void PowerUpBlue()
    {
        //enemigo.velocidad == velocidad/2;
        Debug.Log("se agarro poder azul");
    }
    public void PowerUpGreen()
    { 
        playerHUD.CurarVida(1);
        Debug.Log("se ha obtenido una vida");
    }
    public void puntuacion()
    {
        playerHUD.SumarPuntos(100);
        Debug.Log("se a agarrado Star");
    }

}
