using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MelodyModel;

public class Melody 
{
  
    public List<int> triangles;
    public string melodyKey;

    public Melody(
        string melodyKey,
        List<int> triangles
        )
    {
        this.melodyKey = melodyKey;
        this.triangles = triangles; 
    }
}
