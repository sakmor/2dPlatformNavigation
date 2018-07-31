using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private float speed = 0.05f;
	[SerializeField] private Animator Animator;

	private Vector2 GoalPos;


	internal void MoveTo(Vector2 pos)
	{
		GoalPos = pos;
	}
	private void Update()
	{
		Movement();
	}

	private void Movement()
	{
		if (Vector2.Distance(transform.position, GoalPos) < 0.01f) { Animator.Play("Player@Idle"); return; }

		Animator.Play("Player@Walk_Right");
		Vector3 CurrentPos = transform.position;
		transform.position = Vector2.MoveTowards(CurrentPos, GoalPos, speed);
	}
}