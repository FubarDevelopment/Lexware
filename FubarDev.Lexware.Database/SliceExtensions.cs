// <copyright file="SliceExtensions.cs" company="Fubar Development Junker">
// Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>

namespace FubarDev.Lexware.Database
{
    internal static class SliceExtensions
    {
        public static Slice<T> ToSlice<T>(this T[] array)
        {
            return new Slice<T>(array);
        }

        public static Slice<T> ToSlice<T>(this T[] array, int offset, int length)
        {
            return new Slice<T>(array, offset, length);
        }

        public static Slice<T> ToSlice<T>(this Slice<T> slice)
        {
            return slice;
        }

        public static Slice<T> ToSlice<T>(this Slice<T> slice, int offset, int length)
        {
            return new Slice<T>(slice, offset, length);
        }
    }
}
