using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MelodyModel;

public class Melody 
{
  
    public List<KeyValuePair<Color, TriangleTone>> triangles;
    public string melodyKey;

    public Melody(
        string melodyKey,
        List<KeyValuePair<Color, TriangleTone>> triangles
        )
    {
        this.melodyKey = melodyKey;
        this.triangles = triangles; 
    }
}
