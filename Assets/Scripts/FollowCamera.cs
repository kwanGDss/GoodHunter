using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
	public Transform target;
	public Vector3 offset;
	public float mouseSensitivity = 100f;
	public float rotationSmoothTime = 0.12f;

	private float verticalRotation = 0f;
	private float horizontalRotation = 0f;
	private Vector3 currentRotation;
	private Vector3 rotationSmoothVelocity;

	void Start()
	{
		// 마우스 커서 숨기기
		Cursor.lockState = CursorLockMode.Locked;

		// 카메라 회전 초기화
		currentRotation = transform.eulerAngles;
		verticalRotation = currentRotation.x;
		horizontalRotation = currentRotation.y;

		// 카메라의 초기 위치 설정
		SetInitialCameraPosition();
	}

	void LateUpdate()
	{
		// 마우스 입력에 따른 회전 처리
		horizontalRotation += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
		verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
		verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

		Vector3 targetRotation = new Vector3(verticalRotation, horizontalRotation);
		currentRotation = Vector3.SmoothDamp(currentRotation, targetRotation, ref rotationSmoothVelocity, rotationSmoothTime);

		// 카메라 회전 및 위치 업데이트
		transform.eulerAngles = currentRotation;
		transform.position = target.position - transform.forward * offset.magnitude;
	}

	void SetInitialCameraPosition()
	{
		// 카메라의 초기 위치를 캐릭터 위치 + 오프셋으로 설정
		transform.position = target.position + offset;
		transform.LookAt(target);
	}
}