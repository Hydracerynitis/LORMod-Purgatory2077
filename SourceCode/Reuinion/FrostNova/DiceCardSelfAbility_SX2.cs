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
    //[使用时] 下一幕使自身获得1层[束缚]并恢复2点光芒
    public class DiceCardSelfAbility_SX2 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[使用时] 下一幕使自身获得1层[束缚]并恢复2点光芒";
        public override void OnUseCard()
        {
            owner.bufListDetail.AddKeywordBufByCard(KeywordBuf.Binding, 1, owner);
            owner.bufListDetail.AddBuf(new RecoverEnergy(2));
        }
    }
}
