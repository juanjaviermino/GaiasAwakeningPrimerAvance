using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVRotacion : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform target;

    // Update is called once per frame
    void Update()
    {
        Vector3 targetOrientation = target.position - transform.position;

        transform.rotation = Quaternion.LookRotation(targetOrientation);
    }
}
