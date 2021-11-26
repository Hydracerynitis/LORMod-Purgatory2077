// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100078
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //莱茵蓄能      累计使用书页消耗10层”充能“则在这一幕获得1层”强壮“与1层”忍耐“(每一幕至多触发一次)
    public class PassiveAbility_100078 : PassiveAbilityBase
    {
        private int count;
        private bool isTriggered;
        public void OnUseChargeNum(int num)
        {
            if (isTriggered)
                return;
            count += num;
            if (count < 10)
                return;
            owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Strength, 1);
            owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Endurance, 1);
            isTriggered = true;
            count = 0;
        }
         public override void OnRoundStart() => isTriggered = false;
    }
}
