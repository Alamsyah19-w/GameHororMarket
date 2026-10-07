using UnityEngine;
using UnityEngine.InputSystem;
public class MovementPlayer : MonoBehaviour
{
    [SerializeField] private float speed=5f;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private float gravity=-9.8f;
    private CharacterController playerControl;

    private Vector3 movement;
    private float velocityY;

    private void Awake()
    {
        playerControl=GetComponent<CharacterController>();
    }
    public void PlayerMovement(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        movement = new Vector3(input.x, 0, input.y);
       
    }
    private void gravitasiPlayer()
    {
        if (playerControl.isGrounded && velocityY <0)
        {
            velocityY=-2;
        }
        velocityY+=gravity*Time.deltaTime;
        
    }

    private void Update()
    {
        gravitasiPlayer();
        Vector3 velocity= movement*speed;
        velocity.y=velocityY;

        playerControl.Move(velocity*Time.deltaTime);
        
        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }
       
        
    }

}
