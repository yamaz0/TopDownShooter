using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public static class Utils
{
    static Camera mainCamera;
    static UnityEngine.InputSystem.Controls.Vector2Control mousePosition;

    static Utils()
    {
        mainCamera = Camera.main;
        mousePosition = Mouse.current.position;
    }

    public static Vector3 MouseScreenToWorldPoint()
    {
        Vector2 currentMousePosition = mousePosition.ReadValue();
        return mainCamera.ScreenToWorldPoint(currentMousePosition);
    }
}
