using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public Texture2D cursorTexture; // Назначьте спрайт для курсора в инспекторе
    public Vector2 hotspot = Vector2.zero; // При необходимости, настройте точку клика

    private void Start()
    {
        Cursor.SetCursor(cursorTexture, hotspot, CursorMode.Auto);
    }
}
