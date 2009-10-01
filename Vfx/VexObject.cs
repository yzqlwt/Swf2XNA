/* Copyright (C) 2008 Robin Debreuil -- Released under the BSD License */

using System;
using System.Collections.Generic;
using System.Text;

namespace DDW.Vex
{
	public class VexObject : IVexObject
	{
		public static string SoundPrefix = "snd_";
		public static string BitmapPrefix = "bmp_";
		public static string MaskPrefix = "mask_";
		private static string Resources = "Resources";

		public Rectangle ViewPort;
		public float FrameRate = 600;
		public Color BackgroundColor = new Color(0, 0, 0, 0);
		public string Name = "Nameless";
		public string ResourceFolder = "Nameless_Resources";

		public Timeline Root;
		public Dictionary<uint, IDefinition> Definitions = new Dictionary<uint, IDefinition>();

		//public VexObject()
		//{
		//}
		public VexObject(string name)
		{
			this.Name = name;
			this.ResourceFolder = Resources + "_" + name;
		}

		private uint idCounter = 0;
		public uint NextId()
		{
			return idCounter++;
		}

        public uint GetFrameFromMilliseconds(uint time)
        {
            return (uint)Math.Round(time / (1000 / FrameRate));
        }
	}
}
