using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    private RectTransform crosshairRectTransform;

    private void Start()
    {
        crosshairRectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        // Get the center position of the screen
        Vector2 screenCenter = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);

        // Set the position of the crosshair to the center of the screen
        crosshairRectTransform.position = screenCenter;
    }
}
