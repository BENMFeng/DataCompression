﻿using System;

namespace gfoidl.DataCompression
{
    internal static class DataPointExtensions
    {
        public static double Gradient(this DataPoint a, DataPoint b)
        {
            if (a == b) throw new ArgumentException(Strings.Gradient_A_eq_B, nameof(b));

            return (b.Y - a.Y) / (b.X - a.X);
        }
    }
}