// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_42ts
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System.Collections.Generic;
using HarmonyLib;
using LOR_DiceSystem;

namespace Ark
{
    //[拼点失败]使目标获得1层[腐蚀]
    public class DiceCardAbility_Wonly :DiceCardAbilityBase 
    {
        public static string Desc = "[拼点失败]使目标获得1层[腐蚀]";
        public override void OnLoseParrying()
        {
            behavior.card.target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Decay, 1, owner);
        }
    }
}
