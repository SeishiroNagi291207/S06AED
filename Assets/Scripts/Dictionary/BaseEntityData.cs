using UnityEngine;
using Sirenix.OdinInspector;
using System;
[CreateAssetMenu(fileName = "BaseEntity", menuName = "Scriptable Objects/BaseEntity")]
[InlineEditor]
public class BaseEntityData : ScriptableObject
{
    [FoldoutGroup("Settings")]
    public int ID;
    [FoldoutGroup("Settings")]
    public string EntityName;
    [FoldoutGroup("Settings / References"), PreviewField(150)]
    public Sprite Icon;
    [FoldoutGroup("Settings "), TextArea(3, 10)]
    public string Description;

}