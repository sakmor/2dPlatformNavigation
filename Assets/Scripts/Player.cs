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
    [SerializeField] private Collider2D Collider2D;

    private Vector2 GoalPos;

    private void Start()
    {
        GoalPos = transform.position;
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
        Collider2D.enabled = false;
    }

    private void Stop()
    {
        Animator.Play("Player@Idle");
        Main.MoveCursor.SetActive(false);
        Collider2D.enabled = true;
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