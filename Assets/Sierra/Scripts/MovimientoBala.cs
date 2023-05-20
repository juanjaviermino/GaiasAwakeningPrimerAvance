using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class MovimientoBala : MonoBehaviour
{
    public float fuerzaDisparo = 10f;
    public float alturaMaxima = 5f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        Vector3 direccionDisparo = transform.forward + transform.up;
        rb.AddForce(direccionDisparo * fuerzaDisparo, ForceMode.VelocityChange);

        // Aplica una fuerza hacia abajo para simular la gravedad
        rb.AddForce(Physics.gravity, ForceMode.Acceleration);

        // Calcula el tiempo de vuelo basado en la altura máxima y la gravedad
        float tiempoVuelo = Mathf.Sqrt(2f * alturaMaxima / Mathf.Abs(Physics.gravity.y));

        // Destruye la bala después de un tiempo igual al tiempo de vuelo
        //Destroy(gameObject, tiempoVuelo);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            Jugador jugador = collision.gameObject.GetComponent<Jugador>();
            if (jugador != null)
            {
                jugador.reproducirSonido();
            }

            Destroy(gameObject);

        }
        else if (collision.gameObject.CompareTag("Terreno"))
        {
            Destroy(gameObject);
        }
    }
}

/*public class MovimientoBala : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float timelife = 5f;

    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timelife);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Jugador")
        {
            Destroy(gameObject);
        }
    }
}*/
