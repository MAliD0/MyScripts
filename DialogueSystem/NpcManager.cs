using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Dialogue system/New Npc Collection", order = 2)]
public class NpcManager : ScriptableObject
{
    public List<NpcData> npcDatas;
    public NpcData FindNpc(string name)
    {
        foreach(NpcData npc in npcDatas)
        {
            if(npc.name == name)
            {
                return npc;
            }
        }
        return null;
    }
    public NpcData FindNpc(int id)
    {
        foreach (NpcData npc in npcDatas)
        {
            if (npc.id == id)
            {
                return npc;
            }
        }
        return null;
    }
}
