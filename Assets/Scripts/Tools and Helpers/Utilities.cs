using UnityEngine;

public class Utilities : MonoBehaviour 
{
	public static Vector3 GetBLScreenPos ()
	{
		return Camera.main.ScreenToWorldPoint (Vector3.zero);
	}

	public static Vector3 GetTRScreenPos ()
	{
		return Camera.main.ScreenToWorldPoint (Vector3.one);
	}

	public static Vector3 GetScreenPos (float p_x, float p_y, float p_z = 0.0f)
	{
		return Camera.main.ScreenToWorldPoint (new Vector3(p_x, p_y, p_z));
	}
	
	public static void ShowCursor (bool p_bShowCursor)
	{
		Screen.showCursor = p_bShowCursor;
		Screen.lockCursor = !p_bShowCursor;
	}
}
