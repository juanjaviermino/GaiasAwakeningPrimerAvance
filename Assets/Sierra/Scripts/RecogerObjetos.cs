using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecogerObjetos : MonoBehaviour
{
    [SerializeField] private Camera FPCamera;
    [SerializeField] private float range = 200f;
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float waitTime = 3f;

    private Transform playerTransform;
    private bool isMoving = false;
    private float destroyTime;

    private void Start()
    {
        playerTransform = transform;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range) && hit.collider.gameObject.name.Contains("Sanador"))
            {
                isMoving = true;
                destroyTime = Time.time + waitTime;

                // Detener cualquier movimiento actual
                if (GetComponent<Rigidbody>() != null)
                {
                    GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
            }
        }

        if (isMoving)
        {
            MoveToPlayer();

            if (Time.time >= destroyTime)
            {
                Destroy(gameObject);
            }
        }
    }

    private void MoveToPlayer()
    {
        Vector3 direction = playerTransform.position - transform.position;
        float distanceToPlayer = direction.magnitude;

        if (distanceToPlayer > 0.1f)
        {
            Vector3 movement = direction.normalized * movementSpeed * Time.deltaTime;
            transform.position += movement;
        }
    }
}
