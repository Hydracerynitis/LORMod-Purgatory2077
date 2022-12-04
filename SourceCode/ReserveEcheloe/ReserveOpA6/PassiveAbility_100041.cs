// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100041
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using LOR_DiceSystem;
using System;

namespace Ark
{
    //战场冲杀      以一整张书页的骰子全部命中敌人时下一幕使所有友方恢复1点光芒
    public class PassiveAbility_100041 : PassiveAbilityBase
    {
        private int AttackNum;
        private int HitNum;
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            AttackNum = curCard.GetOriginalDiceBehaviorList().FindAll(x => x.Type != BehaviourType.Standby && IsAttackDice(x.Detail)).Count;
            HitNum = 0;
        }
        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            ++HitNum;
            if (HitNum < AttackNum)
                return;
            foreach (BattleUnitModel alive in BattleObjectManager.instance.GetAliveList(owner.faction))
                alive.cardSlotDetail.RecoverPlayPoint(1);
        }
    }
}
