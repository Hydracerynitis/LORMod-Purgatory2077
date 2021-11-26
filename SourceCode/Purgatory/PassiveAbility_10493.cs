// Decompiled with JetBrains decompiler
// Type: Purgatory.PassiveAbility_10493
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //咒术阵线      不稳定的使自身情感提升到2级且使所有敌方单位获得1层“烧伤”
    public class PassiveAbility_10493 : PassiveAbilityBase
    {
        public override void OnWaveStart()
        {
            if (owner.emotionDetail.EmotionLevel < 2)
            {
                owner.emotionDetail.SetEmotionLevel(2);
                owner.cardSlotDetail.RecoverPlayPoint(owner.cardSlotDetail.GetMaxPlayPoint());
            }
            foreach (BattleUnitModel battleUnitModel in BattleObjectManager.instance.GetAliveListExceptFaction(owner.faction))
                battleUnitModel.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Burn, 1, owner);
        }
    }
}
