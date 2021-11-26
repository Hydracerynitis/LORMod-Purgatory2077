// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100042
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //滞留解力      拼点时使目标不受威力增减影响
    public class PassiveAbility_100042 : PassiveAbilityBase
    {
        public override void OnStartParrying(BattlePlayingCardDataInUnitModel curCard)
        {
            BattleUnitModel target = curCard.target;
            if (target == null || target.currentDiceAction == null)
                return;
            target.currentDiceAction.ignorePower = true;
        }
    }
}
