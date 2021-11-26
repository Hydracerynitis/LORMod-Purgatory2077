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
            List<BattleDiceCardModel> BurnCard = owner.allyCardDetail.GetHand().FindAll(x => CheckCondition(x));
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
        private bool CheckCondition(BattleDiceCardModel card)
        {
            if (card != null)
            {
                DiceCardXmlInfo xmlData = card.XmlData;
                if (xmlData == null)
                    return false;
                if (xmlData.Keywords.Contains("Burn_Keyword"))
                    return true;
                List<string> abilityKeywords = Singleton<BattleCardAbilityDescXmlList>.Instance.GetAbilityKeywords(xmlData);
                for (int index = 0; index < abilityKeywords.Count; ++index)
                {
                    if (abilityKeywords[index] == "Burn_Keyword")
                        return true;
                }
                foreach (DiceBehaviour behaviour in card.GetBehaviourList())
                {
                    List<string> keywordsByScript = Singleton<BattleCardAbilityDescXmlList>.Instance.GetAbilityKeywords_byScript(behaviour.Script);
                    for (int index = 0; index < keywordsByScript.Count; ++index)
                    {
                        if (keywordsByScript[index] == "Burn_Keyword")
                            return true;
                    }
                }
            }
            return false;
        }
    }
}
