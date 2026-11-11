using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
public class IUManager : MonoBehaviour
{
    public GameObject panelCreditos;
    public GameObject panelInformacion;
    public GameObject panelPrincipal;
    public GameObject panelMovimiento;
    public GameObject panelPowerUp;
    public GameObject panelConfiguracion;
    public GameObject panelNivel;
    public GameObject panelSalir;
    public void TogglePanel(GameObject panel)
    {
        if(panel != null)
        {
            bool activar = !panel.activeSelf;
            if(panelCreditos != null)panelCreditos.SetActive(false);
            
            if(panelInformacion != null)panelInformacion.SetActive(false);
            if(panelPrincipal != null)panelPrincipal.SetActive(false);
            if(panelMovimiento != null)panelMovimiento.SetActive(false);
            if(panelPowerUp != null)panelPowerUp.SetActive(false);
            if(panelConfiguracion != null)panelConfiguracion.SetActive(false);
            if(panelNivel != null)panelNivel.SetActive(false);
            if(panelSalir != null)panelSalir.SetActive(false);
            if(activar)panel.SetActive(true);
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(sceneName: scene);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(panelCreditos != null)
            {
                panelCreditos.SetActive(false);
            }
            if(panelInformacion != null)
            {
                panelInformacion.SetActive(false);
            }
            if(panelPrincipal != null)
            {
                panelPrincipal.SetActive(false);
            }
        }
    }
}
