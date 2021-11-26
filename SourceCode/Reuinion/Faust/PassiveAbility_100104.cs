// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100104
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //致命一击      每隔三幕时获得4层“强壮”
    public class PassiveAbility_100104 : PassiveAbilityBase
    {
        public override void OnRoundStart()
        {
            if(Singleton<StageController>.Instance.RoundTurn%3==0)
                owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Strength, 4);
        }
  }
}
