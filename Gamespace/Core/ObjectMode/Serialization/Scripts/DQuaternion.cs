using System;
using UnityEngine;

namespace Gamespace.Core.ObjectMode.Serialization
{
    [Serializable]
    public struct DQuaternion
    {
        public double x;
        public double y;
        public double z;
        public double w;
        
        public DQuaternion(Quaternion q)
        {
            x = q.x;
            y = q.y;
            z = q.z;
            w = q.w;
        }
        public DQuaternion(double x, double y, double z, double w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
        public DQuaternion(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public static implicit operator Quaternion(DQuaternion dq)
        {
            return new Quaternion((float)dq.x, (float)dq.y, (float)dq.z, (float)dq.w);
        }
        public static implicit operator DQuaternion(Quaternion q)
        {
            return new DQuaternion(q);
        }
        public static Quaternion operator *(Quaternion lhs, DQuaternion rhs) => new Quaternion((float) ((double) lhs.w * (double) rhs.x + (double) lhs.x * (double) rhs.w + (double) lhs.y * (double) rhs.z - (double) lhs.z * (double) rhs.y), (float) ((double) lhs.w * (double) rhs.y + (double) lhs.y * (double) rhs.w + (double) lhs.z * (double) rhs.x - (double) lhs.x * (double) rhs.z), (float) ((double) lhs.w * (double) rhs.z + (double) lhs.z * (double) rhs.w + (double) lhs.x * (double) rhs.y - (double) lhs.y * (double) rhs.x), (float) ((double) lhs.w * (double) rhs.w - (double) lhs.x * (double) rhs.x - (double) lhs.y * (double) rhs.y - (double) lhs.z * (double) rhs.z));
        public static DQuaternion operator *(DQuaternion lhs, DQuaternion rhs) => new DQuaternion(lhs.w * rhs.x + lhs.x * rhs.w + lhs.y * rhs.z - lhs.z * rhs.y, lhs.w * rhs.y + lhs.y * rhs.w + lhs.z * rhs.x - lhs.x * rhs.z, lhs.w * rhs.z + lhs.z *  rhs.w +  lhs.x *  rhs.y -  lhs.y *  rhs.x, lhs.w *  rhs.w -  lhs.x *  rhs.x -  lhs.y *  rhs.y -  lhs.z *  rhs.z);
        public static DVector3 operator *(DQuaternion rotation, DVector3 point)
        {
            double num1 = rotation.x * 2f;
            double num2 = rotation.y * 2f;
            double num3 = rotation.z * 2f;
            double num4 = rotation.x * num1;
            double num5 = rotation.y * num2;
            double num6 = rotation.z * num3;
            double num7 = rotation.x * num2;
            double num8 = rotation.x * num3;
            double num9 = rotation.y * num3;
            double num10 = rotation.w * num1;
            double num11 = rotation.w * num2;
            double num12 = rotation.w * num3;
            DVector3 vector3;
            vector3.x =  ((1.0 - (num5 +  num6)) *  point.x + (num7 -  num12) *  point.y + (num8 +  num11) *  point.z);
            vector3.y =  ((num7 +  num12) *  point.x + (1.0 - (num4 +  num6)) *  point.y + (num9 -  num10) *  point.z);
            vector3.z =  ((num8 -  num11) *  point.x + (num9 +  num10) *  point.y + (1.0 - (num4 +  num5)) *  point.z);
            return vector3;
        }
        public static DVector3 operator *(DQuaternion rotation, Vector3 point)
        {
            double num1 = rotation.x * 2f;
            double num2 = rotation.y * 2f;
            double num3 = rotation.z * 2f;
            double num4 = rotation.x * num1;
            double num5 = rotation.y * num2;
            double num6 = rotation.z * num3;
            double num7 = rotation.x * num2;
            double num8 = rotation.x * num3;
            double num9 = rotation.y * num3;
            double num10 = rotation.w * num1;
            double num11 = rotation.w * num2;
            double num12 = rotation.w * num3;
            DVector3 vector3;
            vector3.x =  ((1.0 - (num5 +  num6)) *  point.x + (num7 -  num12) *  point.y + (num8 +  num11) *  point.z);
            vector3.y =  ((num7 +  num12) *  point.x + (1.0 - (num4 +  num6)) *  point.y + (num9 -  num10) *  point.z);
            vector3.z =  ((num8 -  num11) *  point.x + (num9 +  num10) *  point.y + (1.0 - (num4 +  num5)) *  point.z);
            return vector3;
        }
    }
}