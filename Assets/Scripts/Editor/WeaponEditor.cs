/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(WeaponData), true)]
public class WeaponEditor : Editor
{
    WeaponData weapon;
    public override void OnInspectorGUI()
    {
        weapon.name = EditorGUILayout.TextField("Weapon: ", weapon.weaponName);
        EditorUtility.SetDirty(weapon);


    }
}
#endif*/