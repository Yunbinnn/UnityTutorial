using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CURSOR
{
    HOLD,
    ATTACK,
}

public class Mouse : MonoBehaviour
{
    [SerializeField] Texture2D[] mouseCursor;

    void Start()
    {
        SetCursor(CURSOR.HOLD);
    }

    void Update()
    {
        
    }

    public void SetCursor(CURSOR cursorImage)
    {
        Cursor.SetCursor(mouseCursor[(int)cursorImage], Vector2.zero, CursorMode.Auto);
    }
}