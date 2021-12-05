// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100069
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //体力低于25%时立刻恢复100点体力并在这一幕与下一幕中获得4层"守护"
    public class PassiveAbility_BlazePix1 : PassiveAbilityBase
    {
        private bool trigger = false;
        public override void OnLoseHp(int dmg)
        {
            if(owner.hp-dmg<owner.MaxHp/4 && !trigger)
            {
                trigger = true;
                owner.RecoverHP(100);
                owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Protection, 4);
                owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Protection, 4);
            }
        }
    }
}
