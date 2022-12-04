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
    //[使用时]目标[腐蚀]不低于3层则使自身下一幕抽取2张书页
    public class DiceCardSelfAbility_Wonly1 :DiceCardSelfAbilityBase 
    {
        public static string Desc = "[使用时]目标[腐蚀]不低于3层则使自身下一幕抽取2张书页";
        public override void OnUseCard()
        {
            if (card.target.bufListDetail.GetKewordBufStack(KeywordBuf.Decay) < 3)
                return;
            owner.bufListDetail.AddBuf(new DrawCard(2));
        }
    }
}
