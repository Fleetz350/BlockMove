using System;
using UnityEngine;

[Serializable]
public class Path
{
    public Vector3[] Points => _points;

    public bool Loopind => _looping;

    public float Time => _time;

    [SerializeField]
    private Vector3[] _points;

    [SerializeField]
    private bool _looping;

    [SerializeField]
    private float _time;

} 
