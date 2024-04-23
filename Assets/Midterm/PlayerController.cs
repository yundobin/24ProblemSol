using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 90.0f;

    public Camera playerCamera; // 카메라 변수 추가

    private bool isRotating = false; // 회전 중인지 여부를 나타내는 변수
    private bool isMoving = false; // 이동 중인지 여부를 나타내는 변수

    void Update()
    {
        // P 키를 누를 때마다 카메라 회전 처리 및 이동
        if (Input.GetKeyDown(KeyCode.P) && !isRotating && !isMoving)
        {
            StartCoroutine(RotateAndMoveCamera(playerCamera.transform.right * 40f, -90));
        }

        // O 키를 누를 때마다 카메라 회전 처리 및 이동
        if (Input.GetKeyDown(KeyCode.O) && !isRotating && !isMoving)
        {
            StartCoroutine(RotateAndMoveCamera(-playerCamera.transform.right * 40f, 90));
        }
    }

    IEnumerator RotateAndMoveCamera(Vector3 moveDirection, float rotationAngle)
    {
        isRotating = true;
        float startRotation = playerCamera.transform.rotation.eulerAngles.y; // 시작 각도
        float targetRotation = startRotation + rotationAngle; // 목표 각도

        float elapsedTime = 0f; // 경과 시간

        while (elapsedTime < 1f)
        {
            float currentAngle = Mathf.Lerp(startRotation, targetRotation, Mathf.SmoothStep(0f, 1f, elapsedTime)); // 부드럽게 각도 변경
            playerCamera.transform.rotation = Quaternion.Euler(45f, currentAngle, 0f);

            // 이동
            if (!isMoving)
            {
                isMoving = true;
                StartCoroutine(MoveCamera(moveDirection));
            }

            elapsedTime += Time.deltaTime / 1f; // 1초 동안 회전
            yield return null;
        }
        isRotating = false;
    }

    IEnumerator MoveCamera(Vector3 moveDirection)
    {
        float elapsedTime = 0f; // 경과 시간
        Vector3 startPosition = playerCamera.transform.position; // 시작 위치
        Vector3 targetPosition = startPosition + moveDirection;

        while (elapsedTime < 1f)
        {
            playerCamera.transform.position = Vector3.Lerp(startPosition, targetPosition, Mathf.SmoothStep(0f, 1f, elapsedTime)); // 부드럽게 이동
            elapsedTime += Time.deltaTime / 1f; // 1초 동안 이동

            // 회전
            float rotationAngle = Input.GetKeyDown(KeyCode.P) ? -90 : 90;
            float startRotation = playerCamera.transform.rotation.eulerAngles.y; // 시작 각도
            float targetRotation = startRotation + rotationAngle; // 목표 각도
            float currentAngle = Mathf.Lerp(startRotation, targetRotation, Mathf.SmoothStep(0f, 1f, elapsedTime)); // 부드럽게 각도 변경
            playerCamera.transform.rotation = Quaternion.Euler(45f, currentAngle, 0f);

            yield return null;
        }

        playerCamera.transform.position = targetPosition; // 목표 위치로 보정
        isMoving = false;
    }
}
