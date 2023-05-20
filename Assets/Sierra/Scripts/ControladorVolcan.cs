using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorVolcan : MonoBehaviour
{
    public Light luz;
    public AudioClip sonido;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        luz = GetComponent<Light>();
        audioSource = GetComponent<AudioSource>();
        if (sonido != null)
        {
            audioSource.clip = sonido;
        }
    }

    // Update is called once per frame
    public IEnumerator AumentarIntensidad()
    {
        if (luz != null)
        {
            luz.intensity += 10f;
            Color color = HexToColor("#E29D41");
            Color color2 = HexToColor("#DED3C4");
            luz.color = color2;
            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play();
            }
            yield return new WaitForSeconds(2f);
            luz.color = color;
        }
    }

    private Color HexToColor(string hex)
    {
        Color color = Color.black;
        if (ColorUtility.TryParseHtmlString(hex, out color))
        {
            return color;
        }
        else
        {
            Debug.LogError("Error al convertir el código hexadecimal en color.");
            return Color.black;
        }
    }
}


/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorVolcan : MonoBehaviour
{
    public Light luz;
    public AudioClip sonido;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        luz = GetComponent<Light>();
        audioSource = GetComponent<AudioSource>();
        if (sonido != null)
        {
            audioSource.clip = sonido;
        }
    }

    // Update is called once per frame
    public void aumentarIntensidad()
    {
        if (luz != null)
        {
            luz.intensity += 5f;
            Color color HexToColor("#E29D41");
            Color color2 HexToColor("#DED3C4");
            luz.color = color2;
            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play();
            }
            yield return new WaitForSeconds(2f);
            luz.color =  color;
        }
    }
}*/
