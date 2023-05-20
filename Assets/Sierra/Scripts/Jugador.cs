using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Jugador : MonoBehaviour
{
    public AudioClip sonido;
    public AudioClip trueno;
    private AudioSource audioSource;
    public JugadorInfo data;
    public RawImage imagen;
    public Texture2D ganaste;
    public Texture2D perdiste;
    public Texture2D menu;
    public GameObject menuCanvas;
    public TextMeshProUGUI orbes;
    public TextMeshProUGUI vidas;
    public Light targetLight;
    public float flashIntensity = 5f;
    public float flashDuration = 0.5f;
    public int flashCount = 5;
    public float timeBetweenFlashes = 0.2f;
    private float originalIntensity;
    // Start is called before the first frame update
    void Start()
    {
        data.vida = 3;
        data.orbesRecogidos = 0;
        audioSource = GetComponent<AudioSource>();
        if (sonido != null)
        {
            audioSource.clip = sonido;
        }
        imagen.texture = menu;
        int orbesR = data.orbesRecogidos;
        orbes.text = orbesR.ToString();
        int vidasR = data.vida;
        vidas.text = vidasR.ToString();
        originalIntensity = targetLight.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SaveManager.Save(data);
        }
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            data = SaveManager.Load();
            int orbesR = data.orbesRecogidos;
            orbes.text = orbesR.ToString();
            int vidasR = data.vida;
            vidas.text = vidasR.ToString();
        }
    }

    public void reproducirSonido()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sanador"))
        {
            data.orbesRecogidos += 1;
            int orbesR = data.orbesRecogidos;
            orbes.text = orbesR.ToString();
            StartCoroutine(FlashCoroutine());
            if (data.orbesRecogidos == 10)
            {
                imagen.texture = ganaste;
                menuCanvas.SetActive(!menuCanvas.activeSelf);
                Time.timeScale = menuCanvas.activeSelf ? 0f : 1f;
                Cursor.visible = menuCanvas.activeSelf;
                Cursor.lockState = menuCanvas.activeSelf ? CursorLockMode.None : CursorLockMode.Locked;
            }
            
        }

        if (collision.gameObject.CompareTag("Bala"))
        {
            data.vida -= 1;
            int vidasR = data.vida;
            vidas.text = vidasR.ToString();
            if (data.vida == 0)
            {
                imagen.texture = perdiste;
                menuCanvas.SetActive(!menuCanvas.activeSelf);
                Time.timeScale = menuCanvas.activeSelf ? 0f : 1f;
                Cursor.visible = menuCanvas.activeSelf;
                Cursor.lockState = menuCanvas.activeSelf ? CursorLockMode.None : CursorLockMode.Locked;
            }
        }
    }

    private System.Collections.IEnumerator FlashCoroutine()
    {
        audioSource.clip = trueno;
        reproducirSonido();
        for (int i = 0; i < flashCount; i++)
        {
            targetLight.intensity = flashIntensity;
            yield return new WaitForSeconds(flashDuration / 2);

            targetLight.intensity = originalIntensity;
            yield return new WaitForSeconds(flashDuration / 2);

            yield return new WaitForSeconds(timeBetweenFlashes);
        }
        yield return new WaitForSeconds(3);
        audioSource.clip = sonido;
    }

    public void actualizarMarcador()
    {
        int orbesR = data.orbesRecogidos;
        orbes.text = orbesR.ToString();
        int vidasR = data.vida;
        vidas.text = vidasR.ToString();
    }

}

