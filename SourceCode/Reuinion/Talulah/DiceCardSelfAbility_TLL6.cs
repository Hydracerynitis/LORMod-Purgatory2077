﻿// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_42ts
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System.Collections.Generic;
using HarmonyLib;

namespace Ark
{
    //[使用时] 自身烧伤大于5层时下一幕进入匿踪且本书页骰子将骰出最大值
    public class DiceCardSelfAbility_TLL6 :DiceCardSelfAbilityBase 
    {
        public static string Desc = "[使用时] 自身烧伤大于5层时下一幕进入匿踪且本书页骰子将骰出最大值";
        public override void OnUseCard()
        {
            if (owner.bufListDetail.GetKewordBufStack(KeywordBuf.Burn) > 5)
            {
                owner.bufListDetail.AddBuf(new Critical() { currentCard = card });
                owner.bufListDetail.AddReadyBuf(new Stealth());
            }
        }
    }
}
