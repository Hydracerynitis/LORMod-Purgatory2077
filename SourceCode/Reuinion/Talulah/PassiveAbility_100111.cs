// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100111
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //烈火之势      命中目标时施加1层“烧伤”且追加目标“烧伤”层数的伤害
    public class PassiveAbility_100111 : PassiveAbilityBase
    {
        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            owner.battleCardResultLog?.SetPassiveAbility(this);
            BattleUnitModel target = behavior.card.target;
            if (target == null)
                return;
            target.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Burn, 1, owner);
            foreach (BattleUnitBuf activatedBuf in owner.bufListDetail.GetActivatedBufList())
            {
                if (activatedBuf.bufType == KeywordBuf.Burn)
                {
                    int stack = activatedBuf.stack;
                    if (stack > 0)
                        target.TakeDamage(stack, DamageType.Passive);
                }
            }
        }
    }
}
