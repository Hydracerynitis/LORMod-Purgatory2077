// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100100
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //C4    进攻型骰子拼点失败时给予目标1层“腐蚀” 命中有“腐蚀”的目标时追加“腐蚀”层数x2的伤害与混乱伤害并清除目标“腐蚀”层数
    public class PassiveAbility_100100 : PassiveAbilityBase
    {
        public override void OnLoseParrying(BattleDiceBehavior behavior)
        {
            owner.battleCardResultLog?.SetPassiveAbility(this);
            behavior.card.target?.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Decay, 1, owner);
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
                    target.TakeDamage(stack * 2, DamageType.Passive);
                    target.TakeBreakDamage(stack * 2, DamageType.Passive);
                    activatedBuf.stack = 0;
                }
            }
        }
    }
}
