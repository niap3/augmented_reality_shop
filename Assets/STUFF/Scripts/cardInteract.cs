using UnityEngine;

public class CardRotation : MonoBehaviour
{
    private Vector2 initialTouchPosition;
    private Vector2 touchDelta;
    private float rotationSpeedFactor = 0.5f;
    private bool isRotating = true;

    void Update()
    {
        if (isRotating)
        {
            RotateContinuously();
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    initialTouchPosition = touch.position;
                    isRotating = false;
                    break;

                case TouchPhase.Moved:
                    isRotating = false;
                    touchDelta = touch.position - initialTouchPosition;
                    float rotationAmount = -touchDelta.x * rotationSpeedFactor;
                    Quaternion deltaRotation = Quaternion.Euler(0f, rotationAmount, 0f);
                    transform.rotation *= deltaRotation;
                    initialTouchPosition = touch.position;
                    break;

                case TouchPhase.Ended:
                    isRotating = true;
                    break;
            }
        }
    }

    void RotateContinuously()
    {
        transform.rotation *= Quaternion.Euler(0f, rotationSpeedFactor * 160 * Time.deltaTime, 0f);
    }
}
