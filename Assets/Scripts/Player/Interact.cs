using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    [SerializeField] private Transform originTransform;
    [SerializeField] private Vector3 boxHalfExtents = new Vector3(0.5f, 1f, 0.5f);
    public void playerInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("interact");
        }
    }
    private void Update()
    {
        interactBox();
    }

    private void interactBox()
    {
        Vector3 origin= originTransform.position;
        Vector3 direction = originTransform.forward;
        Quaternion rotate=originTransform.rotation;

        bool hitbox=Physics.BoxCast(
            origin,
            boxHalfExtents,
            direction,out RaycastHit hit,
            rotate,
            10f
        );
        if (hitbox)
        {
            
        }

    }
}
