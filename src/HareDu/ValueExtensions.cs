﻿// Copyright 2013-2017 Albert L. Hives
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
namespace HareDu
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public static class ValueExtensions
    {
        internal static string ConvertTo(this HighAvailabilityModes mode)
        {
            switch (mode)
            {
                case HighAvailabilityModes.All:
                    return "all";
                    
                case HighAvailabilityModes.Exactly:
                    return "exactly";
                    
                case HighAvailabilityModes.Nodes:
                    return "nodes";
                    
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }
        
        internal static HighAvailabilityModes ConvertTo(this string mode)
        {
            switch (mode.ToLower())
            {
                case "all":
                    return HighAvailabilityModes.All;
                    
                case "exactly":
                    return HighAvailabilityModes.Exactly;
                    
                case "nodes":
                    return HighAvailabilityModes.Nodes;
                    
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }

        internal static string ConvertTo(this HighAvailabilitySyncModes mode)
        {
            switch (mode)
            {
                case HighAvailabilitySyncModes.Manual:
                    return "manual";
                    
                case HighAvailabilitySyncModes.Automatic:
                    return "automatic";
                    
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }

        public static bool IsNull<T>(this T value) => value == null;
        
        public static bool HasValue<T>(this Result<T> source) => source != null && source.Data != null;

        public static bool HasValue<T>(this Result<IEnumerable<T>> source) => source?.Data != null && source.Data.Any();

        public static IEnumerable<T> Where<T>(this Result<IEnumerable<T>> source, Func<T, bool> predicate)
            => source?.Data == null || !source.Data.Any() ? Enumerable.Empty<T>() : source.Data.Where(predicate);

        public static T Single<T>(this Task<Result<IEnumerable<T>>> source) => source.Unravel().Single();

        public static T SingleOrDefault<T>(this Task<Result<IEnumerable<T>>> source) => source.Unravel().SingleOrDefault();

        public static T SingleOrDefault<T>(this Task<Result<IEnumerable<T>>> source, Func<T, bool> predicate) => source.Unravel().SingleOrDefault(predicate);

        public static T FirstOrDefault<T>(this Task<Result<IEnumerable<T>>> source) => source.Unravel().FirstOrDefault();

        public static T FirstOrDefault<T>(this Task<Result<IEnumerable<T>>> source, Func<T, bool> predicate) => source.Unravel().FirstOrDefault(predicate);

        public static bool Any<T>(this Task<Result<IEnumerable<T>>> source) => source.Unravel().Any();

        public static bool Any<T>(this Task<Result<IEnumerable<T>>> source, Func<T, bool> predicate) => source.Unravel().Any(predicate);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> Where<T>(this Task<Result<IEnumerable<T>>> source, Func<T, bool> predicate)
        {
            Result<IEnumerable<T>> data = source?.Result;
            if (data?.Data == null || !data.Data.Any())
                return Enumerable.Empty<T>();

            IEnumerable<T> list = source.Unravel().Where(predicate);
            
            return list;
        }

        public static T Unwrap<T>(this Task<T> result) => result.Result;

        public static T Unravel<T>(this Task<Result<T>> result)
        {
            var data = result.Unwrap().Data;

            return !data.IsNull() ? result.Unwrap().Data : default(T);
        }
    }
}