using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

using HutongGames.PlayMakerEditor;

[InitializeOnLoad]
public class PlayMakerPhotonEditorSetup
{
	static PlayMakerPhotonEditorSetup()
	{
		#if PLAYMAKER_1_9_OR_NEWER
			FsmEditorSettings.ShowNetworkSync = true;
		#endif
	}

}