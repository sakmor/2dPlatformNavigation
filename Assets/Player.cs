using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private Main Main;
	[SerializeField] private float speed = 0.05f;
	[SerializeField] private Animator Animator;
	[SerializeField] private SpriteRenderer Sprite;
	[SerializeField] internal bool IsLadder;

	private Vector2 GoalPos;

	private void Start()
	{
		GoalPos = transform.position;
	}
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
		Vector3 CurrentPos = transform.position;

		Sprite.flipX = false;
		if (CurrentPos.x > GoalPos.x) Sprite.flipX = true;

		Animator.Play("Player@Walk_Right");

		transform.position = Vector2.MoveTowards(CurrentPos, GoalPos, speed);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other != Main.Ladder) return;
		IsLadder = true;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other != Main.Ladder) return;
		IsLadder = false;
	}

}