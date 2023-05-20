using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CambiarEscena : MonoBehaviour
{
    public int escena;
    public Button button;

    private void Start()
    {
        button.onClick.AddListener(CambioEscena);
    }

    public void CambioEscena()
    {
        SceneManager.LoadScene(escena);
    }
}
