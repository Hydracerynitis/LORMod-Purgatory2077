// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100089
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using LOR_DiceSystem;

namespace Ark
{
    //折射/破碎     未陷入“晕眩”时受到的混乱伤害-4 /累积拼点失败16次时下一幕获得“晕眩”
    public class PassiveAbility_100116 : PassiveAbilityBase
    {
        private int LoseCount=0;
        public override int GetBreakDamageReductionAll(int dmg, DamageType dmgType, BattleUnitModel attacker)
        {
            return owner.bufListDetail.GetActivatedBuf(KeywordBuf.Stun)!=null? base.GetBreakDamageReductionAll(dmg, dmgType, attacker): 4;
        }
        public override void OnLoseParrying(BattleDiceBehavior behavior)
        {
            LoseCount += 1;
            if (LoseCount >= 16)
            {
                owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Stun, 1);
                LoseCount = 0;
            }
        }
    }
}
