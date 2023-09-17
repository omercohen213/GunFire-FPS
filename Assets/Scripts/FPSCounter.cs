using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    private float deltaTime = 0.0f;
    private readonly GUIStyle style = new();

    private void Start()
    {
        // Set up the GUIStyle for the FPS display.
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = 12;
        style.normal.textColor = Color.green;
    }

    private void Update()
    {
        // Calculate the current FPS.
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
    }

    private void OnGUI()
    {
        // Calculate and display the FPS.
        float fps = 1.0f / deltaTime;
        string fpsText = string.Format("{0:0.} FPS", fps);
        GUI.Label(new Rect(10, 10, 150, 30), fpsText, style);
    }
}
