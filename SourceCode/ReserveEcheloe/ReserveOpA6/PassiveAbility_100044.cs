// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100044
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //魔王气质      月见夜觉得自己很帅,每一幕开始恢复1点混乱抗性
    public class PassiveAbility_100044 : PassiveAbilityBase
    {
        public override void OnRoundStart() => owner.breakDetail.RecoverBreak(1);
    }
}
