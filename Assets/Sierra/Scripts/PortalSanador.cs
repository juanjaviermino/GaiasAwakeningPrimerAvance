using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSanador : MonoBehaviour
{
    public float minX = 0f;
    public float maxX = 100f;
    public float minZ = 0f;
    public float maxZ = 100f;
    public float rotationSpeed = 50f;
    public float floatSpeed = 1f;
    public float floatAmplitude = 0.5f;

    private Vector3 initialPosition;
    private float elapsedTime = 0f;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jugador"))
        {
            Jugador player = other.GetComponent<Jugador>();
            MoveObject();
            player.data.vida += 1;
            player.actualizarMarcador();
        }
    }

    private void MoveObject()
    {
        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);

        Vector3 newPosition = new Vector3(randomX, initialPosition.y, randomZ);

        transform.position = newPosition;

        elapsedTime = 0f;
    }

    private void Update()
    {
        // Rotación sobre el eje Y
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // Movimiento vertical
        elapsedTime += Time.deltaTime;
        float newY = initialPosition.y + Mathf.Sin(elapsedTime * floatSpeed) * floatAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}



