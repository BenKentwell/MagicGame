using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{

    [SerializeField, Tooltip("Speed of the characters moement.")]
    private float acceleration = 10;

    [SerializeField, Tooltip("Intensity of the players slowing down.")]
    private float dampening;

    [SerializeField]
    private CameraController cameraController;

    private Rigidbody rigidBody;

    private Vector2 horizontal;
    private Vector3 velocity;
    private Vector3 direction;


    // Start is called before the first frame update
    void Start()
    {
        if (!rigidBody)
            rigidBody = GetComponent<Rigidbody>();

        if(!cameraController)
            cameraController = GetComponent<CameraController>();
    }

    void FixedUpdate()
    {
        Vector3 movement = Vector3.zero;
        movement += horizontal.x * Vector3.right;
        movement.z += horizontal.y;

        direction = transform.TransformDirection(movement);
        direction *= acceleration;
        /*velocity += direction * Time.deltaTime;
        velocity.x = Mathf.Lerp(velocity.x, 0, dampening * Time.deltaTime);
        velocity.z = Mathf.Lerp(velocity.z, 0, dampening * Time.deltaTime);
        velocity.y = rigidBody.velocity.y;
        rigidBody.velocity = new Vector3(velocity.x * Time.deltaTime, velocity.y, velocity.z * Time.deltaTime);
*/
        velocity += direction * Time.deltaTime;
        velocity.x = Mathf.Lerp(velocity.x, 0, dampening * Time.deltaTime);
        velocity.z = Mathf.Lerp(velocity.z, 0, dampening * Time.deltaTime);
        velocity.y = rigidBody.velocity.y;

        rigidBody.velocity = new Vector3(velocity.x * Time.deltaTime, velocity.y, velocity.z * Time.deltaTime);
        /*rigidBody.AddForce(new Vector3(velocity.x, 0, velocity.z ));*/
      

          cameraController.bobRate = rigidBody.velocity.magnitude;
        
    }

    public void Move(InputAction.CallbackContext _context)
    {
        horizontal = _context.action.ReadValue<Vector2>();
    }
}
