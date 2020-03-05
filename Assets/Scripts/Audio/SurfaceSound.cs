using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSurfaceSound", menuName = "ScriptableObjects/SurfaceSound", order = 1)]
public class SurfaceSound : ScriptableObject
{
    public AudioClip[] clips;
}
