using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform target; // ĳ������ Transform
	public Vector3 offset; // ĳ���Ϳ� ī�޶� ������ ������
	public float upVector = 3.0f; // ī�޶��� ���� ����

	private void LateUpdate()
	{
		Vector3 desiredPosition = target.position + offset;
		transform.position = desiredPosition;
		transform.LookAt(target.position + Vector3.up * upVector);
	}
}