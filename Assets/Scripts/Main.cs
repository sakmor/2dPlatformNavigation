using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] internal GameObject MoveCursor;
    [SerializeField] private Player Player;
    [SerializeField] internal Collider2D Ladder;
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
        if (Input.GetMouseButtonDown(0) == false) return;
        Vector3 mousePoint = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
        if (Physics2D.Raycast(mousePoint, Vector2.zero)) return;

        RaycastHit2D hit = Physics2D.Raycast(mousePoint, Vector2.down, 1);
        if (hit == false) return;

        Vector3 pos = hit.point;
        if (Player.IsLadder) Player.MoveTo(pos, "Player@Back");
        if (Mathf.Abs(pos.y - Player.transform.position.y) <= 1) Player.MoveTo(pos, "Player@Walk");
        MoveCursor.transform.position = pos;
        MoveCursor.SetActive(true);
    }
}
