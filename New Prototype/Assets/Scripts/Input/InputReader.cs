using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "New Input Reader", menuName = "Input/Reader")]
public class InputReader : ScriptableObject, GameInput.IPlayerActions
{
    // Gameplay
    public event UnityAction jumpEvent;
    public event UnityAction jumpCanceledEvent;
    public event UnityAction dashEvent;
    public event UnityAction<bool> glideEvent;
    public event UnityAction grabEvent;
    public event UnityAction<bool> groundPoundEvent;
    public event UnityAction<Vector2> moveEvent;

    private GameInput gameInput;

    private void OnEnable()
    {
        if (gameInput == null)
        {
            gameInput = new GameInput();
            gameInput.Player.SetCallbacks(this);
        }

        gameInput.Player.Enable();
    }

    private void OnDisable()
    {
        gameInput.Player.Disable();
    }

    public void OnClimb(InputAction.CallbackContext context)
    {
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (dashEvent != null && context.phase == InputActionPhase.Performed)
        {
            dashEvent.Invoke();
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (jumpEvent != null && context.phase == InputActionPhase.Performed)
        {
            jumpEvent.Invoke();
        }
    }

    public void OnJumpCancel(InputAction.CallbackContext context)
    {
        if (jumpCanceledEvent != null && context.phase == InputActionPhase.Performed)
        {
            jumpCanceledEvent.Invoke();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (moveEvent != null && context.phase == InputActionPhase.Performed)
        {
            moveEvent.Invoke(context.ReadValue<Vector2>());
        }

        if (moveEvent != null && context.phase == InputActionPhase.Canceled)
        {
            moveEvent.Invoke(Vector2.zero);
        }
    }

    public void OnGlide(InputAction.CallbackContext context)
    {
        if (glideEvent != null && context.phase == InputActionPhase.Performed)
        {
            glideEvent.Invoke(true);
        }

        if (glideEvent != null && context.phase == InputActionPhase.Canceled)
        {
            glideEvent.Invoke(false);
        }
    }

    public void OnGrab(InputAction.CallbackContext context)
    {
        if (grabEvent != null && context.phase == InputActionPhase.Started)
        {
            grabEvent.Invoke();
        }
    }

    public void OnGroundPound(InputAction.CallbackContext context)
    {
        if (groundPoundEvent != null && context.phase == InputActionPhase.Performed)
        {
            groundPoundEvent.Invoke(true);
        }

        if (groundPoundEvent != null && context.phase == InputActionPhase.Canceled)
        {
            groundPoundEvent.Invoke(false);
        }
    }
}
