using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform target; // 캐릭터의 Transform
	public Vector3 offset; // 캐릭터와 카메라 사이의 오프셋
	public float upVector = 3.0f; // 카메라의 높이 설정

	private void LateUpdate()
	{
		Vector3 desiredPosition = target.position + offset;
		transform.position = desiredPosition;
		transform.LookAt(target.position + Vector3.up * upVector);
	}
}