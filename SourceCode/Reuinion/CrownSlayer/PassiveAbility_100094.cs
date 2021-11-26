// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100094
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //潜行者       第一幕中获得“匿踪”
    public class PassiveAbility_100094 : PassiveAbilityBase
    {
        public override bool isTargetable => Singleton<StageController>.Instance.RoundTurn != 1;
    }
}
