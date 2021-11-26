// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100015
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //专属-远海战歌   每一幕开始恢复自身所拥有的buff种类x5的体力
    public class PassiveAbility_100015 : PassiveAbilityBase
    {
        public override void OnRoundStart() => owner.RecoverHP(owner.bufListDetail.GetActivatedBufList().Count * 5);
    }
}
