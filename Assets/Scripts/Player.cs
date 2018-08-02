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
	[SerializeField] internal bool IsLadder, IsGround;
	[SerializeField] private Collider2D Collider2D;
	[SerializeField] private Rigidbody2D Rigidbody2D;
	[SerializeField] private GameObject DialogICANT, DialogLadder;

	private Vector2 GoalPos;


	private void Start()
	{
		Stop();
	}
	internal void MoveTo(Vector2 pos, string animation)
	{
		Animator.Play(animation);
		GoalPos = pos;
	}
	private void Update()
	{
		Movement();
		LadderEvent();
	}

	private void LadderEvent()
	{
		if (IsLadder == true)
		{
			Collider2D.isTrigger = true;
			Rigidbody2D.gravityScale = 0;
			ShowDialogLadder();
		}
		if (IsLadder == false)
		{
			Collider2D.isTrigger = false;
			HideDialogLadder();
			Rigidbody2D.gravityScale = 1;
		}
		if (IsLadder == false && IsGround == false) Stop();
	}

	private void Movement()
	{
		if (Vector2.Distance(transform.position, GoalPos) < 0.01f) { Stop(); return; }
		Vector3 CurrentPos = transform.position;

		Sprite.flipX = false;
		if (CurrentPos.x > GoalPos.x) Sprite.flipX = true;

		transform.position = Vector2.MoveTowards(CurrentPos, GoalPos, speed);
	}

	internal void Stop()
	{
		GoalPos = transform.position;
		Animator.Play("Player@Idle");
		Main.MoveCursor.SetActive(false);
	}


	internal void ShowDialogICANT()
	{
		DialogLadder.SetActive(false);
		DialogICANT.SetActive(true);
	}
	internal void ShowDialogLadder()
	{
		DialogLadder.SetActive(true);
		DialogICANT.SetActive(false);
	}
	internal void HideDialogLadder()
	{
		DialogLadder.SetActive(false);
	}
	internal void HideDialogICANT()
	{
		DialogICANT.SetActive(false);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other == Main.Ladder) IsLadder = true;
	}
	private void OnTriggerStay2D(Collider2D other)
	{
		if (other == Main.Ladder) ShowDialogLadder();
	}
	private void OnTriggerExit2D(Collider2D other)
	{
		if (other == Main.Ladder) IsLadder = false;
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.collider == Main.Ground) IsGround = true;
	}
	private void OnCollisionStay2D(Collision2D other)
	{

	}
	private void OnCollisionExit2D(Collision2D other)
	{
		if (other.collider == Main.Ground) IsGround = false;
	}

}