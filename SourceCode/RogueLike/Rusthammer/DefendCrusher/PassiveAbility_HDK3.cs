// Decompiled with JetBrains decompiler
// Type: Purgatory.PassiveAbility_HDK3
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using LOR_DiceSystem;

namespace Ark
{
    //压迫前行/震颤之锤     舞台开启时光芒上限-2/第三张书页的“打击”骰子命中目标时使目标下一幕"眩晕"且可以使用专属书页[锈锤之战](不可转移)
    public class PassiveAbility_HDK3 : PassiveAbilityBase
    {
        private int _count=-1;
        public override int MaxPlayPointAdder() => -2;
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            ++_count;
            if (_count <= 2)
                 return;
            _count = 0;
        }
        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            if (behavior.Detail != BehaviourDetail.Hit || _count < 2)
                return;
             behavior.card.target.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Stun, 1, owner);

        }
    }
}
