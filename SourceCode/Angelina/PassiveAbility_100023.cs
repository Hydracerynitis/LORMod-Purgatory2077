﻿// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100023
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //信使网络  每2幕额外抽取1张书页
    public class PassiveAbility_100023 : PassiveAbilityBase
    {
        public override void OnRoundStart()
        {
            if(StageController.Instance.RoundTurn%2==0)
                this.owner.allyCardDetail.DrawCards(1);
        }
    }
}
