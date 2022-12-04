// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100100
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //C4    免疫“腐蚀”; 进攻型骰子拼点失败时给予双方1层“腐蚀"; 命中有“腐蚀”的目标时追加“腐蚀”层数的伤害与混乱伤害; 战斗开始在EGO栏位中获得特殊书页(不可转移)
    public class PassiveAbility_100100 : PassiveAbilityBase
    {
        public override bool IsImmune(KeywordBuf buf)
        {
            return buf==KeywordBuf.Decay;
        }
        public override void OnWaveStart()
        {
            owner.personalEgoDetail.AddCard(new LorId("Purgatory2077", 357));
            owner.personalEgoDetail.AddCard(new LorId("Purgatory2077", 358));
        }
        public override void OnLoseParrying(BattleDiceBehavior behavior)
        {
            owner.battleCardResultLog?.SetPassiveAbility(this);
            owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Decay, 1);
            behavior.card.target?.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Decay, 1, owner);
        }
        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {

            BattleUnitModel target = behavior.card.target;
            if (target == null)
                return;
            foreach (BattleUnitBuf activatedBuf in owner.bufListDetail.GetActivatedBufList())
            {
                if (activatedBuf.bufType == KeywordBuf.Decay)
                {
                    owner.battleCardResultLog?.SetPassiveAbility(this);
                    int stack = activatedBuf.stack;
                    target.TakeDamage(stack , DamageType.Passive);
                    target.TakeBreakDamage(stack , DamageType.Passive);
                    //activatedBuf.stack = 0;
                }
            }
        }
    }
}
