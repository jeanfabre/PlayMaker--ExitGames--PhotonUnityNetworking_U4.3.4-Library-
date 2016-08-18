// (c) Copyright HutongGames, LLC 2010-2016. All rights reserved.

using UnityEngine;
using System.Collections.Generic;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Photon")]
	[Tooltip("Get lobby rooms properties.")]
	//[HelpUrl("https://hutonggames.fogbugz.com/default.asp?W900")]
	public class PhotonNetworkGetRoomListProperties : FsmStateAction
	{


		[ActionSection("Builtin Properties")]
		[Tooltip("All rooms' name")]
		[UIHint(UIHint.Variable)]
		[ArrayEditor(VariableType.String)]
		public FsmArray names;

		[Tooltip("All rooms' playerCount")]
		[UIHint(UIHint.Variable)]
		[ArrayEditor(VariableType.Int)]
		public FsmArray playerCount;

		[Tooltip("All rooms' maxPlayers")]
		[UIHint(UIHint.Variable)]
		[ArrayEditor(VariableType.Int)]
		public FsmArray maxPlayers;

		[Tooltip("All rooms' open")]
		[UIHint(UIHint.Variable)]
		[ArrayEditor(VariableType.Bool)]
		public FsmArray open;


		public FsmEvent notInLobbyEvent;

		private RoomInfo[] rooms;

		public override void Reset()
		{

			names = new FsmArray() {UseVariable=true};
			playerCount = new FsmArray() {UseVariable=true};
			maxPlayers = new FsmArray() {UseVariable=true};
			open = new FsmArray() {UseVariable=true};
		}
		
		public override void OnEnter()
		{

			if (!PhotonNetwork.insideLobby)
			{
				Fsm.Event(notInLobbyEvent);

				Finish ();
				return;
			}

			rooms = PhotonNetwork.GetRoomList();


			if (!names.IsNone) names.Resize(rooms.Length);

			int i=0;
			
			foreach (RoomInfo room in rooms)
			{

				if (!names.IsNone) names.Set(i,room.name);
			
				i++;
			}

			if (!names.IsNone)  names.SaveChanges();

		}
		
	}
}