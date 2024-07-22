using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class CharacterController : MonoBehaviour
{

    [SerializeField, Tooltip("Speed of the characters moement.")]
    private float acceleration = 10;

    [SerializeField, Tooltip("Intensity of the players slowing down.")]
    private float dampening;

    private Rigidbody rigidBody;

    private Vector2 horizontal;
    private Vector3 velocity;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        if (!rigidBody)
            rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 movement = Vector3.zero;
        movement += horizontal.x * Vector3.right;
        movement.z += horizontal.y;

        direction = transform.TransformDirection(movement);
        direction *= acceleration;
        velocity += direction * Time.deltaTime;
        velocity.x = Mathf.Lerp(velocity.x, 0, dampening * Time.deltaTime);
        velocity.z = Mathf.Lerp(velocity.z, 0, dampening * Time.deltaTime);
        velocity.y = rigidBody.velocity.y;

        rigidBody.velocity = new Vector3(velocity.x * Time.deltaTime, velocity.y, velocity.z * Time.deltaTime);
    }

    public void Move(InputAction.CallbackContext _context)
    {
        horizontal = _context.action.ReadValue<Vector2>();
    }
}
