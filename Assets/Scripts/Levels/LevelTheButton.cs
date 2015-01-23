using UnityEngine;

public class LevelTheButton : MonoBehaviour 
{
	public void OnClick ()
	{
		LevelMngr.Instance.LoadNextLevel (Constants.LVL_CURSORTIMEOUT);
	}
}
