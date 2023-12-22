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
        Launch();
    }

    public void Launch()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            SetCursor(CURSOR.ATTACK);
        }
        else if(Input.GetButtonUp("Fire1"))
        {
            SetCursor(CURSOR.HOLD);
        }
    }

    public void SetCursor(CURSOR cursorImage)
    {
        Cursor.SetCursor(mouseCursor[(int)cursorImage], Vector2.zero, CursorMode.ForceSoftware);
    }
}