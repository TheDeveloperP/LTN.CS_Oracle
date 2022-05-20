// ***********************************************************************
// Copyright (c) 2016 江苏金恒,All rights reserved.
// Assembly:LTN.CS.Core.Helper
// Author:kolio
// Created:2016/11/4 13:22:38
// Description:
// ***********************************************************************
// Last Modified By:kolio
// Last Modified On:2016/11/4 13:22:38
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTN.CS.Core.Helper
{
    public static class MyArrayHelper
    {
        /// <summary>
        /// 从此实例检索子数组
        /// </summary>
        /// <param name="source">要检索的数组</param>
        /// <param name="startIndex">起始索引号</param>
        /// <param name="length">检索最大长度</param>
        /// <returns>与此实例中在 startIndex 处开头、长度为 length 的子数组等效的一个数组</returns>
        public static Array SubArray(this Array source, Int32 startIndex, Int32 length)
        {
            if (source == null || source.Length < 1)
            {
                return null;
            }
            if (startIndex < 0 || startIndex > source.Length || length < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            Array Destination;
            if (startIndex + length <= source.Length)
            {
                Destination = Array.CreateInstance(source.GetValue(0).GetType(), length);
                Array.Copy(source, startIndex, Destination, 0, length);
            }
            else
            {
                Destination = Array.CreateInstance(source.GetValue(0).GetType(), source.Length - startIndex);
                Array.Copy(source, startIndex, Destination, 0, source.Length - startIndex);
            }

            return Destination;
        }      
    }
}
