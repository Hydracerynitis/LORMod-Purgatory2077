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
    //[使用时] 复制手中随机一张费用最高的[烧伤]词条书页的骰子
    public class DiceCardSelfAbility_TLL14 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[使用时] 复制手中随机一张费用最高的[烧伤]词条书页的骰子";
        public override void OnUseCard()
        {
            base.OnUseCard();
            List<BattleDiceCardModel> BurnCard = owner.allyCardDetail.GetHand().FindAll(x => Harmony_Patch.CheckCondition(x, "Burn_Keyword"));
            if (BurnCard.Count <= 0)
                return;
            List<BattleDiceCardModel> highest = new List<BattleDiceCardModel>();
            int cost = -1;
            foreach(BattleDiceCardModel card in BurnCard)
            {
                if (card.GetCost() > cost)
                {
                    highest.Clear();
                    highest.Add(card);
                    cost = card.GetCost();
                }
                else if (card.GetCost() == cost)
                    highest.Add(card);
            }
            BattleDiceCardModel select = RandomUtil.SelectOne<BattleDiceCardModel>(highest);
            foreach(BattleDiceBehavior dice in select.CreateDiceCardBehaviorList())
                card.AddDice(dice);
        }

    }
}
