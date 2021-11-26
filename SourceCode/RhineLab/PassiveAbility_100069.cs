// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100069
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //莱茵科技  自身获得的“充能”层数+1 (敌方摇摆抽卡)
    public class PassiveAbility_100069 : PassiveAbilityBase
    {
        public override int OnAddKeywordBufByCard(BattleUnitBuf buf, int stack) => buf is BattleUnitBuf_warpCharge? 1 : 0;
        public override void OnRoundStart()
        {
            if (owner.faction != Faction.Enemy)
                return;
            owner.allyCardDetail.DrawCards(owner.Book.GetSpeedDiceRule(owner).Roll(owner).Count - owner.allyCardDetail.GetHand().Count);
        }
    }
}
