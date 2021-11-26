// Decompiled with JetBrains decompiler
// Type: Purgatory.DiceCardAbility_A7_no8host
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //[命中时]追加8点混乱伤害
    public class DiceCardAbility_A7_no8host : DiceCardAbilityBase
    {
        public override void OnSucceedAttack(BattleUnitModel target) => target?.TakeBreakDamage(8, DamageType.Card_Ability, atkResist: AtkResist.None);
    }
}
