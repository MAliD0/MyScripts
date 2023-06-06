using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
[CreateAssetMenu(menuName = "Dialogue system/NPC")]
public class NpcData : ScriptableObject
{
    public int id;
    public new string name;
    public AnimatorController portrait;
}
