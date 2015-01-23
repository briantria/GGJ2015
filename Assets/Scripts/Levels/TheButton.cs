using UnityEngine;
using System.Collections;

public class TheButton : MonoBehaviour 
{
	public void OnClick ()
	{
		LevelMngr.Instance.LoadNextLevel (Constants.LVL_THECURSOR);
	}
}
