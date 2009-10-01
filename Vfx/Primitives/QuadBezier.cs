/* Copyright (C) 2008 Robin Debreuil -- Released under the BSD License */

using System;
using System.Collections.Generic;
using System.Text;

namespace DDW.Vex
{
	public struct QuadBezier : IShapeData
	{
		public Point Anchor0;
		public Point Control;
		public Point Anchor1;

		public QuadBezier(Point anchor0, Point control, Point anchor1)
		{
			this.Anchor0 = anchor0;
			this.Control = control;
			this.Anchor1 = anchor1;
		}
		public SegmentType SegmentType { get { return SegmentType.QuadraticBezier; } }
		public Point StartPoint { get { return Anchor0; } }
		public Point EndPoint { get { return Anchor1; } }

		/// <summary>
		/// Convert from a quadratic bezier to a cubic bezier.
		/// </summary>
		public CubicBezier GetCubicBezier()
		{
			Point c1 = new Point(
				((Control.X - Anchor0.X) * 2 / 3) + Anchor0.X,
				((Control.Y - Anchor0.Y) * 2 / 3) + Anchor0.Y);
			Point c2 = new Point(
				(Anchor1.X - (Anchor1.X - Control.X) * 2 / 3),
				(Anchor1.Y - (Anchor1.Y - Control.Y) * 2 / 3));
			return new CubicBezier(Anchor0, c1, c2, Anchor1);
		}

		public void Reverse()
		{
			Point temp = this.Anchor0;
			this.Anchor0 = this.Anchor1;
			this.Anchor1 = temp;
		}

		public int CompareTo(Object o)
		{
			int result = 0;
			if (o is IShapeData)
			{
				IShapeData co = (IShapeData)o;
				if (this.StartPoint != co.StartPoint)
				{
					result = this.StartPoint.CompareTo(co.StartPoint);
				}
				else if (this.EndPoint != co.EndPoint)
				{
					result = this.EndPoint.CompareTo(co.EndPoint);
				}
				else if (o is QuadBezier)
				{
					QuadBezier cb = (QuadBezier)o;
					if (this.Control != cb.Control)
					{
						result = this.Control.CompareTo(cb.Control);
					}
				}
				else if (this.SegmentType != co.SegmentType)
				{
					result = ((int)this.SegmentType) > ((int)co.SegmentType) ? 1 : -1;
				}
			}
			else
			{
				throw new ArgumentException("Objects being compared are not of the same type");
			}
			return result;
		}
		public override string ToString()
		{
			return "{QB:" + this.Anchor0 + ",.," + this.Anchor1 + "}";
		}
	}
}
