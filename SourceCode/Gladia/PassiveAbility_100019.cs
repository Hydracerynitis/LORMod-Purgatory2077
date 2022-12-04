// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100019
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //猎人直觉  当这一幕受到单方面攻击时下一幕获得1层“迅捷”(每一幕至多触发2次)
    public class PassiveAbility_100019 : PassiveAbilityBase
    {
        private int _trigger = 0 ;
        public override void OnRoundEnd()
        {
            owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Quickness, _trigger, owner);
            _trigger = 0;
        }
        public override void OnStartTargetedOneSide(BattlePlayingCardDataInUnitModel attackerCard)
        {
            _trigger++;
        }
    }
}
