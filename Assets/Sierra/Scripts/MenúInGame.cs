using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenúInGame : MonoBehaviour
{
    public GameObject menuCanvas;
    public Button button;

    private void Start()
    {
        button.onClick.AddListener(CambioEscena);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }

    public void ToggleMenu()
    {
        menuCanvas.SetActive(!menuCanvas.activeSelf);
        Time.timeScale = menuCanvas.activeSelf ? 0f : 1f;
        Cursor.visible = menuCanvas.activeSelf;
        Cursor.lockState = menuCanvas.activeSelf ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public void CambioEscena()
    {
        SceneManager.LoadScene(1);
    }
}
