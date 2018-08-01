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
	}


	private void Movement()
	{
		if (Vector2.Distance(transform.position, GoalPos) < 0.01f) { Stop(); return; }
		Vector3 CurrentPos = transform.position;

		Sprite.flipX = false;
		if (CurrentPos.x > GoalPos.x) Sprite.flipX = true;

		transform.position = Vector2.MoveTowards(CurrentPos, GoalPos, speed);

		if (IsGround == false & IsLadder == false) Stop();

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
	internal void HideDialogICANT()
	{
		DialogICANT.SetActive(false);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other == Main.Ladder) IsLadder = true;
		if (other == Main.Ground) IsGround = true;
	}
	private void OnTriggerStay2D(Collider2D other)
	{
		if (other == Main.Ladder) ShowDialogLadder();
		if (other == Main.Ground) IsGround = true;
	}
	private void OnTriggerExit2D(Collider2D other)
	{
		if (other == Main.Ladder) { IsLadder = false; DialogLadder.SetActive(false); }
		if (other == Main.Ground) IsGround = false;
	}

}