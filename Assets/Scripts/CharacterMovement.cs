using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private Animator animator;
	public float turnSpeed = 10f;

	// Start is called before the first frame update
	void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CharacterMovement();
    }

    void CharacterMovement()
    {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		// 카메라의 방향을 기준으로 이동 벡터 계산
		Vector3 cameraForward = Camera.main.transform.forward;
		Vector3 cameraRight = Camera.main.transform.right;

		cameraForward.y = 0; // 수직 방향의 영향 제거
		cameraRight.y = 0;
		cameraForward.Normalize(); // 정규화
		cameraRight.Normalize();

		// 카메라 방향을 기준으로한 이동 벡터
		Vector3 movement = (cameraForward * moveVertical) + (cameraRight * moveHorizontal);

		if (movement.magnitude > 0.1f)
		{
			Quaternion newRotation = Quaternion.LookRotation(movement);
			transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, turnSpeed * Time.deltaTime);

			transform.Translate(movement.normalized * moveSpeed * Time.deltaTime, Space.World);

			animator.SetFloat("Speed", movement.magnitude);
		}
		else
		{
			animator.SetFloat("Speed", 0);
		}
	}
}
