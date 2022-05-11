using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Cinemachine.CinemachineVirtualCamera cinemachineCamera;
    [SerializeField]
    private InputActionReference mousePositionReference;
    [SerializeField]
    private float radius = 10f;
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private Transform pointerTransform;

    public Camera MainCamera { get; private set; }

    private void Start()
    {
        MainCamera = Camera.main;
    }

    private void Update()
    {
        Vector3 screemMousePosition = mousePositionReference.action.ReadValue<Vector2>();
        Vector3 worldMousePosition = MainCamera.ScreenToWorldPoint(screemMousePosition);
        worldMousePosition.z = 0;
        Vector3 pointerNewPosition = (worldMousePosition + playerTransform.position) / 2;
        pointerNewPosition.x = Mathf.Clamp(pointerNewPosition.x, playerTransform.position.x - radius, playerTransform.position.x + radius);
        pointerNewPosition.y = Mathf.Clamp(pointerNewPosition.y, playerTransform.position.y - radius, playerTransform.position.y + radius);
        pointerTransform.position = pointerNewPosition;
    }
}
