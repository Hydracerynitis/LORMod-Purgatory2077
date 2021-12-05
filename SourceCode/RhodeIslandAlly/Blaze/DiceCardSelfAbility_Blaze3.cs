// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_42ts
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using LOR_DiceSystem;
using System.Collections.Generic;
using HarmonyLib;

namespace Ark
{
    //[使用时]手中书页总费用超过8点时使手中书页费用还原至初始状态       并使本书页所有骰子威力+(还原前手中书页的总和费用)
    public class DiceCardSelfAbility_Blaze3 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[使用时]手中书页总费用超过8点时使手中书页费用还原至初始状态\n并使本书页所有骰子威力+(还原前手中书页的总和费用)";
        public override void OnUseCard()
        {
            int cost = 0;
            owner.allyCardDetail.GetHand().ForEach(x => cost += x.GetCost());
            if (cost <= 8)
                return;
            foreach(BattleDiceCardModel card in owner.allyCardDetail.GetHand())
            {
                while (card.HasBuf<CostIncrease>())
                    card.RemoveBuf<CostIncrease>();
            }
            card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus() { power = cost });
        }
    }
}
