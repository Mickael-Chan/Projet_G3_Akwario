using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Power", menuName ="Create New Power")]
public class Power : ScriptableObject
{
    public new string name;
    public Sprite image;
    public Color color;
}
