// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100068
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //企鹅物流突击       第一幕中获得5层“守护”与“迅捷” 
    public class PassiveAbility_100068 : PassiveAbilityBase
    {
        public override void OnWaveStart()
        {
            owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Protection, 5, owner);
            owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Quickness, 5, owner);
        }
    }
}
