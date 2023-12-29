using UnityEngine;
using System;
using System.Globalization;

namespace Scopa {
    public static class VectorExtensions {

        public static Vector3 Absolute(this Vector3 vec) {
            return new Vector3(
                Mathf.Abs(vec.x), 
                Mathf.Abs(vec.y),
                Mathf.Abs(vec.z)
            );
        }

        public static Vector3 Cross(this Vector3 lhs, Vector3 rhs) {
            return Vector3.Cross( lhs, rhs );
        }

        public static float Dot(this Vector3 lhs, Vector3 rhs) {
            return Vector3.Dot( lhs, rhs );
        }

        public static Vector3 Normalise(this Vector3 vec) {
            return vec.normalized;
        }
 
        public static Vector3 Parse3(string x, string y, string z, NumberStyles ns, IFormatProvider provider) {
            return new Vector3(
                float.Parse(x, ns, provider), 
                float.Parse(y, ns, provider),
                float.Parse(z, ns, provider)
            );
        }

        public static bool TryParse3(string x, string y, string z, out Vector3 result) {
            result = Vector3.zero;
            if (!float.TryParse(x, NumberStyles.Float, CultureInfo.InvariantCulture, out result.x))
                return false;
            if (!float.TryParse(y, NumberStyles.Float, CultureInfo.InvariantCulture, out result.y))
                return false;
            if (!float.TryParse(z, NumberStyles.Float, CultureInfo.InvariantCulture, out result.z))
                return false;
            return true;
        }

        public static Vector4 Parse4(string x, string y, string z, string w, NumberStyles ns, IFormatProvider provider) {
            return new Vector4(
                float.Parse(x, ns, provider), 
                float.Parse(y, ns, provider),
                float.Parse(z, ns, provider),
                float.Parse(w, ns, provider)
            );
        }

        public static bool EquivalentTo(this Vector3 a, Vector3 b, float delta = 0.0001f) {
            return Equivalent(a, b, delta);
        }

        public static bool Equivalent(Vector3 a, Vector3 b, float delta = 0.0001f) {
            if ( Mathf.Abs( a.x - b.x) > delta)
                return false;
            if ( Mathf.Abs( a.y - b.y) > delta)
                return false;
            if ( Mathf.Abs( a.z - b.z) > delta)
                return false;
            
            return true;
        }

        public static float GetMaxDelta(Vector3 a, Vector3 b) {
            return Mathf.Max( Mathf.Abs( a.y - b.y), Mathf.Max( Mathf.Abs( a.x - b.x), Mathf.Abs( a.z - b.z) ) );           
        }

        public static float GetTotalDelta(Vector3 a, Vector3 b) {
            return Mathf.Abs( a.x - b.x) + Mathf.Abs( a.y - b.y) + Mathf.Abs( a.z - b.z);
        }

        // public static Vector3 ToPrecisionVector3(this Vector3 vec) {
        //     return vec;
        // }

        public static string ToStringIntWithNoPunctuation(this Vector3 vec) {
            return Vector3Int.RoundToInt(vec).ToString().Replace(",", "").TrimStart('(').TrimEnd(')');
        }

        // public static Vector3 ToStandardVector3(this Vector3 vec) {
        //     return vec * ScopaCore.scalingFactor;
        // }

    }
}