using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MelodyModel : MonoBehaviour
{
    public static List<Melody> allMelodies;
    public static Dictionary<string, Melody> allMelodiesMap;
    


    public enum TriangleTone
    {
        tone1,
        tone2,
        tone3,
        tone4,
        tone5,
        tone6,
        tone7,
        tone8
    }

    public static Color[] melodyColors = new Color[5]{
        new Color(90/255f, 181/255f, 255/255f, 1f),
        new Color(255/255f, 186/255f, 244/255f, 1f),
        new Color(237/255f, 116/255f, 71/255f, 1f),
        new Color(119/255f, 221/255f, 119/255f, 1f),
        new Color(255/255f, 224/255f, 90/255f, 1f)
    };




  
    
    public List<KeyValuePair<Color, TriangleTone>> tones = new List<KeyValuePair<Color, TriangleTone>>(){
        new KeyValuePair<Color, TriangleTone>(new Color(90/255f, 181/255f, 255/255f, 1f), TriangleTone.tone1),
        new KeyValuePair<Color, TriangleTone>(new Color(255/255f, 186/255f, 244/255f, 1f), TriangleTone.tone2),
        new KeyValuePair<Color, TriangleTone>(new Color(237/255f, 116/255f, 71/255f, 1f), TriangleTone.tone3),
        new KeyValuePair<Color, TriangleTone>(new Color(119/255f, 221/255f, 119/255f, 1f), TriangleTone.tone4),
        new KeyValuePair<Color, TriangleTone>(new Color(255/255f, 224/255f, 90/255f, 1f), TriangleTone.tone5)
    };
   
    public void Awake()
    {

        allMelodies = new List<Melody>
        { 
             new Melody(
                "Melody 3", new List<int>()
                {
                    0,2,1,4,3
                }
                ),
             new Melody(
                "Melody 4", new List<int>()
                {
                     1,2,4,0,3
                }
                ),
             new Melody(
                "Melody 5",new List<int>()
                {
                     4,0,1,2,3
                }
                ),
        };

        allMelodiesMap = allMelodies.ToDictionary(i => i.melodyKey, i => i);
    }
}
