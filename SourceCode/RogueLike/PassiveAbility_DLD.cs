// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100094
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //若第三幕结束时还未死亡则结束舞台(不掉落书籍)
    public class PassiveAbility_DLD : PassiveAbilityBase
    {
        public override void OnRoundEndTheLast()
        {
            if (StageController.Instance.RoundTurn < 3)
                return;
            StageController.Instance.GetCurrentWaveModel().Defeat();
            StageController.Instance.EndBattle();
        }
    }
}
