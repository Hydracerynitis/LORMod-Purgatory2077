// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100034
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //营养套餐      恢复体力时使其获得至多1层的“守护”
    public class PassiveAbility_100034 : PassiveAbilityBase
    {
        private bool _tri;
        public override void OnRecoverHp(int amount)
        {
            if (!_tri)
                return;
            owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Protection, 1);
            _tri = false;
        }
        public override void OnRoundStart() =>  _tri = true;
    }
}
