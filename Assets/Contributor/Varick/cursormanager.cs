using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursormanager : MonoBehaviour
{
    public static cursormanager Instance;

    void Awake(){
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }

    public Texture2D cursorTexture, cursorHoverTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    void Start()
    {
        defaultCursor();
    }

    public void defaultCursor()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    public void hoverCursor()
    {
        // Pass 'null' to the texture parameter to use the default system cursor.
        Cursor.SetCursor(cursorHoverTexture, hotSpot, cursorMode);
    }
}
