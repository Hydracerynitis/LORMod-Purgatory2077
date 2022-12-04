// Decompiled with JetBrains decompiler
// Type: Purgatory.PassiveAbility_HDK1
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //烈意盎然  每损失30%体力时 每一幕开始额外抽取1张书页且可以使用专属书页[锈锤之战](至多抽取3张 不可转移)
    public class PassiveAbility_HDK1 : PassiveAbilityBase
    {
        public override void OnRoundStart()
        {
            double ratio = 1.0 - owner.hp / owner.MaxHp;
            int power;
            for (power = 0; ratio > 0.3 && power<3; ++power)
            {
                ratio -= 0.3;
                owner.allyCardDetail.DrawCards(1);
            }
        }
    }
}
