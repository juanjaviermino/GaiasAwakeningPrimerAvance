using UnityEngine;
using UnityEngine.UI;

public class Sanador : MonoBehaviour
{
    public float velocidad = 1.0f;      // Velocidad de flotación
    public float amplitud = 1.0f;       // Amplitud de la oscilación
    public float alturaInicial = 0.0f;  // Altura inicial de la esfera
    public Camera camara;               // Referencia a la cámara
    private Vector3 posiciónInicial;
    private bool objetoFlotante = true;  // Indica si el objeto está flotando
    private Rigidbody rb;

    private void Start()
    {
        // Guardar la posición inicial del objeto
        posiciónInicial = transform.position;

        // Obtener el componente Rigidbody del objeto
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (objetoFlotante)
        {
            // Calcular la nueva posición vertical de la esfera
            float nuevaAltura = alturaInicial + amplitud * Mathf.Sin(Time.time * velocidad);

            // Actualizar la posición del objeto
            transform.position = new Vector3(posiciónInicial.x, nuevaAltura, posiciónInicial.z);
        }

        if (camara != null)
        {
            // Lanzar un raycast desde la cámara
            Ray rayo = camara.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(rayo, out hitInfo) && hitInfo.collider.gameObject == gameObject)
            {
                // Comprobar si se hizo clic izquierdo del mouse
                if (Input.GetMouseButtonDown(0))
                {
                    objetoFlotante = false;  // Dejar de flotar

                    // Calcular dirección hacia la cámara
                    Vector3 dirección = camara.transform.position - transform.position;

                    // Aplicar una fuerza hacia la cámara
                    rb.AddForce(dirección.normalized * velocidad, ForceMode.VelocityChange);

                    // Comprobar si el objeto chocó con la cámara
                    float distancia = dirección.magnitude;
                    if (distancia < 3f)
                    {
                        // Destruir el objeto
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}
