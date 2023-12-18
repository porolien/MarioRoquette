using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class cursorManager : MonoBehaviour
{
    public Texture2D cursorTexture; // Nouvelle texture du curseur

    public Vector2 hotSpot = Vector2.zero; // Position du point chaud du curseur

    private void Start()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
    }
}
