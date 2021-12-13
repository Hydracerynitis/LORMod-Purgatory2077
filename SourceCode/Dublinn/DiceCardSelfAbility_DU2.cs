// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_DU2
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //[装备时]自身抽取一张书页并使两名友方单位获得1层[振奋]
    public class DiceCardSelfAbility_DU2 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[装备时]自身抽取一张书页并使两名友方单位获得1层[振奋]";
        public override string[] Keywords => new string[1]{ "DrawCard_Keyword" };
        public override void OnUseInstance(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            unit.allyCardDetail.DrawCards(1);
            foreach (BattleUnitModel battleUnitModel in BattleObjectManager.instance.GetAliveList_random(unit.faction, 2))
                battleUnitModel.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.BreakProtection, 1);
        }
        public override void OnEnterCardPhase(BattleUnitModel unit, BattleDiceCardModel self)
        {
            if(unit.faction==Faction.Enemy && unit.allyCardDetail.GetHand().Contains(self) && 
                unit.cardSlotDetail.PlayPoint - unit.cardSlotDetail.ReservedPlayPoint > self.GetCost())
            {
                unit.cardSlotDetail.AddCard(self, BattleObjectManager.instance.GetAliveList_random(Faction.Player, 1)[0], 0);
            }
                
        }
    }
}
