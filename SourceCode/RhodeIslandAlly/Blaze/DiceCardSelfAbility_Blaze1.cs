// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_42ts
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System.Collections.Generic;
using HarmonyLib;

namespace Ark
{
    //[使用时]使本书页费用+1(不包含同名书页)随后抽取1张书页并恢复1点光芒
    public class DiceCardSelfAbility_Blaze1 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[使用时]使本书页费用+1(不包含同名书页)随后抽取1张书页并恢复1点光芒";
        public override void OnUseCard()
        {
            card.card.AddBuf(new CostIncrease());
            owner.allyCardDetail.DrawCards(1);
            owner.cardSlotDetail.RecoverPlayPoint(1);
        }
    }
}
