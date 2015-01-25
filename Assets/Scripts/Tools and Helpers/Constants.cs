using UnityEngine;

public class Constants : MonoBehaviour 
{
	public const string LVL_THEBUTTON     = "LevelTheButton";
	public const string LVL_CURSORTIMEOUT = "LevelCursorTimeout";
	public const string LVL_RUN           = "LevelRun";
	public const string LVL_JUMP          = "LevelJump";
	public const string LVL_MOUSELOOK     = "LevelMouseLook";
	public const string LVL_DOWNBELOW     = "LevelDownBelow";
	
	public const string ENDSCREEN = "Prefabs/EndScreen";
	
	public const float ALPHA_RATIO = 0.0039f; // (1 / 255)
	public static Vector3 PLAYER_INITPOS = new Vector3(0.0f, 1.55f, 0.0f);
}

public enum BGMType
{
	SingleCricket,
	GuitarOminous,
	Ambience02
}

public enum LevelInProgress
{
	TheButton,
	CursorTimeout,
	Run,
	Jump,
	MouseLook,
	DownBelow,
	Listen,
	ToTheLight
}
