//#if UNITY_EDITOR || DEVELOPMENT_BUILD
using UnityEngine;

public static class FPSLabelStarter
{
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	private static void OnAfterSceneLoadRuntimeMethod()
	{
		FPSLabel fpsLabel = GameObject.FindObjectOfType<FPSLabel>();
		if (fpsLabel == null)
		{
			GameObject fpsLabelGO = new GameObject("FPS Label");
			fpsLabelGO.AddComponent<FPSLabel>();
		}
	}
}
//#endif