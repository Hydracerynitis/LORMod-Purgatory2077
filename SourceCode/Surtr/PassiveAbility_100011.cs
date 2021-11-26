// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100011
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //熏烟之火  命中目标时若目标持有烟气则施加1层“烧伤”
    public class PassiveAbility_100011 : PassiveAbilityBase
    {
        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            if (!IsNearOrFar(behavior.card.card) || !IsAttackDice(behavior.Detail))
                return;
            BattleUnitModel target = behavior.card.target;
            if (target == null || target.bufListDetail.GetKewordBufStack(KeywordBuf.Smoke) <= 0)
                return;
            owner.battleCardResultLog?.SetPassiveAbility(this);
            target.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Burn, 1, owner);
        }
    }
}
