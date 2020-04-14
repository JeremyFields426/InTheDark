using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ItemWheel))]
public class CircularMenuEditor : Editor
{
    private ItemWheel weaponWheel;


    private void OnEnable()
    {
        weaponWheel = (ItemWheel)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUI.changed)
        {
            weaponWheel.UpdateMenu();
        }
    }
}
