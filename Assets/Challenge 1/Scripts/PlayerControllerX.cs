using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float verticalInput;
    public float horizontalInput;

    void Update()
    {
        // check if a controller is plugged in
        Gamepad pad = Gamepad.current;

        if (pad != null)
        {
            // the stick gives a number from -1 to 1, not just on/off
            verticalInput = pad.leftStick.y.ReadValue();
            horizontalInput = pad.leftStick.x.ReadValue();
        }

        // stick right = faster, stick left = slower (extra credit)
        float currentSpeed = speed + horizontalInput * 5;

        // move the plane forward
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);

        // tilt the plane, the more you push the stick the faster it tilts
        transform.Rotate(Vector3.right * rotationSpeed * verticalInput * Time.deltaTime);
    }
}
