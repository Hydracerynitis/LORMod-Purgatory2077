// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100108
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //冻结攻型      命中目标时追加目标“束缚”层数的混乱伤害
    public class PassiveAbility_100108 : PassiveAbilityBase
    {
        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            owner.battleCardResultLog?.SetPassiveAbility(this);
            BattleUnitModel target = behavior.card.target;
            if (target == null)
                return;
            foreach (BattleUnitBuf activatedBuf in this.owner.bufListDetail.GetActivatedBufList())
            {
                if (activatedBuf.bufType == KeywordBuf.Binding)
                {
                    int stack = activatedBuf.stack;
                    if (stack > 0)
                        target.TakeBreakDamage(stack, DamageType.Passive);
                }
            }
        }
    }
}
