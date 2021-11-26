// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100009
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //赏金锁定     拼点失败时下一次攻击命中额外追加1点混乱伤害(可无限叠加)
    public class PassiveAbility_100009 : PassiveAbilityBase
    {
        private int _num;
        public override void OnLoseParrying(BattleDiceBehavior behavior) => ++_num;
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            if (_num <= 0)
                return;
            behavior.ApplyDiceStatBonus(new DiceStatBonus(){ breakDmg = _num });
        }
        public override void OnSucceedAttack(BattleDiceBehavior behavior) => _num = 0;
    }
}
