using System;
using Unity.Entities;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Editor
{
    public static class TempTools
    {

        //SortChildrenStands

        [MenuItem("EditorsScript/CloneZ10")]
        public static void CloneZ()
        {
            var cloneCount = 10;
            cloneCount++;
            foreach (var obj in Selection.gameObjects)
            {
                for (var i = 1; i < cloneCount; i++)
                {
                    var newObj = Object.Instantiate(obj, obj.transform.parent);
                    newObj.transform.position += new Vector3(0, 0, 1.01f*i);
                }

            }
        }
        [MenuItem("EditorsScript/CloneX10")]
        public static void CloneX()
        {
            var cloneCount = 10;
            cloneCount++;
            foreach (var obj in Selection.gameObjects)
            {
                for (var i = 1; i < cloneCount; i++)
                {
                    var newObj = Object.Instantiate(obj, obj.transform.parent);
                    newObj.transform.position += new Vector3(1.01f*i, 0, 0);
                }

            }
        }
        
        [MenuItem("EditorsScript/ConvertToEntity")]
        public static void ConvertToEntity()
        {
            foreach (var obj in Selection.gameObjects)
            {
                for (var i = 0; i < obj.transform.childCount; i++)
                {
                    var entity = obj.transform.GetChild(i).gameObject.AddComponent(typeof(ConvertToEntity)) as ConvertToEntity;
                    entity.ConversionMode = Unity.Entities.ConvertToEntity.Mode.ConvertAndDestroy;
                }
            }
        }
    }
}