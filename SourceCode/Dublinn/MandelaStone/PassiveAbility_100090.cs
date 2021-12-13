// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100089
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using LOR_DiceSystem;

namespace Ark
{
    //腾跃而行     携带远程书页时无法使用远程书页，若陷入混乱则限制解除
    public class PassiveAbility_100090 : PassiveAbilityBase
    {
        public bool UseFar = false;
        public override void OnBreakState()
        {
            UseFar = true;
        }
    }
}
