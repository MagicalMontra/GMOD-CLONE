using System;
using UnityEngine;

namespace Gamespace.Core.ObjectMode.Serialization
{
    [Serializable]
    public struct DVector3
    {
        public double x;
        public double y;
        public double z;

        public DVector3(Vector3 v)
        {
            x = v.x;
            y = v.y;
            z = v.z;
        }
        public DVector3(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public DVector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static implicit operator Vector3(DVector3 dv)
        {
            return new Vector3((float)dv.x, (float)dv.y, (float)dv.z);
        }
        public static implicit operator DVector3(Vector3 v)
        {
            return new DVector3(v);
        }
        public static DVector3 operator +(DVector3 a, DVector3 b)
        {
            a.x += b.x;
            a.y += b.y;
            a.z += b.z;

            return a;
        }
        public static DVector3 operator -(DVector3 a, DVector3 b)
        {
            a.x -= b.x;
            a.y -= b.y;
            a.z -= b.z;

            return a;
        }
        public static DVector3 operator +(DVector3 a, Vector3 b)
        {
            a.x += b.x;
            a.y += b.y;
            a.z += b.z;

            return a;
        }
        public static DVector3 operator -(DVector3 a, Vector3 b)
        {
            a.x -= b.x;
            a.y -= b.y;
            a.z -= b.z;

            return a;
        }
    }
}