using UnityEditor;
using UnityEngine;

namespace ggStrider.Shared.Scripts.Editor
{
    public abstract class InterfaceDrawer : PropertyDrawer
    {
        protected virtual bool AllowSceneObjects => true;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var fieldName = AllowSceneObjects ? "_object" : "_prefab";
            var objectProp = property.FindPropertyRelative(fieldName);
            var interfaceType = fieldInfo.FieldType.GetGenericArguments()[0];

            label.text += $" ({interfaceType.Name})";

            EditorGUI.BeginProperty(position, label, property);
            EditorGUI.BeginChangeCheck();

            var newObj = EditorGUI.ObjectField(
                position, label, 
                objectProp.objectReferenceValue != null ? ((MonoBehaviour)objectProp.objectReferenceValue).gameObject : null,
                typeof(GameObject), 
                AllowSceneObjects
            );

            if (EditorGUI.EndChangeCheck())
            {
                if (newObj == null)
                {
                    objectProp.objectReferenceValue = null;
                }
                else if (newObj is GameObject go && go.TryGetComponent(interfaceType, out var component))
                {
                    objectProp.objectReferenceValue = component as MonoBehaviour;
                }
                else
                {
                    Debug.LogWarning($"[InterfaceDrawer] Object must implement {interfaceType.Name}");
                }
            }

            EditorGUI.EndProperty();
        }
    }
}