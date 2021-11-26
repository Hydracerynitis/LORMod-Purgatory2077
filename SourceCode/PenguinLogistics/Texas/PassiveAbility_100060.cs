﻿// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100060
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //战术快递      拼点胜利时25%概率抽取1张书页并使一名友方单位抽取1张书页
    public class PassiveAbility_100060 : PassiveAbilityBase
    {
        public override void OnWinParrying(BattleDiceBehavior behavior)
        {
            if (RandomUtil.valueForProb >= 0.25)
                return;
            owner.allyCardDetail.DrawCards(1);
            foreach (BattleUnitModel battleUnitModel in BattleObjectManager.instance.GetAliveList_random(owner.faction, 1))
                battleUnitModel.allyCardDetail.DrawCards(1);
        }
    }
}
