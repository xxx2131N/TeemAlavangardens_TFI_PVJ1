using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class POwerUp : MonoBehaviour
{
    private PlayerHUD playerHUD;
    private float duracionPoder = 5;
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
        StartCoroutine(RutinaPoderRojo());
    }
    private IEnumerator RutinaPoderRojo()
    {
        if (playerHUD != null)
        {
            playerHUD.SetInvulnerable(true);
        }
        yield return new WaitForSeconds(duracionPoder);
        if (playerHUD != null)
        {
            playerHUD.SetInvulnerable(false);
        }
        Debug.Log("se agarro el poder rojo");
    }
    public void PowerUpBlue()
    {
        Debug.Log("se agarro poder azul");
        StartCoroutine(RutinaPoderAzul());
    }

    private IEnumerator RutinaPoderAzul()
    {
        GameObject[] objetosCaos = GameObject.FindGameObjectsWithTag("Caos");

        List<Enemigo> enemigosAfectados = new List<Enemigo>();
        List<Nave> navesAfectadas = new List<Nave>();
        List<Pendulo> pendulosAfectados = new List<Pendulo>();

        foreach (GameObject obj in objetosCaos)
        {
            Enemigo scriptEnemigo = obj.GetComponent<Enemigo>();
            if (scriptEnemigo != null)
            {
                scriptEnemigo.velocidad /= 2f;
                enemigosAfectados.Add(scriptEnemigo);
            }

            Nave scriptNave = obj.GetComponent<Nave>();
            if (scriptNave != null)
            {
                scriptNave.velocidad /= 2f;
                navesAfectadas.Add(scriptNave);
            }

            Pendulo scriptPendulo = obj.GetComponent<Pendulo>();
            if (scriptPendulo != null)
            {
                scriptPendulo.velocidad /= 2f;
                pendulosAfectados.Add(scriptPendulo);
            }
        }

        yield return new WaitForSeconds(duracionPoder);

        foreach (Enemigo e in enemigosAfectados)
        {
            if (e != null) e.velocidad *= 2f;
        }

        foreach (Nave n in navesAfectadas)
        {
            if (n != null) n.velocidad *= 2f;
        }

        foreach (Pendulo p in pendulosAfectados)
        {
            if (p != null) p.velocidad *= 2f;
        }

        Debug.Log("termino el poder azul");
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
