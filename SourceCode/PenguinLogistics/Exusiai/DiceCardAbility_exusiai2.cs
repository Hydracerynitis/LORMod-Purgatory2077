// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardAbility_exusiai2
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //[命中时] 减少自身4点体力
    public class DiceCardAbility_exusiai2 : DiceCardAbilityBase
    {
        public static string Desc = "[命中时] 减少自身4点体力";
        public override void OnSucceedAttack() => owner.LoseHp(4);
    }
}
