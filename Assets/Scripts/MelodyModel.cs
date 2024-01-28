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

    public void Awake()
    {

        allMelodies = new List<Melody>
        { 
             new Melody(
                "Melody 3", new List<KeyValuePair<Color, TriangleTone>>()
                {
                    new KeyValuePair<Color, TriangleTone>(new Color(90/255f, 181/255f, 255/255f, 1f), TriangleTone.tone1),
                    new KeyValuePair<Color, TriangleTone>(new Color(237/255f, 116/255f, 71/255f, 1f), TriangleTone.tone3),
                    new KeyValuePair<Color, TriangleTone>(new Color(255/255f, 186/255f, 244/255f, 1f), TriangleTone.tone2),
                    new KeyValuePair<Color, TriangleTone>(new Color(255/255f, 224/255f, 90/255f, 1f), TriangleTone.tone5 ),
                    new KeyValuePair<Color, TriangleTone>(new Color(220/255f, 232/255f, 209/255f, 1f), TriangleTone.tone4)
                }
                ),
             new Melody(
                "Melody 4", new List<KeyValuePair<Color, TriangleTone>>()
                {
                     new KeyValuePair<Color, TriangleTone>(new Color(255/255f, 186/255f, 244/255f, 1f), TriangleTone.tone2),
                     new KeyValuePair<Color, TriangleTone>(new Color(237/255f, 116/255f, 71/255f, 1f), TriangleTone.tone3),
                     new KeyValuePair<Color, TriangleTone>(new Color(255/255f, 224/255f, 90/255f, 1f), TriangleTone.tone5),
                     new KeyValuePair<Color, TriangleTone>(new Color(90/255f, 181/255f, 255/255f, 1f), TriangleTone.tone1),
                     new KeyValuePair<Color, TriangleTone>(new Color(220/255f, 232/255f, 209/255f, 1f), TriangleTone.tone4),
                }
                ),
             new Melody(
                "Melody 5",new List<KeyValuePair<Color, TriangleTone>>()
                {
                     new KeyValuePair<Color, TriangleTone>(new Color(255/255f, 224/255f, 90/255f, 1f), TriangleTone.tone5),
                     new KeyValuePair<Color, TriangleTone>(new Color(90/255f, 181/255f, 255/255f, 1f), TriangleTone.tone1),
                     new KeyValuePair<Color, TriangleTone>(new Color(255/255f, 186/255f, 244/255f, 1f), TriangleTone.tone2),
                     new KeyValuePair<Color, TriangleTone>(new Color(237/255f, 116/255f, 71/255f, 1f), TriangleTone.tone3),
                     new KeyValuePair<Color, TriangleTone>(new Color(220/255f, 232/255f, 209/255f, 1f), TriangleTone.tone4),
                }
                ),
        };

        allMelodiesMap = allMelodies.ToDictionary(i => i.melodyKey, i => i);
    }
}