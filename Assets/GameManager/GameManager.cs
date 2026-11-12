using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public GameObject panelInicio;
    public GameObject panelHUD;
    public GameObject panelPause;
    public GameObject panelGameOver;
    public GameObject panelVictoria;
    public GameState estadoActual;
    public enum GameState
    {
        Inicio,
        Jugando,
        Pausa,
        GameOver,
        Victoria
    }
    void Start()
    {
        Time.timeScale = 1f;
        estadoActual = GameState.Inicio;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(panelInicio != null)
            {
                panelInicio.SetActive(false);
            }
            estadoActual = GameState.Jugando;
            Time.timeScale = 1f;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(estadoActual == GameState.Jugando)
            {
                PauseGame();
            }
            else if(estadoActual == GameState.Pausa)
            {
                ReanudarJuego();
            }
        }
    }
    public void createPanel()
    {
        if(panelHUD != null && panelInicio != null)
        {
            panelHUD.SetActive(true);
        }
    }
    public void PauseGame()
    {
        if(panelPause != null)
        {
            Debug.Log(" se ah PAUSADO el juego");
            panelPause.SetActive(true);
            Time.timeScale = 0f;
        }
        estadoActual = GameState.Pausa;
    }
    public void ReanudarJuego()
    {
        Time.timeScale = 1f;
        if(panelPause != null)
        {
            Debug.Log(" se ah REANUDADO el juego");
            panelPause.SetActive(false);
        }
        estadoActual = GameState.Jugando;
    }
    public void GameOver()
    {
        estadoActual = GameState.GameOver;
        Time.timeScale = 0f;
        if(panelGameOver != null)
        {
            Debug.Log("GAME OVER");
            panelGameOver.SetActive(true);
        }
        if (panelHUD != null)
        {
            panelHUD.SetActive(false);
        }
        Debug.Log("estado:GAME OVER");
    }
    public void Victoria()
    {
        Time.timeScale = 0f;
        estadoActual = GameState.Victoria;
        if(panelVictoria != null)
        {
            
            Debug.Log("VICTORIA");
            panelVictoria.SetActive(true);
        }
        if (panelHUD != null)
        {
            panelHUD.SetActive(false);
        }
        Debug.Log("estado:VICTORIA");
    }
    public void ToggelPanel(GameObject panel)
    {
        if(panel != null)
        {
            bool isActive = panel.activeSelf;
            panel.SetActive(!panel.activeSelf);
        }
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
