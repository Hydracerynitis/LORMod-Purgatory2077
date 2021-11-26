// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_42ts
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System.Collections.Generic;
using HarmonyLib;

namespace Ark
{
    //此书页第一幕必出现在手中      [舞台开启]若已转移[不死的黑蛇]则变为。。。
    public class DiceCardSelfAbility_TLL5 :DiceCardSelfAbilityBase 
    {
        private const int DeathLessBlackSnakeEquipPageId = 1;
        private const int NameLessWhiteDragonCombatPageId = 1;
        public static string Desc = "此书页第一幕必出现在手中\n[舞台开启]若已转移[不死的黑蛇]则变为。。。";
        public override void OnEnterCardPhase(BattleUnitModel unit, BattleDiceCardModel self)
        {
            bool transform = CheckEquiped(unit);
            BattleDiceCardModel newCard = BattleDiceCardModel.CreatePlayingCard(ItemXmlDataList.instance.GetCardItem(new LorId("Purgatory2077", NameLessWhiteDragonCombatPageId)));
            newCard.owner = unit;
            if (Singleton<StageController>.Instance.RoundTurn != 1)
                return;
            List<BattleDiceCardModel> hand = typeof(BattleAllyCardDetail).GetField("_cardInHand", AccessTools.all).GetValue(unit.allyCardDetail) as List<BattleDiceCardModel>;
            if (hand.Exists(x => x == self))
            {
                unit.allyCardDetail.DrawCards(1);
                if (transform)
                {
                    hand.Remove(self);
                    hand.Add(newCard);
                }
                return;
            }      
            if (unit.allyCardDetail.GetDeck().Exists(x => x == self))
            {
                List<BattleDiceCardModel> deck = typeof(BattleAllyCardDetail).GetField("_cardInDeck", AccessTools.all).GetValue(unit.allyCardDetail) as List<BattleDiceCardModel>;
                deck.Remove(self);
                if (transform)
                    hand.Add(newCard);
                else
                    hand.Add(self);
            }
            if(unit.allyCardDetail.GetDiscarded().Exists(x => x == self))
            {
                List<BattleDiceCardModel> discard = typeof(BattleAllyCardDetail).GetField("_cardInDiscarded", AccessTools.all).GetValue(unit.allyCardDetail) as List<BattleDiceCardModel>;
                discard.Remove(self);
                if (transform)
                    hand.Add(newCard);
                else
                    hand.Add(self);
            }
        }
        private bool CheckEquiped(BattleUnitModel unit)
        {
            List<BookModel> EquipedBook = unit.equipment.book.GetEquipedBookList(true);
            foreach (BookModel model in EquipedBook)
            {
                if (model.BookId == new LorId("Purgatory2077", DeathLessBlackSnakeEquipPageId))
                    return true;
            }
            return false;
        }
    }
}
