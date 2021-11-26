// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100113
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using LOR_DiceSystem;
using System.Collections.Generic;

namespace Ark
{
    //灼烧大地      使用远程书页命中目标时施加烧伤时对其他敌方单位也施加1层“烧伤”
    public class PassiveAbility_100113 : PassiveAbilityBase
    {
        private bool _Far;
        public override int OnGiveKeywordBufByCard(BattleUnitBuf buf, int stack, BattleUnitModel target)
        {
            if (buf.bufType != KeywordBuf.Burn || !_Far)
                return 0;
            foreach(BattleUnitModel unit in BattleObjectManager.instance.GetAliveList_opponent(owner.faction))
                unit.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Burn, 1, null);
            return 0;
        }
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            if (curCard.card.GetSpec().Ranged == CardRange.Far)
                _Far = true;
            else
                _Far = false;
        }
    }
}
