/* Copyright (C) 2008 Robin Debreuil -- Released under the BSD License */

using System;
using System.Collections.Generic;
using System.CodeDom.Compiler;

namespace DDW.Swf
{
	public struct Trace : IAction, IStackManipulator
	{
		public ActionKind ActionId{get{return ActionKind.Trace;}}
		public uint Version {get{return 4;}}
		public uint Length {get{return 1;}}

		public uint StackPops { get { return 1; } }
		public uint StackPushes { get { return 0; } }
		public int StackChange { get { return -1; } }

		public void ToFlashAsm(IndentedTextWriter w)
		{
			w.WriteLine("trace");
		}

		public void ToSwf(SwfWriter w)
		{
            w.AppendByte((byte)ActionKind.Trace);
		}

		public void Dump(IndentedTextWriter w)
		{
			w.WriteLine(Enum.GetName(typeof(ActionKind), this.ActionId));
		}
	}
}
