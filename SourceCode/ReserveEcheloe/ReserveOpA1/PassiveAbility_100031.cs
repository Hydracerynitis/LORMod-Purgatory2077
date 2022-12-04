// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100031
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //冲锋号令  当使用书页恢复光芒时,下一幕开始获得1层“迅捷”
    public class PassiveAbility_100031 : PassiveAbilityBase
    {
        public void OnRecoverPlayPoint() => owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Quickness,1);
    }
}
