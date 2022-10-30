using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public static class Utils
{
    static Camera mainCamera;
    static UnityEngine.InputSystem.Controls.Vector2Control mousePosition;

    public static Camera MainCamera
    {
        get
        {
            if (!mainCamera)
            {
                mainCamera = Camera.main;
            }
            return mainCamera;
        }
    }

    static Utils()
    {
        mainCamera = Camera.main;
        mousePosition = Mouse.current.position;
    }

    public static Vector3 MouseScreenToWorldPoint()
    {
        Vector2 currentMousePosition = mousePosition.ReadValue();
        return MainCamera.ScreenToWorldPoint(currentMousePosition);
    }
    public static Texture2D GenerateTextureFromSprite(Sprite aSprite)
    {
        var rect = aSprite.rect;
        var tex = new Texture2D((int)rect.width, (int)rect.height);
        var data = aSprite.texture.GetPixels((int)rect.x, (int)rect.y, (int)rect.width, (int)rect.height);
        tex.SetPixels(data);
        tex.Apply(true);
        return tex;
    }
}
