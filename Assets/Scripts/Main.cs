using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
	[SerializeField] internal GameObject MoveCursor;
	[SerializeField] private Player Player;
	[SerializeField] internal Collider2D Ladder, Ground;
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		InputUpdate();
	}

	void InputUpdate()
	{
		if (Input.GetMouseButton(0) == false) return;
		Debug.Log("GetMouseButtonDown");

		Vector3 mousePoint = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
		if (Physics2D.Raycast(mousePoint, Vector2.zero, Mathf.Infinity, 1, -1000f, 1000f)) { Debug.Log("hitBlock"); return; }

		RaycastHit2D hit = Physics2D.Raycast(mousePoint, Vector2.down, Mathf.Infinity, 1, -1000f, 1000f);
		if (hit == false) { Debug.Log("Did not hit Block down "); return; }

		Vector3 pos = hit.point;


		MoveCursor.transform.position = pos;
		MoveCursor.SetActive(true);
		if (Mathf.Abs(pos.y - Player.transform.position.y) >= 1 && Player.IsLadder == false)
		{
			Player.ShowDialogICANT();
			return;
		}

		Player.HideDialogICANT();
		Player.MoveTo(pos, "Player@Walk");
	}
}
