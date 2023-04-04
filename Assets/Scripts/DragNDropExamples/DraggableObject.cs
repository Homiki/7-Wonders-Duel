using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float _startYPos;
    private BoardController _board;

    void Start()
    {
        _board = GetComponentInParent<BoardController>();
        _rigidbody = GetComponent<Rigidbody>();

        _startYPos = 1; // Better to not hardcode that one but whatever
    }

    private void OnMouseDrag()
    {
        Vector3 newWorldPosition = new Vector3(_board.CurrentMousePosition.x, _startYPos + 1, _board.CurrentMousePosition.z);

        var difference = newWorldPosition - transform.position;

        var speed = 10 * difference;
        _rigidbody.velocity = speed;
        _rigidbody.rotation = Quaternion.Euler(new Vector3(speed.z, 0, -speed.x));
    }
}