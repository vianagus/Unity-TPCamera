using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        HideCursor(true);
    }

    public static void HideCursor(bool isHide)
    {
        if(isHide)
            Cursor.lockState = CursorLockMode.Locked;
        else
            Cursor.lockState = CursorLockMode.None;

    }
}
