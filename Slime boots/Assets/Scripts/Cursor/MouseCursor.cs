using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    public Animator cursorAnimator;

    void Start()
    {
        Cursor.visible = false;
    }
    
    void Update()
    {
        Vector2 cursorePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorePos;
    }
}
