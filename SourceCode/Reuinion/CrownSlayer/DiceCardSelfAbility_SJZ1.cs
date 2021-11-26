// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_42ts
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System.Collections.Generic;
using HarmonyLib;

namespace Ark
{
    //此书页第一幕必出现在手中
    public class DiceCardSelfAbility_SJZ1 :DiceCardSelfAbilityBase 
    {
        public static string Desc = "此书页第一幕必出现在手中";
        public override void OnEnterCardPhase(BattleUnitModel unit, BattleDiceCardModel self)
        {
            if (Singleton<StageController>.Instance.RoundTurn != 1)
                return;
            if (unit.allyCardDetail.GetHand().Exists(x => x == self))
            {
                unit.allyCardDetail.DrawCards(1);
                return;
            }
            List<BattleDiceCardModel> hand = typeof(BattleAllyCardDetail).GetField("_cardInHand", AccessTools.all).GetValue(unit.allyCardDetail) as List<BattleDiceCardModel>;
            if (unit.allyCardDetail.GetDeck().Exists(x => x == self))
            {
                List<BattleDiceCardModel> deck = typeof(BattleAllyCardDetail).GetField("_cardInDeck", AccessTools.all).GetValue(unit.allyCardDetail) as List<BattleDiceCardModel>;
                deck.Remove(self);
                hand.Add(self);
            }
            if(unit.allyCardDetail.GetDiscarded().Exists(x => x == self))
            {
                List<BattleDiceCardModel> discard = typeof(BattleAllyCardDetail).GetField("_cardInDiscarded", AccessTools.all).GetValue(unit.allyCardDetail) as List<BattleDiceCardModel>;
                discard.Remove(self);
                hand.Add(self);
            }
        }
    }
}
