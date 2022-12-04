// Decompiled with JetBrains decompiler
// Type: Purgatory.PassiveAbility_HDK8
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using LOR_DiceSystem;

namespace Ark
{
    //震颤之击     第三张书页的“打击”骰子命中目标时使目标下一幕"眩晕"且可以使用专属书页[锈锤之战](不可转移 触发效果后移除此被动)
    public class PassiveAbility_HDK9 : PassiveAbilityBase
    {
        private int _count=-1;
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
            owner.passiveDetail.DestroyPassive( this);
        }
    }
}
