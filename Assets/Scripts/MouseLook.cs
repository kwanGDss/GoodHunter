using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
	public Transform target; // 카메라가 따라갈 대상 (캐릭터)
	public Vector3 offset; // 카메라와 대상 사이의 거리
	public float mouseSensitivity = 100f; // 마우스 감도
	public float rotationSmoothTime = 0.12f; // 회전의 부드러움

	private float verticalRotation = 0f;
	private float horizontalRotation = 0f;
	private Vector3 currentRotation;
	private Vector3 rotationSmoothVelocity;

	// Start is called before the first frame update
	void Start()
    {
		// 마우스 커서 숨기기
		Cursor.lockState = CursorLockMode.Locked;
	}

    // Update is called once per frame
    void Update()
    {
		// 마우스 입력 받기
		horizontalRotation += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
		verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
		verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f); // 상하 회전 제한

		// 부드러운 회전을 위한 처리
		Vector3 targetRotation = new Vector3(verticalRotation, horizontalRotation);
		currentRotation = Vector3.SmoothDamp(currentRotation, targetRotation, ref rotationSmoothVelocity, rotationSmoothTime);

		// 카메라 회전 및 위치 업데이트
		transform.eulerAngles = currentRotation;
		transform.position = target.position - transform.forward * offset.magnitude;
	}
}
