using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC", menuName = "NPC")]
public class Talk : ScriptableObject
{
    [Header("對話1"), TextArea(1, 5)]
    public string dialoug1;
    [Header("對話2"), TextArea(1, 5)]
    public string dialoug2;
    [Header("對話3"), TextArea(1, 5)]
    public string dialoug3;
    [Header("任務需求數量")]
    public int count;
    [Header("已取得項目數")]
    public int countCurrent;
}
