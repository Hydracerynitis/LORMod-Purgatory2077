// Decompiled with JetBrains decompiler
// Type: Purgatory.PassiveAbility_10494
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //炎狱炎熔      每一幕使所有敌方单位获得1层“烧伤” 每三幕时在牌库置入一张特殊书页
    public class PassiveAbility_10494 : PassiveAbilityBase
    {
        private int _patternCount=3;
        public override void OnRoundStart()
        {
            --this._patternCount;
            foreach (BattleUnitModel battleUnitModel in BattleObjectManager.instance.GetAliveListExceptFaction(owner.faction))
                battleUnitModel.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Burn, 1, owner);
            if (_patternCount > 0)
                return;
            _patternCount = 3;
            owner.allyCardDetail.AddTempCard(new LorId("Purgatory2077", 11));
        }
    }
}
