// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100103
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //环境伪装      舞台开启时前三幕处于“匿踪”
    public class PassiveAbility_100103 : PassiveAbilityBase
    {
        public override bool isTargetable => Singleton<StageController>.Instance.RoundTurn > 3;
    }
}
