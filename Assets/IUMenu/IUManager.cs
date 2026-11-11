using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
public class IUManager : MonoBehaviour
{
    public GameObject panelCreditos;
    public GameObject panelInformacion;
    public GameObject panelPrincipal;
    public void TogglePanel(GameObject panel)
    {
        if(panel != null)
        {
            bool toggle = panel.activeInHierarchy ? false : true;
            panel.SetActive(toggle);
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
