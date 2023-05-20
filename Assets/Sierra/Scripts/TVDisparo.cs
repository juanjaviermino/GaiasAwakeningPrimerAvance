using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVDisparo : MonoBehaviour
{
    public GameObject objetoDisparado;
    public Transform puntoDisparo;
    public float tiempoEntreDisparos = 2f;

    private float tiempoSiguienteDisparo;

    private void Update()
    {
        if (Time.time >= tiempoSiguienteDisparo)
        {
            Disparar();
            tiempoSiguienteDisparo = Time.time + tiempoEntreDisparos;
        }
    }

    private void Disparar()
    {
        // Crea una instancia del objeto disparado en el punto de disparo
        GameObject instanciaDisparo = Instantiate(objetoDisparado, puntoDisparo.position, puntoDisparo.rotation);
    }
}



