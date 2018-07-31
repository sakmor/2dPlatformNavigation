﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
	[SerializeField] private GameObject g;
	[SerializeField] private Player Player;
	[SerializeField] internal Collider2D Ladder;
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButton(0) == false) return;
		Vector3 mousePoint = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
		if (Physics2D.Raycast(mousePoint, Vector2.zero)) return;

		RaycastHit2D hit = Physics2D.Raycast(mousePoint, Vector2.down);
		if (hit == false) return;

		Vector3 pos = hit.point;
		if (Mathf.Abs(pos.y - Player.transform.position.y) <= 1) Player.MoveTo(pos);
		if (Player.IsLadder) Player.MoveTo(pos);
		g.transform.position = pos;

	}

	void OnTriggerStay2D(Collider2D other)
	{

	}
}
