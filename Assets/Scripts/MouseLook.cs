using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
	public Transform target; // ī�޶� ���� ��� (ĳ����)
	public Vector3 offset; // ī�޶�� ��� ������ �Ÿ�
	public float mouseSensitivity = 100f; // ���콺 ����
	public float rotationSmoothTime = 0.12f; // ȸ���� �ε巯��

	private float verticalRotation = 0f;
	private float horizontalRotation = 0f;
	private Vector3 currentRotation;
	private Vector3 rotationSmoothVelocity;

	// Start is called before the first frame update
	void Start()
    {
		// ���콺 Ŀ�� �����
		Cursor.lockState = CursorLockMode.Locked;
	}

    // Update is called once per frame
    void Update()
    {
		// ���콺 �Է� �ޱ�
		horizontalRotation += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
		verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
		verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f); // ���� ȸ�� ����

		// �ε巯�� ȸ���� ���� ó��
		Vector3 targetRotation = new Vector3(verticalRotation, horizontalRotation);
		currentRotation = Vector3.SmoothDamp(currentRotation, targetRotation, ref rotationSmoothVelocity, rotationSmoothTime);

		// ī�޶� ȸ�� �� ��ġ ������Ʈ
		transform.eulerAngles = currentRotation;
		transform.position = target.position - transform.forward * offset.magnitude;
	}
}
