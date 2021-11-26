// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100114
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using LOR_DiceSystem;

namespace Ark
{
    //专属-黑蛇意志       免疫“烧伤”伤害，且拥有不低于15层的“烧伤”时自身所有抗性变为致命且自身造成伤害+100%
    public class PassiveAbility_100114 : PassiveAbilityBase
    {
        public override float DmgFactor(int dmg, DamageType type = DamageType.ETC, KeywordBuf keyword = KeywordBuf.None) => keyword == KeywordBuf.Burn ? 0.0f : base.DmgFactor(dmg, type, keyword);
        public override AtkResist GetResistHP(AtkResist origin, BehaviourDetail detail)
        {
            if (owner.bufListDetail.GetKewordBufStack(KeywordBuf.Burn) > 15)
                return AtkResist.Weak;
            return base.GetResistHP(origin, detail);
        }
        public override AtkResist GetResistBP(AtkResist origin, BehaviourDetail detail)
        {
            if (owner.bufListDetail.GetKewordBufStack(KeywordBuf.Burn) > 15)
                return AtkResist.Weak;
            return base.GetResistBP(origin, detail);
        }
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            if (!IsAttackDice(behavior.Detail) || owner.bufListDetail.GetActivatedBuf(KeywordBuf.Burn).stack < 15)
                return;
            owner.battleCardResultLog?.SetPassiveAbility(this);
            behavior.ApplyDiceStatBonus(new DiceStatBonus(){ dmgRate = 100 });
        }
    }
}
