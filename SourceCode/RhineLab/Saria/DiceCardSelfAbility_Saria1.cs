﻿// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_Saria1
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //[使用时]获得1层[忍耐]与3层[充能]
    public class DiceCardSelfAbility_Saria1 : DiceCardSelfAbilityBase
    { 
        public static string Desc = "[使用时]获得1层[忍耐]与3层[充能]";
        public override string[] Keywords => new string[1]{ "WarpCharge" };
        public override void OnUseCard()
        {
            owner.bufListDetail.AddKeywordBufByCard(KeywordBuf.Endurance, 1, owner);
            owner.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.WarpCharge, 3, owner);
        }
    }
}
