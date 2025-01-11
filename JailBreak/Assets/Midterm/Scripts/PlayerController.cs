using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private GameObject cameraObject;

    private bool isRotating = false;

    void Update()
    {
        // Get camera's forward and right vectors (ignoring y-axis)
        Vector3 cameraForward = Vector3.Scale(cameraObject.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 cameraRight = Vector3.Scale(cameraObject.transform.right, new Vector3(1, 0, 1)).normalized;

        // Calculate movement direction based on camera orientation
        Vector3 moveDirection = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += cameraForward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection -= cameraRight;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection -= cameraForward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += cameraRight;
        }

        // Normalize and apply movement
        if (moveDirection != Vector3.zero)
        {
            moveDirection.Normalize();
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
            // Rotate player to face the movement direction
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }

        // Handle rotations
        if (!isRotating && Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(RotateCamera(-90));
        }
        else if (!isRotating && Input.GetKeyDown(KeyCode.O))
        {
            StartCoroutine(RotateCamera(90));
        }
    }

    System.Collections.IEnumerator RotateCamera(float angle)
    {
        isRotating = true;
        float duration = 1.0f; // 회전하는 데 걸리는 시간 (초)
        Quaternion startRotation = cameraObject.transform.rotation;
        Quaternion endRotation = startRotation * Quaternion.Euler(0, angle, 0);
        float timeElapsed = 0;

        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;
            Quaternion currentRotation = Quaternion.Lerp(startRotation, endRotation, timeElapsed / duration);
            cameraObject.transform.rotation = currentRotation; // 카메라만 회전
            yield return null;
        }

        cameraObject.transform.rotation = endRotation;
        isRotating = false;
    }
}
