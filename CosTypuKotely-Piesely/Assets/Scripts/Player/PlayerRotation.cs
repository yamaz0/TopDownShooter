using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class PlayerRotation
{
    [SerializeField]
    private InputActionReference mousePositionReference;
    [SerializeField]
    private Camera mainCamera;
    public void Rotate(Transform playerTransform)
    {
        Vector2 screemMousePosition = mousePositionReference.action.ReadValue<Vector2>();
        Vector2 worldMousePosition = mainCamera.ScreenToWorldPoint(screemMousePosition);

        // Vector2 direction = worldMousePosition - new Vector2(playerTransform.position.x, playerTransform.position.y);
        float angle = AngleBetweenTwoPoints(worldMousePosition, playerTransform.position);
        playerTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public float AngleBetweenTwoPoints(Vector2 a, Vector2 b)
    {
        return Mathf.Atan2(b.y - a.y, b.x - a.x) * Mathf.Rad2Deg;
    }

    public Vector3 GetShootDirection(Transform playerTransform)
    {
        Vector3 screemMousePosition = mousePositionReference.action.ReadValue<Vector2>();
        Vector3 worldMousePosition = mainCamera.ScreenToWorldPoint(screemMousePosition);
        return worldMousePosition - playerTransform.position;
    }
}
