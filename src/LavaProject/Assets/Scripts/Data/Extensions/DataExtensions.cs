using Data.Dynamic;
using Data.Dynamic.PlayerData;
using UnityEngine;

namespace Data.Extensions
{
    public static class DataExtensions
    {
        public static Vector3Data AsVectorData(this Vector3 vector)
        {
            return new Vector3Data(vector.x, vector.y, vector.z);
        }
        
        public static Vector3 AsVector3(this Vector3Data vector)
        {
            return new Vector3(vector.X, vector.Y, vector.Z);
        }
        
        public static Vector3 AddHeight( this Vector3 vector, float height)
        {
            return new Vector3(vector.x, vector.y + height, vector.z);
        }
        
        public static string ToJson(this object obj)
        {
            return JsonUtility.ToJson(obj);
        }
        
        public static T FromJson<T>(this string json)
        {
            return JsonUtility.FromJson<T>(json);
        }
    }
}
