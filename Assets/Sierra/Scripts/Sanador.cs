using UnityEngine;
using UnityEngine.UI;

public class Sanador : MonoBehaviour
{
    public float velocidad = 1.0f;      // Velocidad de flotaci�n
    public float amplitud = 1.0f;       // Amplitud de la oscilaci�n
    public float alturaInicial = 0.0f;  // Altura inicial de la esfera
    public Camera camara;               // Referencia a la c�mara
    private Vector3 posici�nInicial;
    private bool objetoFlotante = true;  // Indica si el objeto est� flotando
    private Rigidbody rb;

    private void Start()
    {
        // Guardar la posici�n inicial del objeto
        posici�nInicial = transform.position;

        // Obtener el componente Rigidbody del objeto
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (objetoFlotante)
        {
            // Calcular la nueva posici�n vertical de la esfera
            float nuevaAltura = alturaInicial + amplitud * Mathf.Sin(Time.time * velocidad);

            // Actualizar la posici�n del objeto
            transform.position = new Vector3(posici�nInicial.x, nuevaAltura, posici�nInicial.z);
        }

        if (camara != null)
        {
            // Lanzar un raycast desde la c�mara
            Ray rayo = camara.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(rayo, out hitInfo) && hitInfo.collider.gameObject == gameObject)
            {
                // Comprobar si se hizo clic izquierdo del mouse
                if (Input.GetMouseButtonDown(0))
                {
                    objetoFlotante = false;  // Dejar de flotar

                    // Calcular direcci�n hacia la c�mara
                    Vector3 direcci�n = camara.transform.position - transform.position;

                    // Aplicar una fuerza hacia la c�mara
                    rb.AddForce(direcci�n.normalized * velocidad, ForceMode.VelocityChange);

                    // Comprobar si el objeto choc� con la c�mara
                    float distancia = direcci�n.magnitude;
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
