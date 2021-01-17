using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC", menuName = "NPC")]
public class Talk : ScriptableObject
{
    [Header("對話1"), TextArea(1, 5)]
    public string dialoug1;
   }
