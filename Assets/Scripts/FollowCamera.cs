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
		// ���콺 Ŀ�� �����
		Cursor.lockState = CursorLockMode.Locked;

		// ī�޶� ȸ�� �ʱ�ȭ
		currentRotation = transform.eulerAngles;
		verticalRotation = currentRotation.x;
		horizontalRotation = currentRotation.y;

		// ī�޶��� �ʱ� ��ġ ����
		SetInitialCameraPosition();
	}

	void LateUpdate()
	{
		// ���콺 �Է¿� ���� ȸ�� ó��
		horizontalRotation += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
		verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
		verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

		Vector3 targetRotation = new Vector3(verticalRotation, horizontalRotation);
		currentRotation = Vector3.SmoothDamp(currentRotation, targetRotation, ref rotationSmoothVelocity, rotationSmoothTime);

		// ī�޶� ȸ�� �� ��ġ ������Ʈ
		transform.eulerAngles = currentRotation;
		transform.position = target.position - transform.forward * offset.magnitude;
	}

	void SetInitialCameraPosition()
	{
		// ī�޶��� �ʱ� ��ġ�� ĳ���� ��ġ + ���������� ����
		transform.position = target.position + offset;
		transform.LookAt(target);
	}
}