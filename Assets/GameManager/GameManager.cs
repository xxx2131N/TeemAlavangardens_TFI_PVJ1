using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject panelInicio;
    public GameObject Informacion;
    public GameObject panelHUD;
    public GameObject panelPause;
    public GameObject panelGameOver;
    public GameObject panelVictoria;

    public GameState estadoActual;

    public enum GameState
    {
        Inicio,
        Informacion,
        Jugando,
        Pausa,
        GameOver,
        Victoria
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Time.timeScale = 0f;
        estadoActual = GameState.Inicio;

        if (panelInicio != null) panelInicio.SetActive(true);
        if (Informacion != null) Informacion.SetActive(false);
        if (panelHUD != null) panelHUD.SetActive(false);
        if (panelPause != null) panelPause.SetActive(false);
        if (panelGameOver != null) panelGameOver.SetActive(false);
        if (panelVictoria != null) panelVictoria.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (estadoActual == GameState.Inicio)
            {
                MostrarInformacion();
            }
            else if (estadoActual == GameState.Informacion)
            {
                EmpezarJuego();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (estadoActual == GameState.Jugando)
            {
                PauseGame();
            }
            else if (estadoActual == GameState.Pausa)
            {
                ReanudarJuego();
            }
        }
    }

    public void MostrarInformacion()
    {
        Time.timeScale = 0f;
        estadoActual = GameState.Informacion;

        if (panelInicio != null) panelInicio.SetActive(false);
        if (Informacion != null) Informacion.SetActive(true);
        if (panelHUD != null) panelHUD.SetActive(false);
    }

    public void EmpezarJuego()
    {
        estadoActual = GameState.Jugando;

        if (panelInicio != null) panelInicio.SetActive(false);
        if (Informacion != null) Informacion.SetActive(false);
        if (panelHUD != null) panelHUD.SetActive(true);

        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        if (panelPause != null)
        {
            Debug.Log("Se ha PAUSADO el juego");
            panelPause.SetActive(true);
        }
        if (panelHUD != null)
        {
            panelHUD.SetActive(false);
        }

        Time.timeScale = 0f;
        estadoActual = GameState.Pausa;
    }

    public void ReanudarJuego()
    {
        if (panelPause != null)
        {
            Debug.Log("Se ha REANUDADO el juego");
            panelPause.SetActive(false);
        }
        if (panelHUD != null)
        {
            panelHUD.SetActive(true);
        }

        Time.timeScale = 1f;
        estadoActual = GameState.Jugando;
    }

    public void GameOver()
    {
        estadoActual = GameState.GameOver;
        Time.timeScale = 0f;

        if (panelGameOver != null)
        {
            Debug.Log("GAME OVER");
            panelGameOver.SetActive(true);
        }
        if (panelHUD != null)
        {
            panelHUD.SetActive(false);
        }
    }

    public void Victoria()
    {
        estadoActual = GameState.Victoria;
        Time.timeScale = 0f;

        if (panelVictoria != null)
        {
            Debug.Log("VICTORIA");
            panelVictoria.SetActive(true);
        }
        if (panelHUD != null)
        {
            panelHUD.SetActive(false);
        }
    }

    public void ToggelPanel(GameObject panel)
    {
        if (panel != null)
        {
            panel.SetActive(!panel.activeSelf);
        }
    }

    public void ChangeScene(string sceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }
}