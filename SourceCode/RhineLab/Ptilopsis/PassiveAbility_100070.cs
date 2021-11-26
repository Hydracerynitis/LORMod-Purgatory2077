// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100070
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //脑啡肽提神     受到伤害时恢复3点混乱抗性(每一幕至多触发3次)
    public class PassiveAbility_100070 : PassiveAbilityBase
    {
        private int _recover;
        public override void OnRoundStart() => _recover = 3;
        public override void AfterTakeDamage(BattleUnitModel attacker, int dmg)
        {
            if (_recover <= 0)
                return;
            --_recover;
            owner.breakDetail.RecoverBreak(3);
        }
    }
}
