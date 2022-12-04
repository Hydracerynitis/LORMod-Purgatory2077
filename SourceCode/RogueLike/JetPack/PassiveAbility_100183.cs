// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100100
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //速度骰子锁定为3颗 若自身在本幕被攻击则在下一幕使自身[无法行动]
    public class PassiveAbility_100183 : PassiveAbilityBase
    {
        public int GetSpeedDiceNumLast() => 3;
        public override void OnTakeDamageByAttack(BattleDiceBehavior atkDice, int dmg)
        {
            owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Stun, 1);
        }
    }
}
