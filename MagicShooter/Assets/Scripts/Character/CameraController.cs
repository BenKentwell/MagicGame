using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float lookSensitivityMax;

    private float lookSensitivity;

    [SerializeField, Tooltip("The maximum angle in degrees, the character can look up and down. \n X - Up contraint \n Y - Down constraint")]
    private Vector2 lookContstraintAngle;

    [SerializeField, Tooltip("The small amount of dampening for the camera movement delta")]
    private float dampening;

    private GameObject childCamera;
    private Vector2 lookDelta;

    // Start is called before the first frame update
    void Start()
    {
        lookSensitivity = lookSensitivityMax;
        Cursor.lockState = CursorLockMode.Locked;
        childCamera = GetComponentInChildren<Camera>().gameObject;

    }

    private void Update()
    {
        Quaternion rotation = childCamera.transform.rotation;
        Quaternion vertical = Quaternion.AngleAxis(lookDelta.y, Vector3.left);
        Quaternion horizontal = Quaternion.AngleAxis(lookDelta.x, Vector3.up);
        childCamera.transform.rotation = rotation * vertical;
        transform.rotation = horizontal * transform.rotation;
        float cameraLookX = childCamera.transform.eulerAngles.x;
        if (cameraLookX < 360 - lookContstraintAngle.x && cameraLookX > 270)
        {
            Vector3 pos = childCamera.transform.localPosition;
            childCamera.transform.SetLocalPositionAndRotation(pos, Quaternion.Euler(360 - lookContstraintAngle.x, 0, 0));
        }

        if (cameraLookX > lookContstraintAngle.y && cameraLookX < 90)
        {
            Vector3 pos = childCamera.transform.localPosition;
            childCamera.transform.SetLocalPositionAndRotation(pos, Quaternion.Euler(lookContstraintAngle.y, 0, 0));
        }
    }

    public void OnLook(InputAction.CallbackContext _context)
    {
        lookDelta = _context.phase switch
        {
            InputActionPhase.Performed => _context.ReadValue<Vector2>() * lookSensitivity,
            InputActionPhase.Canceled => Vector2.zero,
            _ => Vector2.zero
        };
    }

}
