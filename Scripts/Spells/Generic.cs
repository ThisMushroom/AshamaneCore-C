﻿/*
 * Copyright (C) 2012-2017 CypherCore <http://github.com/CypherCore>
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using Framework.Constants;
using Framework.Dynamic;
using Game.DataStorage;
using Game.Entities;
using Game.Maps;
using Game.Network.Packets;
using Game.Scripting;
using Game.Spells;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Scripts.Spells.Generic
{
    struct SpellIds
    {
        //Adaptivewarding
        public const uint GenAdaptiveWardingFire = 28765;
        public const uint GenAdaptiveWardingNature = 28768;
        public const uint GenAdaptiveWardingFrost = 28766;
        public const uint GenAdaptiveWardingShadow = 28769;
        public const uint GenAdaptiveWardingArcane = 28770;

        //Animalbloodpoolspell
        public const uint AnimalBlood = 46221;
        public const uint SpawnBloodPool = 63471;

        //Serviceuniform
        public const uint ServiceUniform = 71450;

        //Genericbandage
        public const uint RecentlyBandaged = 11196;

        //Bloodreserve
        public const uint BloodReserveAura = 64568;
        public const uint BloodReserveHeal = 64569;

        //Bonked
        public const uint Bonked = 62991;
        public const uint FormSwordDefeat = 62994;
        public const uint Onguard = 62972;

        //Breakshieldspells
        public const uint BreakShieldDamage2k = 62626;
        public const uint BreakShieldDamage10k = 64590;
        public const uint BreakShieldTriggerFactionMounts = 62575; // Also On Toc5 Mounts
        public const uint BreakShieldTriggerCampaingWarhorse = 64595;
        public const uint BreakShieldTriggerUnk = 66480;

        //Cannibalizespells
        public const uint CannibalizeTriggered = 20578;

        //Chaosblast
        public const uint ChaosBlast = 37675;

        //Clone
        public const uint NightmareFigmentMirrorImage = 57528;

        //Cloneweaponspells        
        public const uint WeaponAura = 41054;
        public const uint Weapon2Aura = 63418;
        public const uint Weapon3Aura = 69893;

        public const uint OffhandAura = 45205;
        public const uint Offhand2Aura = 69896;

        public const uint RangedAura = 57594;

        //Createlancespells
        public const uint CreateLanceAlliance = 63914;
        public const uint CreateLanceHorde = 63919;

        //Dalarandisguisespells        
        public const uint SunreaverTrigger = 69672;
        public const uint SunreaverFemale = 70973;
        public const uint SunreaverMale = 70974;

        public const uint SilverCovenantTrigger = 69673;
        public const uint SilverCovenantFemale = 70971;
        public const uint SilverCovenantMale = 70972;

        //Defendvisuals
        public const uint VisualShield1 = 63130;
        public const uint VisualShield2 = 63131;
        public const uint VisualShield3 = 63132;

        //Divinestormspell
        public const uint DivineStorm = 53385;

        //Elunecandle
        public const uint OmenHead = 26622;
        public const uint OmenChest = 26624;
        public const uint OmenHandR = 26625;
        public const uint OmenHandL = 26649;
        public const uint Normal = 26636;

        //Fishingspells
        public const uint FishingNoFishingPole = 131476;
        public const uint FishingWithPole = 131490;

        //Transporterbackfires
        public const uint TransporterMalfunctionPolymorph = 23444;
        public const uint TransporterEviltwin = 23445;
        public const uint TransporterMalfunctionMiss = 36902;

        //Gnomishtransporter
        public const uint TransporterSuccess = 23441;
        public const uint TransporterFailure = 23446;

        //Interrupt
        public const uint GenThrowInterrupt = 32747;

        //Genericlifebloomspells        
        public const uint HexlordMalacrass = 43422;
        public const uint TurragePaw = 52552;
        public const uint CenarionScout = 53692;
        public const uint TwistedVisage = 57763;
        public const uint FactionChampionsDru = 66094;

        //Chargespells        
        public const uint Damage8k5 = 62874;
        public const uint Damage20k = 68498;
        public const uint Damage45k = 64591;

        public const uint ChargingEffect8k5 = 63661;
        public const uint ChargingEffect20k1 = 68284;
        public const uint ChargingEffect20k2 = 68501;
        public const uint ChargingEffect45k1 = 62563;
        public const uint ChargingEffect45k2 = 66481;

        public const uint TriggerFactionMounts = 62960;
        public const uint TriggerTrialChampion = 68282;

        public const uint MissEffect = 62977;

        //Netherbloom
        public const uint NetherBloomPollen1 = 28703;

        //Nightmarevine
        public const uint NightmarePollen = 28721;

        //Obsidianarmorspells        
        public const uint Holy = 27536;
        public const uint Fire = 27533;
        public const uint Nature = 27538;
        public const uint Frost = 27534;
        public const uint Shadow = 27535;
        public const uint Arcane = 27540;

        //Tournamentpennantspells
        public const uint StormwindAspirant = 62595;
        public const uint StormwindValiant = 62596;
        public const uint StormwindChampion = 62594;
        public const uint GnomereganAspirant = 63394;
        public const uint GnomereganValiant = 63395;
        public const uint GnomereganChampion = 63396;
        public const uint SenjinAspirant = 63397;
        public const uint SenjinValiant = 63398;
        public const uint SenjinChampion = 63399;
        public const uint SilvermoonAspirant = 63401;
        public const uint SilvermoonValiant = 63402;
        public const uint SilvermoonChampion = 63403;
        public const uint DarnassusAspirant = 63404;
        public const uint DarnassusValiant = 63405;
        public const uint DarnassusChampion = 63406;
        public const uint ExodarAspirant = 63421;
        public const uint ExodarValiant = 63422;
        public const uint ExodarChampion = 63423;
        public const uint IronforgeAspirant = 63425;
        public const uint IronforgeValiant = 63426;
        public const uint IronforgeChampion = 63427;
        public const uint UndercityAspirant = 63428;
        public const uint UndercityValiant = 63429;
        public const uint UndercityChampion = 63430;
        public const uint OrgrimmarAspirant = 63431;
        public const uint OrgrimmarValiant = 63432;
        public const uint OrgrimmarChampion = 63433;
        public const uint ThunderbluffAspirant = 63434;
        public const uint ThunderbluffValiant = 63435;
        public const uint ThunderbluffChampion = 63436;
        public const uint ArgentcrusadeAspirant = 63606;
        public const uint ArgentcrusadeValiant = 63500;
        public const uint ArgentcrusadeChampion = 63501;
        public const uint EbonbladeAspirant = 63607;
        public const uint EbonbladeValiant = 63608;
        public const uint EbonbladeChampion = 63609;

        //Orcdisguisespells
        public const uint OrcDisguiseTrigger = 45759;
        public const uint OrcDisguiseMale = 45760;
        public const uint OrcDisguiseFemale = 45762;

        //Parachutespells
        public const uint Parachute = 45472;
        public const uint ParachuteBuff = 44795;

        //Trinketspells
        public const uint PvpTrinketAlliance = 97403;
        public const uint PvpTrinketHorde = 97404;

        //Replenishment
        public const uint Replenishment = 57669;
        public const uint InfiniteReplenishment = 61782;

        //Runningwild
        public const uint AlteredForm = 97709;

        //Seaforiumspells
        public const uint PlantChargesCreditAchievement = 60937;

        //Summonelemental
        public const uint SummonFireElemental = 8985;
        public const uint SummonEarthElemental = 19704;

        //Tournamentmountsspells
        public const uint LanceEquipped = 62853;

        //Mountedduelspells
        public const uint OnTournamentMount = 63034;
        public const uint MountedDuel = 62875;

        //Pvptrinkettriggeredspells
        public const uint WillOfTheForsakenCooldownTrigger = 72752;
        public const uint WillOfTheForsakenCooldownTriggerWotf = 72757;

        //Friendorfowl
        public const uint TurkeyVengeance = 25285;

        //Vampirictouch
        public const uint VampiricTouchHeal = 52724;

        //Vehiclescaling
        public const uint GearScaling = 66668;

        //Whispergulchyoggsaronwhisper
        public const uint YoggSaronWhisperDummy = 29072;

        //Gmfreeze
        public const uint GmFreeze = 9454;

        //Landmineknockbackachievement        
        public const uint LandmineKnockbackAchievement = 57064;
        
        //Ponyspells
        public const uint AchievementPonyup = 3736;
        public const uint MountPony = 29736;

        //Kazrogalhellfiremark
        public const uint MarkOfKazrogalHellfire = 189512;
        public const uint MarkOfKazrogalDamageHellfire = 189515;

        // Auraprocremovespells
        public const uint FaceRage = 99947;
        public const uint ImpatientMind = 187213;
    }

    struct CreatureIds
    {
        //EluneCandle
        public const uint Omen = 15467;

        //TournamentMounts
        public const uint StormwindSteed = 33217;
        public const uint IronforgeRam = 33316;
        public const uint GnomereganMechanostrider = 33317;
        public const uint ExodarElekk = 33318;
        public const uint DarnassianNightsaber = 33319;
        public const uint OrgrimmarWolf = 33320;
        public const uint DarkSpearRaptor = 33321;
        public const uint ThunderBluffKodo = 33322;
        public const uint SilvermoonHawkstrider = 33323;
        public const uint ForsakenWarhorse = 33324;
        public const uint ArgentWarhorse = 33782;
        public const uint ArgentSteedAspirant = 33845;
        public const uint ArgentHawkstriderAspirant = 33844;

        //PetSummoned
        public const uint Doomguard = 11859;
        public const uint Infernal = 89;
        public const uint Imp = 416;

        //VendorBarkTrigger
        public const uint AmphitheaterVendor = 30098;
    }

    struct ModelIds
    {
        //ServiceUniform
        public const uint GoblinMale = 31002;
        public const uint GoblinFemale = 31003;

        //RunningWild
        public const uint RunningWild = 73200;
    }

    struct TextIds
    {
        //VendorBarkTrigger
        public const uint SayAmphitheaterVendor = 0;
    }

    struct AchievementIds
    {
        //TournamentAchievements
        public const uint ChampionStormwind = 2781;
        public const uint ChampionDarnassus = 2777;
        public const uint ChampionIronforge = 2780;
        public const uint ChampionGnomeregan = 2779;
        public const uint ChampionTheExodar = 2778;
        public const uint ChampionOrgrimmar = 2783;
        public const uint ChampionSenJin = 2784;
        public const uint ChampionThunderBluff = 2786;
        public const uint ChampionUndercity = 2787;
        public const uint ChampionSilvermoon = 2785;
        public const uint ArgentValor = 2758;
        public const uint ChampionAlliance = 2782;
        public const uint ChampionHorde = 2788;
    }
    struct QuestIds
    {
        //TournamentQuests
        public const uint ValiantOfStormwind = 13593;
        public const uint A_ValiantOfStormwind = 13684;
        public const uint ValiantOfDarnassus = 13706;
        public const uint A_ValiantOfDarnassus = 13689;
        public const uint ValiantOfIronforge = 13703;
        public const uint A_ValiantOfIronforge = 13685;
        public const uint ValiantOfGnomeregan = 13704;
        public const uint A_ValiantOfGnomeregan = 13688;
        public const uint ValiantOfTheExodar = 13705;
        public const uint A_ValiantOfTheExodar = 13690;
        public const uint ValiantOfOrgrimmar = 13707;
        public const uint A_ValiantOfOrgrimmar = 13691;
        public const uint ValiantOfSenJin = 13708;
        public const uint A_ValiantOfSenJin = 13693;
        public const uint ValiantOfThunderBluff = 13709;
        public const uint A_ValiantOfThunderBluff = 13694;
        public const uint ValiantOfUndercity = 13710;
        public const uint A_ValiantOfUndercity = 13695;
        public const uint ValiantOfSilvermoon = 13711;
        public const uint A_ValiantOfSilvermoon = 13696;
    }

    [Script]
    class spell_gen_absorb0_hitlimit1 : SpellScriptLoader
    {
        public spell_gen_absorb0_hitlimit1() : base("spell_gen_absorb0_hitlimit1") { }

        class spell_gen_absorb0_hitlimit1_AuraScript : AuraScript
        {
            public override bool Load()
            {
                // Max absorb stored in 1 dummy effect
                limit = GetSpellInfo().GetEffect(1).CalcValue();
                return true;
            }

            void Absorb(AuraEffect aurEff, DamageInfo dmgInfo, ref uint absorbAmount)
            {
                absorbAmount = (uint)Math.Min(limit, absorbAmount);
            }

            public override void Register()
            {
                OnEffectAbsorb.Add(new EffectAbsorbHandler(Absorb, 0));
            }

            int limit;
        }

        public override AuraScript GetAuraScript()
        {
            return new spell_gen_absorb0_hitlimit1_AuraScript();
        }
    }

    [Script] // 28764 - Adaptive Warding (Frostfire Regalia Set)
    class spell_gen_adaptive_warding : SpellScriptLoader
    {
        public spell_gen_adaptive_warding() : base("spell_gen_adaptive_warding") { }

        class spell_gen_adaptive_warding_AuraScript : AuraScript
        {
            public override bool Validate(SpellInfo spellInfo)
            {
                return ValidateSpellInfo(SpellIds.GenAdaptiveWardingFire, SpellIds.GenAdaptiveWardingNature, SpellIds.GenAdaptiveWardingFrost, SpellIds.GenAdaptiveWardingShadow, SpellIds.GenAdaptiveWardingArcane);
            }

            bool CheckProc(ProcEventInfo eventInfo)
            {
                if (eventInfo.GetDamageInfo().GetSpellInfo() != null) // eventInfo.GetSpellInfo()
                    return false;

                // find Mage Armor
                if (GetTarget().GetAuraEffect(AuraType.ModManaRegenInterrupt, SpellFamilyNames.Mage, new FlagArray128(0x10000000, 0x0, 0x0)) == null)
                    return false;

                switch (SharedConst.GetFirstSchoolInMask(eventInfo.GetSchoolMask()))
                {
                    case SpellSchools.Normal:
                    case SpellSchools.Holy:
                        return false;
                    default:
                        break;
                }
                return true;
            }

            void HandleProc(AuraEffect aurEff, ProcEventInfo eventInfo)
            {
                PreventDefaultAction();

                uint spellId = 0;
                switch (SharedConst.GetFirstSchoolInMask(eventInfo.GetSchoolMask()))
                {
                    case SpellSchools.Fire:
                        spellId = SpellIds.GenAdaptiveWardingFire;
                        break;
                    case SpellSchools.Nature:
                        spellId = SpellIds.GenAdaptiveWardingNature;
                        break;
                    case SpellSchools.Frost:
                        spellId = SpellIds.GenAdaptiveWardingFrost;
                        break;
                    case SpellSchools.Shadow:
                        spellId = SpellIds.GenAdaptiveWardingShadow;
                        break;
                    case SpellSchools.Arcane:
                        spellId = SpellIds.GenAdaptiveWardingArcane;
                        break;
                    default:
                        return;
                }
                GetTarget().CastSpell(GetTarget(), spellId, true, null, aurEff);
            }

            public override void Register()
            {
                DoCheckProc.Add(new CheckProcHandler(CheckProc));
                OnEffectProc.Add(new EffectProcHandler(HandleProc, 0, AuraType.Dummy));
            }
        }

        public override AuraScript GetAuraScript()
        {
            return new spell_gen_adaptive_warding_AuraScript();
        }
    }

    [Script]
    class spell_gen_allow_cast_from_item_only : SpellScriptLoader
    {
        public spell_gen_allow_cast_from_item_only() : base("spell_gen_allow_cast_from_item_only") { }

        class spell_gen_allow_cast_from_item_only_SpellScript : SpellScript
        {
            SpellCastResult CheckRequirement()
            {
                if (!GetCastItem())
                    return SpellCastResult.CantDoThatRightNow;
                return SpellCastResult.SpellCastOk;
            }

            public override void Register()
            {
                OnCheckCast.Add(new CheckCastHandler(CheckRequirement));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_allow_cast_from_item_only_SpellScript();
        }
    }

    [Script]
    class spell_gen_animal_blood : SpellScriptLoader
    {
        public spell_gen_animal_blood() : base("spell_gen_animal_blood") { }

        class spell_gen_animal_blood_AuraScript : AuraScript
        {
            public override bool Validate(SpellInfo spellInfo)
            {
                return ValidateSpellInfo(SpellIds.SpawnBloodPool);
            }

            void OnApply(AuraEffect aurEff, AuraEffectHandleModes mode)
            {
                // Remove all auras with spell id 46221, except the one currently being applied
                Aura aur;
                while ((aur = GetUnitOwner().GetOwnedAura(SpellIds.AnimalBlood, ObjectGuid.Empty, ObjectGuid.Empty, 0, GetAura())) != null)
                    GetUnitOwner().RemoveOwnedAura(aur);
            }

            void OnRemove(AuraEffect aurEff, AuraEffectHandleModes mode)
            {
                Unit owner = GetUnitOwner();
                if (owner)
                    if (owner.IsInWater())
                        owner.CastSpell(owner, SpellIds.SpawnBloodPool, true);
            }

            public override void Register()
            {
                AfterEffectApply.Add(new EffectApplyHandler(OnApply, 0, AuraType.PeriodicTriggerSpell, AuraEffectHandleModes.Real));
                AfterEffectRemove.Add(new EffectApplyHandler(OnRemove, 0, AuraType.PeriodicTriggerSpell, AuraEffectHandleModes.Real));
            }
        }

        public override AuraScript GetAuraScript()
        {
            return new spell_gen_animal_blood_AuraScript();
        }
    }

    [Script] // 41337 Aura of Anger
    class spell_gen_aura_of_anger : SpellScriptLoader
    {
        public spell_gen_aura_of_anger() : base("spell_gen_aura_of_anger") { }

        class spell_gen_aura_of_anger_AuraScript : AuraScript
        {
            void HandleEffectPeriodicUpdate(AuraEffect aurEff)
            {
                AuraEffect aurEff1 = aurEff.GetBase().GetEffect(1);
                if (aurEff1 != null)
                    aurEff1.ChangeAmount(aurEff1.GetAmount() + 5);
                aurEff.SetAmount((int)(100 * aurEff.GetTickNumber()));
            }

            public override void Register()
            {
                OnEffectUpdatePeriodic.Add(new EffectUpdatePeriodicHandler(HandleEffectPeriodicUpdate, 0, AuraType.PeriodicDamage));
            }
        }

        public override AuraScript GetAuraScript()
        {
            return new spell_gen_aura_of_anger_AuraScript();
        }
    }

    [Script]
    class spell_gen_aura_service_uniform : SpellScriptLoader
    {
        public spell_gen_aura_service_uniform() : base("spell_gen_aura_service_uniform") { }

        class spell_gen_aura_service_uniform_AuraScript : AuraScript
        {
            public override bool Validate(SpellInfo spellInfo)
            {
                return ValidateSpellInfo(SpellIds.ServiceUniform);
            }

            void OnApply(AuraEffect aurEff, AuraEffectHandleModes mode)
            {
                // Apply model goblin
                Unit target = GetTarget();
                if (target.IsTypeId(TypeId.Player))
                {
                    if (target.GetGender() == Gender.Male)
                        target.SetDisplayId(ModelIds.GoblinMale);
                    else
                        target.SetDisplayId(ModelIds.GoblinFemale);
                }
            }

            void OnRemove(AuraEffect aurEff, AuraEffectHandleModes mode)
            {
                Unit target = GetTarget();
                if (target.IsTypeId(TypeId.Player))
                    target.RestoreDisplayId();
            }

            public override void Register()
            {
                AfterEffectApply.Add(new EffectApplyHandler(OnApply, 0, AuraType.Transform, AuraEffectHandleModes.Real));
                AfterEffectRemove.Add(new EffectApplyHandler(OnRemove, 0, AuraType.Transform, AuraEffectHandleModes.Real));
            }
        }

        public override AuraScript GetAuraScript()
        {
            return new spell_gen_aura_service_uniform_AuraScript();
        }
    }

    [Script]
    class spell_gen_av_drekthar_presence : SpellScriptLoader
    {
        public spell_gen_av_drekthar_presence() : base("spell_gen_av_drekthar_presence") { }

        class spell_gen_av_drekthar_presence_AuraScript : AuraScript
        {
            bool CheckAreaTarget(Unit target)
            {
                switch (target.GetEntry())
                {
                    // alliance
                    case 14762: // Dun Baldar North Marshal
                    case 14763: // Dun Baldar South Marshal
                    case 14764: // Icewing Marshal
                    case 14765: // Stonehearth Marshal
                    case 11948: // Vandar Stormspike
                                // horde
                    case 14772: // East Frostwolf Warmaster
                    case 14776: // Tower Point Warmaster
                    case 14773: // Iceblood Warmaster
                    case 14777: // West Frostwolf Warmaster
                    case 11946: // Drek'thar
                        return true;
                    default:
                        return false;
                }
            }

            public override void Register()
            {
                DoCheckAreaTarget.Add(new CheckAreaTargetHandler(CheckAreaTarget));
            }
        }

        public override AuraScript GetAuraScript()
        {
            return new spell_gen_av_drekthar_presence_AuraScript();
        }
    }

    [Script]
    class spell_gen_bandage : SpellScriptLoader
    {
        public spell_gen_bandage() : base("spell_gen_bandage") { }

        class spell_gen_bandage_SpellScript : SpellScript
        {
            public override bool Validate(SpellInfo spellInfo)
            {
                return ValidateSpellInfo(SpellIds.RecentlyBandaged);
            }

            SpellCastResult CheckCast()
            {
                Unit target = GetExplTargetUnit();
                if (target)
                {
                    if (target.HasAura(SpellIds.RecentlyBandaged))
                        return SpellCastResult.TargetAurastate;
                }
                return SpellCastResult.SpellCastOk;
            }

            void HandleScript()
            {
                Unit target = GetHitUnit();
                if (target)
                    GetCaster().CastSpell(target, SpellIds.RecentlyBandaged, true);
            }

            public override void Register()
            {
                OnCheckCast.Add(new CheckCastHandler(CheckCast));
                AfterHit.Add(new HitHandler(HandleScript));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_bandage_SpellScript();
        }
    }

    [Script] // Blood Reserve - 64568
    class spell_gen_blood_reserve : SpellScriptLoader
    {
        public spell_gen_blood_reserve() : base("spell_gen_blood_reserve") { }

        class spell_gen_blood_reserve_AuraScript : AuraScript
        {
            public override bool Validate(SpellInfo spellInfo)
            {
                return ValidateSpellInfo(SpellIds.BloodReserveHeal);
            }

            bool CheckProc(ProcEventInfo eventInfo)
            {
                DamageInfo dmgInfo = eventInfo.GetDamageInfo();
                if (dmgInfo != null)
                {
                    Unit caster = eventInfo.GetActionTarget();
                    if (caster)
                        if (caster.HealthBelowPctDamaged(35, dmgInfo.GetDamage()))
                            return true;
                }

                return false;
            }

            void HandleProc(AuraEffect aurEff, ProcEventInfo eventInfo)
            {
                PreventDefaultAction();

                Unit caster = eventInfo.GetActionTarget();
                caster.CastCustomSpell(SpellIds.BloodReserveHeal, SpellValueMod.BasePoint0, aurEff.GetAmount(), caster, TriggerCastFlags.FullMask, null, aurEff);
                caster.RemoveAura(SpellIds.BloodReserveAura);
            }

            public override void Register()
            {
                DoCheckProc.Add(new CheckProcHandler(CheckProc));
                OnEffectProc.Add(new EffectProcHandler(HandleProc, 0, AuraType.ProcTriggerSpell));
            }
        }

        public override AuraScript GetAuraScript()
        {
            return new spell_gen_blood_reserve_AuraScript();
        }
    }

    [Script]
    class spell_gen_bonked : SpellScriptLoader
    {
        public spell_gen_bonked() : base("spell_gen_bonked") { }

        class spell_gen_bonked_SpellScript : SpellScript
        {
            void HandleScript(uint effIndex)
            {
                Player target = GetHitPlayer();
                if (target)
                {
                    Aura aura = GetHitAura();
                    if (!(aura != null && aura.GetStackAmount() == 3))
                        return;

                    target.CastSpell(target, SpellIds.FormSwordDefeat, true);
                    target.RemoveAurasDueToSpell(SpellIds.Bonked);

                    aura = target.GetAura(SpellIds.Onguard);
                    if (aura != null)
                    {
                        Item item = target.GetItemByGuid(aura.GetCastItemGUID());
                        if (item)
                            target.DestroyItemCount(item.GetEntry(), 1, true);
                    }
                }
            }

            public override void Register()
            {
                OnEffectHitTarget.Add(new EffectHandler(HandleScript, 1, SpellEffectName.ScriptEffect));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_bonked_SpellScript();
        }
    }

    [Script("spell_gen_break_shield")]
    [Script("spell_gen_tournament_counterattack")]
    class spell_gen_break_shield : SpellScriptLoader
    {
        public spell_gen_break_shield(string name) : base(name) { }

        class spell_gen_break_shield_SpellScript : SpellScript
        {
            public override bool Validate(SpellInfo spellInfo)
            {
                return ValidateSpellInfo(62552, 62719, 64100, 66482);
            }

            void HandleScriptEffect(uint effIndex)
            {
                Unit target = GetHitUnit();

                switch (effIndex)
                {
                    case 0: // On spells wich trigger the damaging spell (and also the visual)
                        {
                            uint spellId;

                            switch (GetSpellInfo().Id)
                            {
                                case SpellIds.BreakShieldTriggerUnk:
                                case SpellIds.BreakShieldTriggerCampaingWarhorse:
                                    spellId = SpellIds.BreakShieldDamage10k;
                                    break;
                                case SpellIds.BreakShieldTriggerFactionMounts:
                                    spellId = SpellIds.BreakShieldDamage2k;
                                    break;
                                default:
                                    return;
                            }
                            Unit rider = GetCaster().GetCharmer();
                            if (rider)
                                rider.CastSpell(target, spellId, false);
                            else
                                GetCaster().CastSpell(target, spellId, false);
                            break;
                        }
                    case 1: // On damaging spells, for removing a defend layer
                        {
                            var auras = target.GetAppliedAuras();
                            foreach (var pair in auras)
                            {
                                Aura aura = pair.Value.GetBase();
                                if (aura != null)
                                {
                                    if (aura.GetId() == 62552 || aura.GetId() == 62719 || aura.GetId() == 64100 || aura.GetId() == 66482)
                                    {
                                        aura.ModStackAmount(-1, AuraRemoveMode.EnemySpell);
                                        // Remove dummys from rider (Necessary for updating visual shields)
                                        Unit rider = target.GetCharmer();
                                        if (rider)
                                        {
                                            Aura defend = rider.GetAura(aura.GetId());
                                            if (defend != null)
                                                defend.ModStackAmount(-1, AuraRemoveMode.EnemySpell);
                                        }
                                        break;
                                    }
                                }
                            }
                            break;
                        }
                    default:
                        break;
                }
            }

            public override void Register()
            {
                OnEffectHitTarget.Add(new EffectHandler(HandleScriptEffect, SpellConst.EffectFirstFound, SpellEffectName.ScriptEffect));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_break_shield_SpellScript();
        }
    }

    [Script] // 46394 Brutallus Burn
    class spell_gen_burn_brutallus : SpellScriptLoader
    {
        public spell_gen_burn_brutallus() : base("spell_gen_burn_brutallus") { }

        class spell_gen_burn_brutallus_AuraScript : AuraScript
        {
            void HandleEffectPeriodicUpdate(AuraEffect aurEff)
            {
                if (aurEff.GetTickNumber() % 11 == 0)
                    aurEff.SetAmount(aurEff.GetAmount() * 2);
            }

            public override void Register()
            {
                OnEffectUpdatePeriodic.Add(new EffectUpdatePeriodicHandler(HandleEffectPeriodicUpdate, 0, AuraType.PeriodicDamage));
            }
        }

        public override AuraScript GetAuraScript()
        {
            return new spell_gen_burn_brutallus_AuraScript();
        }
    }

    [Script] // 48750 - Burning Depths Necrolyte Image
    class spell_gen_burning_depths_necrolyte_image : SpellScriptLoader
    {
        public spell_gen_burning_depths_necrolyte_image() : base("spell_gen_burning_depths_necrolyte_image") { }

        class spell_gen_burning_depths_necrolyte_image_AuraScript : AuraScript
        {
            public override bool Validate(SpellInfo spellInfo)
            {
                return ValidateSpellInfo((uint)spellInfo.GetEffect(2).CalcValue());
            }

            void HandleApply(AuraEffect aurEff, AuraEffectHandleModes mode)
            {
                Unit caster = GetCaster();
                if (caster)
                    caster.CastSpell(GetTarget(), (uint)GetSpellInfo().GetEffect(2).CalcValue());
            }

            void HandleRemove(AuraEffect aurEff, AuraEffectHandleModes mode)
            {
                GetTarget().RemoveAurasDueToSpell((uint)GetSpellInfo().GetEffect(2).CalcValue(), GetCasterGUID());
            }

            public override void Register()
            {
                AfterEffectApply.Add(new EffectApplyHandler(HandleApply, 0, AuraType.Transform, AuraEffectHandleModes.Real));
                AfterEffectRemove.Add(new EffectApplyHandler(HandleRemove, 0, AuraType.Transform, AuraEffectHandleModes.Real));
            }
        }

        public override AuraScript GetAuraScript()
        {
            return new spell_gen_burning_depths_necrolyte_image_AuraScript();
        }
    }

    [Script]
    class spell_gen_cannibalize : SpellScriptLoader
    {
        public spell_gen_cannibalize() : base("spell_gen_cannibalize") { }

        class spell_gen_cannibalize_SpellScript : SpellScript
        {
            public override bool Validate(SpellInfo spellInfo)
            {
                return ValidateSpellInfo(SpellIds.CannibalizeTriggered);
            }

            SpellCastResult CheckIfCorpseNear()
            {
                Unit caster = GetCaster();
                float max_range = GetSpellInfo().GetMaxRange(false);
                // search for nearby enemy corpse in range
                var check = new AnyDeadUnitSpellTargetInRangeCheck<Unit>(caster, max_range, GetSpellInfo(), SpellTargetCheckTypes.Enemy);
                var searcher = new UnitSearcher(caster, check);
                Cell.VisitWorldObjects(caster, searcher, max_range);
                if (!searcher.GetTarget())
                    Cell.VisitGridObjects(caster, searcher, max_range);
                if (!searcher.GetTarget())
                    return SpellCastResult.NoEdibleCorpses;
                return SpellCastResult.SpellCastOk;
            }

            void HandleDummy(uint effIndex)
            {
                GetCaster().CastSpell(GetCaster(), SpellIds.CannibalizeTriggered, false);
            }

            public override void Register()
            {
                OnEffectHit.Add(new EffectHandler(HandleDummy, 0, SpellEffectName.Dummy));
                OnCheckCast.Add(new CheckCastHandler(CheckIfCorpseNear));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_cannibalize_SpellScript();
        }
    }

    [Script]
    class spell_gen_chaos_blast : SpellScriptLoader
    {
        public spell_gen_chaos_blast() : base("spell_gen_chaos_blast") { }

        class spell_gen_chaos_blast_SpellScript : SpellScript
        {
            public override bool Validate(SpellInfo spellInfo)
            {
                return ValidateSpellInfo(SpellIds.ChaosBlast);
            }

            void HandleDummy(uint effIndex)
            {
                int basepoints0 = 100;
                Unit caster = GetCaster();
                Unit target = GetHitUnit();
                if (target)
                    caster.CastCustomSpell(target, SpellIds.ChaosBlast, basepoints0, 0, 0, true);
            }

            public override void Register()
            {
                OnEffectHitTarget.Add(new EffectHandler(HandleDummy, 0, SpellEffectName.Dummy));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_chaos_blast_SpellScript();
        }
    }

    [Script]
    class spell_gen_clone : SpellScriptLoader
    {
        public spell_gen_clone() : base("spell_gen_clone") { }

        class spell_gen_clone_SpellScript : SpellScript
        {
            void HandleScriptEffect(uint effIndex)
            {
                PreventHitDefaultEffect(effIndex);
                GetHitUnit().CastSpell(GetCaster(), (uint)GetEffectValue(), true);
            }

            public override void Register()
            {
                if (m_scriptSpellId == SpellIds.NightmareFigmentMirrorImage)
                {
                    OnEffectHitTarget.Add(new EffectHandler(HandleScriptEffect, 1, SpellEffectName.Dummy));
                    OnEffectHitTarget.Add(new EffectHandler(HandleScriptEffect, 2, SpellEffectName.Dummy));
                }
                else
                {
                    OnEffectHitTarget.Add(new EffectHandler(HandleScriptEffect, 1, SpellEffectName.ScriptEffect));
                    OnEffectHitTarget.Add(new EffectHandler(HandleScriptEffect, 2, SpellEffectName.ScriptEffect));
                }
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_clone_SpellScript();
        }
    }

    [Script]
    class spell_gen_clone_weapon : SpellScriptLoader
    {
        public spell_gen_clone_weapon() : base("spell_gen_clone_weapon") { }

        class spell_gen_clone_weapon_SpellScript : SpellScript
        {
            void HandleScriptEffect(uint effIndex)
            {
                PreventHitDefaultEffect(effIndex);
                GetHitUnit().CastSpell(GetCaster(), (uint)GetEffectValue(), true);
            }

            public override void Register()
            {
                OnEffectHitTarget.Add(new EffectHandler(HandleScriptEffect, 0, SpellEffectName.ScriptEffect));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_clone_weapon_SpellScript();
        }
    }

    [Script]
    class spell_gen_clone_weapon_aura : SpellScriptLoader
    {
        public spell_gen_clone_weapon_aura() : base("spell_gen_clone_weapon_aura") { }

        class spell_gen_clone_weapon_auraScript : AuraScript
        {
            public override bool Validate(SpellInfo spellInfo)
            {
                return ValidateSpellInfo(SpellIds.WeaponAura, SpellIds.Weapon2Aura, SpellIds.Weapon3Aura, SpellIds.OffhandAura, SpellIds.Offhand2Aura, SpellIds.RangedAura);
            }

            public override bool Load()
            {
                prevItem = 0;
                return true;
            }

            void OnApply(AuraEffect aurEff, AuraEffectHandleModes mode)
            {
                Unit caster = GetCaster();
                Unit target = GetTarget();
                if (!caster)
                    return;

                switch (GetSpellInfo().Id)
                {
                    case SpellIds.WeaponAura:
                    case SpellIds.Weapon2Aura:
                    case SpellIds.Weapon3Aura:
                        {
                            prevItem = target.GetVirtualItemId(0);

                            Player player = caster.ToPlayer();
                            if (player)
                            {
                                Item mainItem = player.GetItemByPos(InventorySlots.Bag0, EquipmentSlot.MainHand);
                                if (mainItem)
                                    target.SetVirtualItem(0, mainItem.GetEntry());
                            }
                            else
                                target.SetVirtualItem(0, caster.GetVirtualItemId(0));
                            break;
                        }
                    case SpellIds.OffhandAura:
                    case SpellIds.Offhand2Aura:
                        {
                            prevItem = target.GetVirtualItemId(1);

                            Player player = caster.ToPlayer();
                            if (player)
                            {
                                Item offItem = player.GetItemByPos(InventorySlots.Bag0, EquipmentSlot.OffHand);
                                if (offItem)
                                    target.SetVirtualItem(1, offItem.GetEntry());
                            }
                            else
                                target.SetVirtualItem(1, caster.GetVirtualItemId(1));
                            break;
                        }
                    case SpellIds.RangedAura:
                        {
                            prevItem = target.GetVirtualItemId(2);

                            Player player = caster.ToPlayer();
                            if (player)
                            {
                                Item rangedItem = player.GetItemByPos(InventorySlots.Bag0, EquipmentSlot.MainHand);
                                if (rangedItem)
                                    target.SetVirtualItem(2, rangedItem.GetEntry());
                            }
                            else
                                target.SetVirtualItem(2, caster.GetVirtualItemId(2));
                            break;
                        }
                    default:
                        break;
                }
            }

            void OnRemove(AuraEffect aurEff, AuraEffectHandleModes mode)
            {
                Unit target = GetTarget();

                switch (GetSpellInfo().Id)
                {
                    case SpellIds.WeaponAura:
                    case SpellIds.Weapon2Aura:
                    case SpellIds.Weapon3Aura:
                        target.SetVirtualItem(0, prevItem);
                        break;
                    case SpellIds.OffhandAura:
                    case SpellIds.Offhand2Aura:
                        target.SetVirtualItem(1, prevItem);
                        break;
                    case SpellIds.RangedAura:
                        target.SetVirtualItem(2, prevItem);
                        break;
                    default:
                        break;
                }
            }

            public override void Register()
            {
                OnEffectApply.Add(new EffectApplyHandler(OnApply, 0, AuraType.PeriodicDummy, AuraEffectHandleModes.RealOrReapplyMask));
                OnEffectRemove.Add(new EffectApplyHandler(OnRemove, 0, AuraType.PeriodicDummy, AuraEffectHandleModes.RealOrReapplyMask));
            }

            uint prevItem;
        }

        public override AuraScript GetAuraScript()
        {
            return new spell_gen_clone_weapon_auraScript();
        }
    }

    [Script("spell_gen_default_count_pct_from_max_hp", 0)]
    [Script("spell_gen_50pct_count_pct_from_max_hp", 50)]
    class spell_gen_count_pct_from_max_hp : SpellScriptLoader
    {
        public spell_gen_count_pct_from_max_hp(string name, int damagePct) : base(name)
        {
            _damagePct = damagePct;
        }

        class spell_gen_count_pct_from_max_hp_SpellScript : SpellScript
        {
            public spell_gen_count_pct_from_max_hp_SpellScript(int damagePct)
            {
                _damagePct = damagePct;
            }

            void RecalculateDamage()
            {
                if (_damagePct == 0)
                    _damagePct = GetHitDamage();

                SetHitDamage((int)GetHitUnit().CountPctFromMaxHealth(_damagePct));
            }

            public override void Register()
            {
                OnHit.Add(new HitHandler(RecalculateDamage));
            }

            int _damagePct;
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_count_pct_from_max_hp_SpellScript(_damagePct);
        }

        int _damagePct;
    }

    [Script] // 63845 - Create Lance
    class spell_gen_create_lance : SpellScriptLoader
    {
        public spell_gen_create_lance() : base("spell_gen_create_lance") { }

        class spell_gen_create_lance_SpellScript : SpellScript
        {
            public override bool Validate(SpellInfo spellInfo)
            {
                return ValidateSpellInfo(SpellIds.CreateLanceAlliance, SpellIds.CreateLanceHorde);
            }

            void HandleScript(uint effIndex)
            {
                PreventHitDefaultEffect(effIndex);

                Player target = GetHitPlayer();
                if (target)
                {
                    if (target.GetTeam() == Team.Alliance)
                        GetCaster().CastSpell(target, SpellIds.CreateLanceAlliance, true);
                    else
                        GetCaster().CastSpell(target, SpellIds.CreateLanceHorde, true);
                }
            }

            public override void Register()
            {
                OnEffectHitTarget.Add(new EffectHandler(HandleScript, 0, SpellEffectName.ScriptEffect));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_create_lance_SpellScript();
        }
    }

    [Script]
    class spell_gen_creature_permanent_feign_death : SpellScriptLoader
    {
        public spell_gen_creature_permanent_feign_death() : base("spell_gen_creature_permanent_feign_death") { }

        class spell_gen_creature_permanent_feign_death_AuraScript : AuraScript
        {
            void HandleEffectApply(AuraEffect aurEff, AuraEffectHandleModes mode)
            {
                Unit target = GetTarget();
                target.SetFlag(ObjectFields.DynamicFlags, UnitDynFlags.Dead);
                target.SetFlag(UnitFields.Flags2, UnitFlags2.FeignDeath);

                if (target.IsTypeId(TypeId.Unit))
                    target.ToCreature().SetReactState(ReactStates.Passive);
            }

            public override void Register()
            {
                OnEffectApply.Add(new EffectApplyHandler(HandleEffectApply, 0, AuraType.Dummy, AuraEffectHandleModes.Real));
            }
        }

        public override AuraScript GetAuraScript()
        {
            return new spell_gen_creature_permanent_feign_death_AuraScript();
        }
    }

    [Script("spell_gen_sunreaver_disguise")]
    [Script("spell_gen_silver_covenant_disguise")]
    class spell_gen_dalaran_disguise : SpellScriptLoader
    {
        public spell_gen_dalaran_disguise(string name) : base(name) { }

        class spell_gen_dalaran_disguise_SpellScript : SpellScript
        {
            public override bool Validate(SpellInfo spellInfo)
            {
                switch (spellInfo.Id)
                {
                    case SpellIds.SunreaverTrigger:
                        return ValidateSpellInfo(SpellIds.SunreaverFemale, SpellIds.SunreaverMale);
                    case SpellIds.SilverCovenantTrigger:
                        return ValidateSpellInfo(SpellIds.SilverCovenantFemale, SpellIds.SilverCovenantMale);
                }
                return false;
            }

            void HandleScript(uint effIndex)
            {
                Player player = GetHitPlayer();
                if (player)
                {
                    Gender gender = player.GetGender();

                    uint spellId = GetSpellInfo().Id;
                    switch (spellId)
                    {
                        case SpellIds.SunreaverTrigger:
                            spellId = gender == Gender.Female ? SpellIds.SunreaverFemale : SpellIds.SunreaverMale;
                            break;
                        case SpellIds.SilverCovenantTrigger:
                            spellId = gender == Gender.Female ? SpellIds.SilverCovenantFemale : SpellIds.SilverCovenantMale;
                            break;
                        default:
                            break;
                    }

                    GetCaster().CastSpell(player, spellId, true);
                }
            }

            public override void Register()
            {
                OnEffectHitTarget.Add(new EffectHandler(HandleScript, 0, SpellEffectName.ScriptEffect));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_dalaran_disguise_SpellScript();
        }
    }

    [Script]
    class spell_gen_defend : SpellScriptLoader
    {
        public spell_gen_defend() : base("spell_gen_defend") { }

        class spell_gen_defend_AuraScript : AuraScript
        {
            public override bool Validate(SpellInfo spellInfo)
            {
                return ValidateSpellInfo(SpellIds.VisualShield1, SpellIds.VisualShield2, SpellIds.VisualShield3);
            }

            void RefreshVisualShields(AuraEffect aurEff, AuraEffectHandleModes mode)
            {
                if (GetCaster())
                {
                    Unit target = GetTarget();

                    for (byte i = 0; i < GetSpellInfo().StackAmount; ++i)
                        target.RemoveAurasDueToSpell(SpellIds.VisualShield1 + i);

                    target.CastSpell(target, SpellIds.VisualShield1 + GetAura().GetStackAmount() - 1, true, null, aurEff);
                }
                else
                    GetTarget().RemoveAurasDueToSpell(GetId());
            }

            void RemoveVisualShields(AuraEffect aurEff, AuraEffectHandleModes mode)
            {
                for (byte i = 0; i < GetSpellInfo().StackAmount; ++i)
                    GetTarget().RemoveAurasDueToSpell(SpellIds.VisualShield1 + i);
            }

            void RemoveDummyFromDriver(AuraEffect aurEff, AuraEffectHandleModes mode)
            {
                Unit caster = GetCaster();
                if (caster)
                {
                    TempSummon vehicle = caster.ToTempSummon();
                    if (vehicle)
                    {
                        Unit rider = vehicle.GetSummoner();
                        if (rider)
                            rider.RemoveAurasDueToSpell(GetId());
                    }
                }
            }

            public override void Register()
            {
                /*SpellInfo spell = Global.SpellMgr.GetSpellInfo(m_scriptSpellId);

                // Defend spells cast by NPCs (add visuals)
                if (spell.GetEffect(0).ApplyAuraName == AuraType.ModDamagePercentTaken)
                {
                    AfterEffectApply.Add(new EffectApplyHandler(RefreshVisualShields, 0, AuraType.ModDamagePercentTaken, AuraEffectHandleModes.RealOrReapplyMask));
                    OnEffectRemove.Add(new EffectApplyHandler(RemoveVisualShields, 0, AuraType.ModDamagePercentTaken, AuraEffectHandleModes.ChangeAmountMask));
                }

                // Remove Defend spell from player when he dismounts
                if (spell.GetEffect(2).ApplyAuraName == AuraType.ModDamagePercentTaken)
                    OnEffectRemove.Add(new EffectApplyHandler(RemoveDummyFromDriver, 2, AuraType.ModDamagePercentTaken, AuraEffectHandleModes.Real));

                // Defend spells cast by players (add/remove visuals)
                if (spell.GetEffect(1).ApplyAuraName == AuraType.Dummy)
                {
                    AfterEffectApply.Add(new EffectApplyHandler(RefreshVisualShields, 1, AuraType.Dummy, AuraEffectHandleModes.RealOrReapplyMask));
                    OnEffectRemove.Add(new EffectApplyHandler(RemoveVisualShields, 1, AuraType.Dummy, AuraEffectHandleModes.ChangeAmountMask));
                }*/
            }
        }

        public override AuraScript GetAuraScript()
        {
            return new spell_gen_defend_AuraScript();
        }
    }

    [Script]
    class spell_gen_despawn_self : SpellScriptLoader
    {
        public spell_gen_despawn_self() : base("spell_gen_despawn_self") { }

        class spell_gen_despawn_self_SpellScript : SpellScript
        {
            public override bool Load()
            {
                return GetCaster().IsTypeId(TypeId.Unit);
            }

            void HandleDummy(uint effIndex)
            {
                if (GetSpellInfo().GetEffect(effIndex).Effect == SpellEffectName.Dummy || GetSpellInfo().GetEffect(effIndex).Effect == SpellEffectName.ScriptEffect)
                    GetCaster().ToCreature().DespawnOrUnsummon();
            }

            public override void Register()
            {
                OnEffectHitTarget.Add(new EffectHandler(HandleDummy, SpellConst.EffectAll, SpellEffectName.Any));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_despawn_self_SpellScript();
        }
    }

    [Script] // 70769 Divine Storm!
    class spell_gen_divine_storm_cd_reset : SpellScriptLoader
    {
        public spell_gen_divine_storm_cd_reset() : base("spell_gen_divine_storm_cd_reset") { }

        class spell_gen_divine_storm_cd_reset_SpellScript : SpellScript
        {
            public override bool Load()
            {
                return GetCaster().IsTypeId(TypeId.Player);
            }

            public override bool Validate(SpellInfo spellInfo)
            {
                return ValidateSpellInfo(SpellIds.DivineStorm);
            }

            void HandleScript(uint effIndex)
            {
                GetCaster().GetSpellHistory().ResetCooldown(SpellIds.DivineStorm, true);
            }

            public override void Register()
            {
                OnEffectHitTarget.Add(new EffectHandler(HandleScript, 0, SpellEffectName.Dummy));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_divine_storm_cd_reset_SpellScript();
        }
    }

    [Script]
    class spell_gen_ds_flush_knockback : SpellScriptLoader
    {
        public spell_gen_ds_flush_knockback() : base("spell_gen_ds_flush_knockback") { }

        class spell_gen_ds_flush_knockback_SpellScript : SpellScript
        {
            void HandleScript(uint effIndex)
            {
                // Here the target is the water spout and determines the position where the player is knocked from
                Unit target = GetHitUnit();
                if (target)
                {
                    Player player = GetCaster().ToPlayer();
                    if (player)
                    {
                        float horizontalSpeed = 20.0f + (40.0f - GetCaster().GetDistance(target));
                        float verticalSpeed = 8.0f;
                        // This method relies on the Dalaran Sewer map disposition and Water Spout position
                        // What we do is knock the player from a position exactly behind him and at the end of the pipe
                        player.KnockbackFrom(target.GetPositionX(), player.GetPositionY(), horizontalSpeed, verticalSpeed);
                    }
                }
            }

            public override void Register()
            {
                OnEffectHitTarget.Add(new EffectHandler(HandleScript, 0, SpellEffectName.Dummy));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_ds_flush_knockback_SpellScript();
        }
    }

    [Script]
    class spell_gen_dungeon_credit : SpellScriptLoader
    {
        public spell_gen_dungeon_credit() : base("spell_gen_dungeon_credit") { }

        class spell_gen_dungeon_credit_SpellScript : SpellScript
        {
            public override bool Load()
            {
                _handled = false;
                return GetCaster().IsTypeId(TypeId.Unit);
            }

            void CreditEncounter()
            {
                // This hook is executed for every target, make sure we only credit instance once
                if (_handled)
                    return;

                _handled = true;
                Unit caster = GetCaster();
                InstanceScript instance = caster.GetInstanceScript();
                if (instance != null)
                    instance.UpdateEncounterStateForSpellCast(GetSpellInfo().Id, caster);
            }

            public override void Register()
            {
                AfterHit.Add(new HitHandler(CreditEncounter));
            }

            bool _handled;
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_dungeon_credit_SpellScript();
        }
    }

    [Script]
    class spell_gen_elune_candle : SpellScriptLoader
    {
        public spell_gen_elune_candle() : base("spell_gen_elune_candle") { }

        class spell_gen_elune_candle_SpellScript : SpellScript
        {
            public override bool Validate(SpellInfo spellInfo)
            {
                return ValidateSpellInfo(SpellIds.OmenHead, SpellIds.OmenChest, SpellIds.OmenHandR, SpellIds.OmenHandL, SpellIds.Normal);
            }

            void HandleScript(uint effIndex)
            {
                uint spellId = 0;

                if (GetHitUnit().GetEntry() == CreatureIds.Omen)
                {
                    switch (RandomHelper.URand(0, 3))
                    {
                        case 0:
                            spellId = SpellIds.OmenHead;
                            break;
                        case 1:
                            spellId = SpellIds.OmenChest;
                            break;
                        case 2:
                            spellId = SpellIds.OmenHandR;
                            break;
                        case 3:
                            spellId = SpellIds.OmenHandL;
                            break;
                    }
                }
                else
                    spellId = SpellIds.Normal;

                GetCaster().CastSpell(GetHitUnit(), spellId, true, null);
            }

            public override void Register()
            {
                OnEffectHitTarget.Add(new EffectHandler(HandleScript, 0, SpellEffectName.Dummy));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_elune_candle_SpellScript();
        }
    }

    [Script] // 131474 - Fishing
    class spell_gen_fishing : SpellScriptLoader
    {
        public spell_gen_fishing() : base("spell_gen_fishing") { }

        class spell_gen_fishing_SpellScript : SpellScript
        {
            public override bool Validate(SpellInfo spellInfo)
            {
                return ValidateSpellInfo(SpellIds.FishingNoFishingPole, SpellIds.FishingWithPole);
            }

            public override bool Load()
            {
                return GetCaster().IsTypeId(TypeId.Player);
            }

            void HandleDummy(uint effIndex)
            {
                PreventHitDefaultEffect(effIndex);
                uint spellId;
                Item mainHand = GetCaster().ToPlayer().GetItemByPos(InventorySlots.Bag0, EquipmentSlot.MainHand);
                if (!mainHand || mainHand.GetTemplate().GetClass() != ItemClass.Weapon || (ItemSubClassWeapon)mainHand.GetTemplate().GetSubClass() != ItemSubClassWeapon.FishingPole)
                    spellId = SpellIds.FishingNoFishingPole;
                else
                    spellId = SpellIds.FishingWithPole;

                GetCaster().CastSpell(GetCaster(), spellId, false);
            }

            public override void Register()
            {
                OnEffectHitTarget.Add(new EffectHandler(HandleDummy, 0, SpellEffectName.Dummy));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_fishing_SpellScript();
        }
    }

    [Script]
    class spell_gen_gadgetzan_transporter_backfire : SpellScriptLoader
    {
        public spell_gen_gadgetzan_transporter_backfire() : base("spell_gen_gadgetzan_transporter_backfire") { }

        class spell_gen_gadgetzan_transporter_backfire_SpellScript : SpellScript
        {
            public override bool Validate(SpellInfo spellInfo)
            {
                return ValidateSpellInfo(SpellIds.TransporterMalfunctionPolymorph, SpellIds.TransporterEviltwin, SpellIds.TransporterMalfunctionMiss);
            }

            void HandleDummy(uint effIndex)
            {
                Unit caster = GetCaster();
                int r = RandomHelper.IRand(0, 119);
                if (r < 20)                           // Transporter Malfunction - 1/6 polymorph
                    caster.CastSpell(caster, SpellIds.TransporterMalfunctionPolymorph, true);
                else if (r < 100)                     // Evil Twin               - 4/6 evil twin
                    caster.CastSpell(caster, SpellIds.TransporterEviltwin, true);
                else                                    // Transporter Malfunction - 1/6 miss the target
                    caster.CastSpell(caster, SpellIds.TransporterMalfunctionMiss, true);
            }

            public override void Register()
            {
                OnEffectHitTarget.Add(new EffectHandler(HandleDummy, 0, SpellEffectName.Dummy));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_gadgetzan_transporter_backfire_SpellScript();
        }
    }

    [Script]
    class spell_gen_gift_of_naaru : SpellScriptLoader
    {
        public spell_gen_gift_of_naaru() : base("spell_gen_gift_of_naaru") { }

        class spell_gen_gift_of_naaru_AuraScript : AuraScript
        {
            void CalculateAmount(AuraEffect aurEff, ref int amount, ref bool canBeRecalculated)
            {
                if (!GetCaster())
                    return;

                float heal = 0.0f;
                switch (GetSpellInfo().SpellFamilyName)
                {
                    case SpellFamilyNames.Mage:
                    case SpellFamilyNames.Warlock:
                    case SpellFamilyNames.Priest:
                        heal = 1.885f * (GetCaster().SpellBaseDamageBonusDone(GetSpellInfo().GetSchoolMask()));
                        break;
                    case SpellFamilyNames.Paladin:
                    case SpellFamilyNames.Shaman:
                        heal = Math.Max(1.885f * (GetCaster().SpellBaseDamageBonusDone(GetSpellInfo().GetSchoolMask())), 1.1f * (GetCaster().GetTotalAttackPowerValue(WeaponAttackType.BaseAttack)));
                        break;
                    case SpellFamilyNames.Warrior:
                    case SpellFamilyNames.Hunter:
                    case SpellFamilyNames.Deathknight:
                        heal = 1.1f * (Math.Max(GetCaster().GetTotalAttackPowerValue(WeaponAttackType.BaseAttack), GetCaster().GetTotalAttackPowerValue(WeaponAttackType.RangedAttack)));
                        break;
                    case SpellFamilyNames.Generic:
                    default:
                        break;
                }

                int healTick = (int)Math.Floor(heal / aurEff.GetTotalTicks());
                amount += Math.Max(healTick, 0);
            }

            public override void Register()
            {
                DoEffectCalcAmount.Add(new EffectCalcAmountHandler(CalculateAmount, 0, AuraType.PeriodicHeal));
            }
        }

        public override AuraScript GetAuraScript()
        {
            return new spell_gen_gift_of_naaru_AuraScript();
        }
    }

    [Script]
    class spell_gen_gnomish_transporter : SpellScriptLoader
    {
        public spell_gen_gnomish_transporter() : base("spell_gen_gnomish_transporter") { }

        class spell_gen_gnomish_transporter_SpellScript : SpellScript
        {
            public override bool Validate(SpellInfo spellInfo)
            {
                return ValidateSpellInfo(SpellIds.TransporterSuccess, SpellIds.TransporterFailure);
            }

            void HandleDummy(uint effIndex)
            {
                GetCaster().CastSpell(GetCaster(), RandomHelper.randChance(50) ? SpellIds.TransporterSuccess : SpellIds.TransporterFailure, true);
            }

            public override void Register()
            {
                OnEffectHitTarget.Add(new EffectHandler(HandleDummy, 0, SpellEffectName.Dummy));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_gnomish_transporter_SpellScript();
        }
    }

    [Script]
    class spell_gen_interrupt : SpellScriptLoader
    {
        public spell_gen_interrupt() : base("spell_gen_interrupt") { }

        class spell_gen_interrupt_AuraScript : AuraScript
        {
            public override bool Validate(SpellInfo spellInfo)
            {
                return ValidateSpellInfo(SpellIds.GenThrowInterrupt);
            }

            void HandleProc(AuraEffect aurEff, ProcEventInfo eventInfo)
            {
                PreventDefaultAction();
                GetTarget().CastSpell(eventInfo.GetProcTarget(), SpellIds.GenThrowInterrupt, true, null, aurEff);
            }

            public override void Register()
            {
                OnEffectProc.Add(new EffectProcHandler(HandleProc, 0, AuraType.Dummy));
            }
        }

        public override AuraScript GetAuraScript()
        {
            return new spell_gen_interrupt_AuraScript();
        }
    }

    [Script("spell_pal_blessing_of_kings")]
    [Script("spell_pal_blessing_of_might")]
    [Script("spell_dru_mark_of_the_wild")]
    [Script("spell_pri_power_word_fortitude")]
    [Script("spell_pri_shadow_protection")]
    [Script("spell_mage_arcane_brilliance")]
    [Script("spell_mage_dalaran_brilliance")]
    class spell_gen_increase_stats_buff : SpellScriptLoader
    {
        public spell_gen_increase_stats_buff(string scriptName) : base(scriptName) { }

        class spell_gen_increase_stats_buff_SpellScript : SpellScript
        {
            void HandleDummy(uint effIndex)
            {
                if (GetHitUnit().IsInRaidWith(GetCaster()))
                    GetCaster().CastSpell(GetCaster(), (uint)GetEffectValue() + 1, true); // raid buff
                else
                    GetCaster().CastSpell(GetHitUnit(), (uint)GetEffectValue(), true); // single-target buff
            }

            public override void Register()
            {
                OnEffectHitTarget.Add(new EffectHandler(HandleDummy, 0, SpellEffectName.Dummy));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_increase_stats_buff_SpellScript();
        }
    }

    [Script("spell_hexlord_lifebloom", SpellIds.HexlordMalacrass)]
    [Script("spell_tur_ragepaw_lifebloom", SpellIds.TurragePaw)]
    [Script("spell_cenarion_scout_lifebloom", SpellIds.CenarionScout)]
    [Script("spell_twisted_visage_lifebloom", SpellIds.TwistedVisage)]
    [Script("spell_faction_champion_dru_lifebloom", SpellIds.FactionChampionsDru)]
    class spell_gen_lifebloom : SpellScriptLoader
    {
        public spell_gen_lifebloom(string name, uint spellId) : base(name)
        {
            _spellId = spellId;
        }

        class spell_gen_lifebloom_AuraScript : AuraScript
        {
            public spell_gen_lifebloom_AuraScript(uint spellId)
            {
                _spellId = spellId;
            }

            public override bool Validate(SpellInfo spellInfo)
            {
                return ValidateSpellInfo(_spellId);
            }

            void AfterRemove(AuraEffect aurEff, AuraEffectHandleModes mode)
            {
                // Final heal only on duration end
                if (GetTargetApplication().GetRemoveMode() != AuraRemoveMode.Expire && GetTargetApplication().GetRemoveMode() != AuraRemoveMode.EnemySpell)
                    return;

                // final heal
                GetTarget().CastSpell(GetTarget(), _spellId, true, null, aurEff, GetCasterGUID());
            }

            public override void Register()
            {
                AfterEffectRemove.Add(new EffectApplyHandler(AfterRemove, 0, AuraType.PeriodicHeal, AuraEffectHandleModes.Real));
            }

            uint _spellId;
        }

        public override AuraScript GetAuraScript()
        {
            return new spell_gen_lifebloom_AuraScript(_spellId);
        }

        uint _spellId;
    }

    [Script]
    class spell_gen_mounted_charge : SpellScriptLoader
    {
        public spell_gen_mounted_charge() : base("spell_gen_mounted_charge") { }

        class spell_gen_mounted_charge_SpellScript : SpellScript
        {
            public override bool Validate(SpellInfo spellInfo)
            {
                return ValidateSpellInfo(62552, 62719, 64100, 66482);
            }

            void HandleScriptEffect(uint effIndex)
            {
                Unit target = GetHitUnit();

                switch (effIndex)
                {
                    case 0: // On spells wich trigger the damaging spell (and also the visual)
                        {
                            uint spellId;

                            switch (GetSpellInfo().Id)
                            {
                                case SpellIds.TriggerTrialChampion:
                                    spellId = SpellIds.ChargingEffect20k1;
                                    break;
                                case SpellIds.TriggerFactionMounts:
                                    spellId = SpellIds.ChargingEffect8k5;
                                    break;
                                default:
                                    return;
                            }

                            // If target isn't a training dummy there's a chance of failing the charge
                            if (!target.IsCharmedOwnedByPlayerOrPlayer() && RandomHelper.randChance(12.5f))
                                spellId = SpellIds.MissEffect;

                            Unit vehicle = GetCaster().GetVehicleBase();
                            if (vehicle)
                                vehicle.CastSpell(target, spellId, false);
                            else
                                GetCaster().CastSpell(target, spellId, false);
                            break;
                        }
                    case 1: // On damaging spells, for removing a defend layer
                    case 2:
                        {
                            var auras = target.GetAppliedAuras();
                            foreach (var pair in auras)
                            {
                                Aura aura = pair.Value.GetBase();
                                if (aura != null)
                                {
                                    if (aura.GetId() == 62552 || aura.GetId() == 62719 || aura.GetId() == 64100 || aura.GetId() == 66482)
                                    {
                                        aura.ModStackAmount(-1, AuraRemoveMode.EnemySpell);
                                        // Remove dummys from rider (Necessary for updating visual shields)
                                        Unit rider = target.GetCharmer();
                                        if (rider)
                                        {
                                            Aura defend = rider.GetAura(aura.GetId());
                                            if (defend != null)
                                                defend.ModStackAmount(-1, AuraRemoveMode.EnemySpell);
                                        }
                                        break;
                                    }
                                }
                            }
                            break;
                        }
                }
            }

            void HandleChargeEffect(uint effIndex)
            {
                uint spellId;

                switch (GetSpellInfo().Id)
                {
                    case SpellIds.ChargingEffect8k5:
                        spellId = SpellIds.Damage8k5;
                        break;
                    case SpellIds.ChargingEffect20k1:
                    case SpellIds.ChargingEffect20k2:
                        spellId = SpellIds.Damage20k;
                        break;
                    case SpellIds.ChargingEffect45k1:
                    case SpellIds.ChargingEffect45k2:
                        spellId = SpellIds.Damage45k;
                        break;
                    default:
                        return;
                }
                Unit rider = GetCaster().GetCharmer();
                if (rider)
                    rider.CastSpell(GetHitUnit(), spellId, false);
                else
                    GetCaster().CastSpell(GetHitUnit(), spellId, false);
            }

            public override void Register()
            {
                SpellInfo spell = Global.SpellMgr.GetSpellInfo(m_scriptSpellId);

                if (spell.HasEffect(SpellEffectName.ScriptEffect))
                    OnEffectHitTarget.Add(new EffectHandler(HandleScriptEffect, SpellConst.EffectFirstFound, SpellEffectName.ScriptEffect));

                if (spell.GetEffect(0).Effect == SpellEffectName.Charge)
                    OnEffectHitTarget.Add(new EffectHandler(HandleChargeEffect, 0, SpellEffectName.Charge));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_mounted_charge_SpellScript();
        }
    }

    [Script] // 28702 - Netherbloom
    class spell_gen_netherbloom : SpellScriptLoader
    {
        public spell_gen_netherbloom() : base("spell_gen_netherbloom") { }

        class spell_gen_netherbloom_SpellScript : SpellScript
        {
            public override bool Validate(SpellInfo spellInfo)
            {
                for (byte i = 0; i < 5; ++i)
                    if (!ValidateSpellInfo(SpellIds.NetherBloomPollen1 + i))
                        return false;

                return true;
            }

            void HandleScript(uint effIndex)
            {
                PreventHitDefaultEffect(effIndex);
                Unit target = GetHitUnit();
                if (target)
                {
                    // 25% chance of casting a random buff
                    if (RandomHelper.randChance(75))
                        return;

                    // triggered spells are 28703 to 28707
                    // Note: some sources say, that there was the possibility of
                    //       receiving a debuff. However, this seems to be removed by a patch.

                    // don't overwrite an existing aura
                    for (byte i = 0; i < 5; ++i)
                        if (target.HasAura(SpellIds.NetherBloomPollen1 + i))
                            return;

                    target.CastSpell(target, SpellIds.NetherBloomPollen1 + RandomHelper.URand(0, 4), true);
                }
            }

            public override void Register()
            {
                OnEffectHitTarget.Add(new EffectHandler(HandleScript, 0, SpellEffectName.ScriptEffect));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_netherbloom_SpellScript();
        }
    }

    [Script] // 28720 - Nightmare Vine
    class spell_gen_nightmare_vine : SpellScriptLoader
    {
        public spell_gen_nightmare_vine() : base("spell_gen_nightmare_vine") { }

        class spell_gen_nightmare_vine_SpellScript : SpellScript
        {
            public override bool Validate(SpellInfo spellInfo)
            {
                return ValidateSpellInfo(SpellIds.NightmarePollen);
            }

            void HandleScript(uint effIndex)
            {
                PreventHitDefaultEffect(effIndex);
                Unit target = GetHitUnit();
                if (target)
                {
                    // 25% chance of casting Nightmare Pollen
                    if (RandomHelper.randChance(25))
                        target.CastSpell(target, SpellIds.NightmarePollen, true);
                }
            }

            public override void Register()
            {
                OnEffectHitTarget.Add(new EffectHandler(HandleScript, 0, SpellEffectName.ScriptEffect));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_nightmare_vine_SpellScript();
        }
    }

    [Script] // 27539 - Obsidian Armor
    class spell_gen_obsidian_armor : SpellScriptLoader
    {
        public spell_gen_obsidian_armor() : base("spell_gen_obsidian_armor") { }

        class spell_gen_obsidian_armor_AuraScript : AuraScript
        {
            public override bool Validate(SpellInfo spellInfo)
            {
                return ValidateSpellInfo(SpellIds.Holy, SpellIds.Fire, SpellIds.Nature, SpellIds.Frost, SpellIds.Shadow, SpellIds.Arcane);
            }

            bool CheckProc(ProcEventInfo eventInfo)
            {
                if (eventInfo.GetDamageInfo().GetSpellInfo() != null) // eventInfo.GetSpellInfo()
                    return false;

                if (SharedConst.GetFirstSchoolInMask(eventInfo.GetSchoolMask()) == SpellSchools.Normal)
                    return false;

                return true;
            }

            void onProc(AuraEffect aurEff, ProcEventInfo eventInfo)
            {
                PreventDefaultAction();

                uint spellId = 0;
                switch (SharedConst.GetFirstSchoolInMask(eventInfo.GetSchoolMask()))
                {
                    case SpellSchools.Holy:
                        spellId = SpellIds.Holy;
                        break;
                    case SpellSchools.Fire:
                        spellId = SpellIds.Fire;
                        break;
                    case SpellSchools.Nature:
                        spellId = SpellIds.Nature;
                        break;
                    case SpellSchools.Frost:
                        spellId = SpellIds.Frost;
                        break;
                    case SpellSchools.Shadow:
                        spellId = SpellIds.Shadow;
                        break;
                    case SpellSchools.Arcane:
                        spellId = SpellIds.Arcane;
                        break;
                    default:
                        return;
                }
                GetTarget().CastSpell(GetTarget(), spellId, true, null, aurEff);
            }

            public override void Register()
            {
                DoCheckProc.Add(new CheckProcHandler(CheckProc));
                OnEffectProc.Add(new EffectProcHandler(onProc, 0, AuraType.Dummy));
            }
        }

        public override AuraScript GetAuraScript()
        {
            return new spell_gen_obsidian_armor_AuraScript();
        }
    }

    [Script]
    class spell_gen_on_tournament_mount : SpellScriptLoader
    {
        public spell_gen_on_tournament_mount() : base("spell_gen_on_tournament_mount") { }

        class spell_gen_on_tournament_mount_AuraScript : AuraScript
        {
            uint _pennantSpellId;

            public override bool Load()
            {
                _pennantSpellId = 0;
                return GetCaster() && GetCaster().IsTypeId(TypeId.Player);
            }

            void HandleApplyEffect(AuraEffect aurEff, AuraEffectHandleModes mode)
            {
                Unit caster = GetCaster();
                if (caster)
                {
                    Unit vehicle = caster.GetVehicleBase();
                    if (vehicle)
                    {
                        _pennantSpellId = GetPennatSpellId(caster.ToPlayer(), vehicle);
                        caster.CastSpell(caster, _pennantSpellId, true);
                    }
                }
            }

            void HandleRemoveEffect(AuraEffect aurEff, AuraEffectHandleModes mode)
            {
                Unit caster = GetCaster();
                if (caster)
                    caster.RemoveAurasDueToSpell(_pennantSpellId);
            }

            uint GetPennatSpellId(Player player, Unit mount)
            {
                switch (mount.GetEntry())
                {
                    case CreatureIds.ArgentSteedAspirant:
                    case CreatureIds.StormwindSteed:
                        {
                            if (player.HasAchieved(AchievementIds.ChampionStormwind))
                                return SpellIds.StormwindChampion;
                            else if (player.GetQuestRewardStatus(QuestIds.ValiantOfStormwind) || player.GetQuestRewardStatus(QuestIds.A_ValiantOfStormwind))
                                return SpellIds.StormwindValiant;
                            else
                                return SpellIds.StormwindAspirant;
                        }
                    case CreatureIds.GnomereganMechanostrider:
                        {
                            if (player.HasAchieved(AchievementIds.ChampionGnomeregan))
                                return SpellIds.GnomereganChampion;
                            else if (player.GetQuestRewardStatus(QuestIds.ValiantOfGnomeregan) || player.GetQuestRewardStatus(QuestIds.A_ValiantOfGnomeregan))
                                return SpellIds.GnomereganValiant;
                            else
                                return SpellIds.GnomereganAspirant;
                        }
                    case CreatureIds.DarkSpearRaptor:
                        {
                            if (player.HasAchieved(AchievementIds.ChampionSenJin))
                                return SpellIds.SenjinChampion;
                            else if (player.GetQuestRewardStatus(QuestIds.ValiantOfSenJin) || player.GetQuestRewardStatus(QuestIds.A_ValiantOfSenJin))
                                return SpellIds.SenjinValiant;
                            else
                                return SpellIds.SenjinAspirant;
                        }
                    case CreatureIds.ArgentHawkstriderAspirant:
                    case CreatureIds.SilvermoonHawkstrider:
                        {
                            if (player.HasAchieved(AchievementIds.ChampionSilvermoon))
                                return SpellIds.SilvermoonChampion;
                            else if (player.GetQuestRewardStatus(QuestIds.ValiantOfSilvermoon) || player.GetQuestRewardStatus(QuestIds.A_ValiantOfSilvermoon))
                                return SpellIds.SilvermoonValiant;
                            else
                                return SpellIds.SilvermoonAspirant;
                        }
                    case CreatureIds.DarnassianNightsaber:
                        {
                            if (player.HasAchieved(AchievementIds.ChampionDarnassus))
                                return SpellIds.DarnassusChampion;
                            else if (player.GetQuestRewardStatus(QuestIds.ValiantOfDarnassus) || player.GetQuestRewardStatus(QuestIds.A_ValiantOfDarnassus))
                                return SpellIds.DarnassusValiant;
                            else
                                return SpellIds.DarnassusAspirant;
                        }
                    case CreatureIds.ExodarElekk:
                        {
                            if (player.HasAchieved(AchievementIds.ChampionTheExodar))
                                return SpellIds.ExodarChampion;
                            else if (player.GetQuestRewardStatus(QuestIds.ValiantOfTheExodar) || player.GetQuestRewardStatus(QuestIds.A_ValiantOfTheExodar))
                                return SpellIds.ExodarValiant;
                            else
                                return SpellIds.ExodarAspirant;
                        }
                    case CreatureIds.IronforgeRam:
                        {
                            if (player.HasAchieved(AchievementIds.ChampionIronforge))
                                return SpellIds.IronforgeChampion;
                            else if (player.GetQuestRewardStatus(QuestIds.ValiantOfIronforge) || player.GetQuestRewardStatus(QuestIds.A_ValiantOfIronforge))
                                return SpellIds.IronforgeValiant;
                            else
                                return SpellIds.IronforgeAspirant;
                        }
                    case CreatureIds.ForsakenWarhorse:
                        {
                            if (player.HasAchieved(AchievementIds.ChampionUndercity))
                                return SpellIds.UndercityChampion;
                            else if (player.GetQuestRewardStatus(QuestIds.ValiantOfUndercity) || player.GetQuestRewardStatus(QuestIds.A_ValiantOfUndercity))
                                return SpellIds.UndercityValiant;
                            else
                                return SpellIds.UndercityAspirant;
                        }
                    case CreatureIds.OrgrimmarWolf:
                        {
                            if (player.HasAchieved(AchievementIds.ChampionOrgrimmar))
                                return SpellIds.OrgrimmarChampion;
                            else if (player.GetQuestRewardStatus(QuestIds.ValiantOfOrgrimmar) || player.GetQuestRewardStatus(QuestIds.A_ValiantOfOrgrimmar))
                                return SpellIds.OrgrimmarValiant;
                            else
                                return SpellIds.OrgrimmarAspirant;
                        }
                    case CreatureIds.ThunderBluffKodo:
                        {
                            if (player.HasAchieved(AchievementIds.ChampionThunderBluff))
                                return SpellIds.ThunderbluffChampion;
                            else if (player.GetQuestRewardStatus(QuestIds.ValiantOfThunderBluff) || player.GetQuestRewardStatus(QuestIds.A_ValiantOfThunderBluff))
                                return SpellIds.ThunderbluffValiant;
                            else
                                return SpellIds.ThunderbluffAspirant;
                        }
                    case CreatureIds.ArgentWarhorse:
                        {
                            if (player.HasAchieved(AchievementIds.ChampionAlliance) || player.HasAchieved(AchievementIds.ChampionHorde))
                                return player.GetClass() == Class.Deathknight ? SpellIds.EbonbladeChampion : SpellIds.ArgentcrusadeChampion;
                            else if (player.HasAchieved(AchievementIds.ArgentValor))
                                return player.GetClass() == Class.Deathknight ? SpellIds.EbonbladeValiant : SpellIds.ArgentcrusadeValiant;
                            else
                                return player.GetClass() == Class.Deathknight ? SpellIds.EbonbladeAspirant : SpellIds.ArgentcrusadeAspirant;
                        }
                    default:
                        return 0;
                }
            }

            public override void Register()
            {
                AfterEffectApply.Add(new EffectApplyHandler(HandleApplyEffect, 0, AuraType.Dummy, AuraEffectHandleModes.RealOrReapplyMask));
                OnEffectRemove.Add(new EffectApplyHandler(HandleRemoveEffect, 0, AuraType.Dummy, AuraEffectHandleModes.RealOrReapplyMask));
            }
        }

        public override AuraScript GetAuraScript()
        {
            return new spell_gen_on_tournament_mount_AuraScript();
        }
    }

    [Script]
    class spell_gen_oracle_wolvar_reputation : SpellScriptLoader
    {
        public spell_gen_oracle_wolvar_reputation() : base("spell_gen_oracle_wolvar_reputation") { }

        class spell_gen_oracle_wolvar_reputation_SpellScript : SpellScript
        {
            public override bool Load()
            {
                return GetCaster().IsTypeId(TypeId.Player);
            }

            void HandleDummy(uint effIndex)
            {
                Player player = GetCaster().ToPlayer();
                uint factionId = (uint)GetSpellInfo().GetEffect(effIndex).CalcValue();
                int repChange = GetSpellInfo().GetEffect(1).CalcValue();

                FactionRecord factionEntry = CliDB.FactionStorage.LookupByKey(factionId);

                if (factionEntry == null)
                    return;

                // Set rep to baserep + basepoints (expecting spillover for oposite faction . become hated)
                // Not when player already has equal or higher rep with this faction
                if (player.GetReputationMgr().GetBaseReputation(factionEntry) < repChange)
                    player.GetReputationMgr().SetReputation(factionEntry, repChange);

                // EFFECT_INDEX_2 most likely update at war state, we already handle this in SetReputation
            }

            public override void Register()
            {
                OnEffectHit.Add(new EffectHandler(HandleDummy, 0, SpellEffectName.Dummy));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_oracle_wolvar_reputation_SpellScript();
        }
    }

    [Script]
    class spell_gen_orc_disguise : SpellScriptLoader
    {
        public spell_gen_orc_disguise() : base("spell_gen_orc_disguise") { }

        class spell_gen_orc_disguise_SpellScript : SpellScript
        {
            public override bool Validate(SpellInfo spellInfo)
            {
                return ValidateSpellInfo(SpellIds.OrcDisguiseTrigger, SpellIds.OrcDisguiseMale, SpellIds.OrcDisguiseFemale);
            }

            void HandleScript(uint effIndex)
            {
                Unit caster = GetCaster();
                Player target = GetHitPlayer();
                if (target)
                {
                    Gender gender = target.GetGender();
                    if (gender == Gender.Male)
                        caster.CastSpell(target, SpellIds.OrcDisguiseMale, true);
                    else
                        caster.CastSpell(target, SpellIds.OrcDisguiseFemale, true);
                }
            }

            public override void Register()
            {
                OnEffectHitTarget.Add(new EffectHandler(HandleScript, 0, SpellEffectName.ScriptEffect));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_orc_disguise_SpellScript();
        }
    }

    [Script("spell_item_soul_harvesters_charm")]
    [Script("spell_item_commendation_of_kaelthas")]
    [Script("spell_item_corpse_tongue_coin")]
    [Script("spell_item_corpse_tongue_coin_heroic")]
    [Script("spell_item_petrified_twilight_scale")]
    [Script("spell_item_petrified_twilight_scale_heroic")]
    class spell_gen_proc_below_pct_damaged : SpellScriptLoader
    {
        public spell_gen_proc_below_pct_damaged(string name) : base(name) { }

        class spell_gen_proc_below_pct_damaged_AuraScript : AuraScript
        {
            bool CheckProc(ProcEventInfo eventInfo)
            {
                DamageInfo damageInfo = eventInfo.GetDamageInfo();
                if (damageInfo == null || damageInfo.GetDamage() == 0)
                    return false;

                int pct = GetSpellInfo().GetEffect(0).CalcValue();

                if (eventInfo.GetActionTarget().HealthBelowPctDamaged(pct, damageInfo.GetDamage()))
                    return true;

                return false;
            }

            public override void Register()
            {
                DoCheckProc.Add(new CheckProcHandler(CheckProc));
            }
        }

        public override AuraScript GetAuraScript()
        {
            return new spell_gen_proc_below_pct_damaged_AuraScript();
        }
    }

    [Script] // 45472 Parachute
    class spell_gen_parachute : SpellScriptLoader
    {
        public spell_gen_parachute() : base("spell_gen_parachute") { }

        class spell_gen_parachute_AuraScript : AuraScript
        {
            public override bool Validate(SpellInfo spellInfo)
            {
                return ValidateSpellInfo(SpellIds.Parachute, SpellIds.ParachuteBuff);
            }

            void HandleEffectPeriodic(AuraEffect aurEff)
            {
                Player target = GetTarget().ToPlayer();
                if (target)
                {
                    if (target.IsFalling())
                    {
                        target.RemoveAurasDueToSpell(SpellIds.Parachute);
                        target.CastSpell(target, SpellIds.ParachuteBuff, true);
                    }
                }
            }

            public override void Register()
            {
                OnEffectPeriodic.Add(new EffectPeriodicHandler(HandleEffectPeriodic, 0, AuraType.PeriodicDummy));
            }
        }

        public override AuraScript GetAuraScript()
        {
            return new spell_gen_parachute_AuraScript();
        }
    }

    [Script]
    class spell_gen_pet_summoned : SpellScriptLoader
    {
        public spell_gen_pet_summoned() : base("spell_gen_pet_summoned") { }

        class spell_gen_pet_summoned_SpellScript : SpellScript
        {
            public override bool Load()
            {
                return GetCaster().IsTypeId(TypeId.Player);
            }

            void HandleScript(uint effIndex)
            {
                Player player = GetCaster().ToPlayer();
                if (player.GetLastPetNumber() != 0)
                {
                    PetType newPetType = (player.GetClass() == Class.Hunter) ? PetType.Hunter : PetType.Summon;
                    Pet newPet = new Pet(player, newPetType);
                    if (newPet.LoadPetFromDB(player, 0, player.GetLastPetNumber(), true))
                    {
                        // revive the pet if it is dead
                        if (newPet.getDeathState() == DeathState.Dead)
                            newPet.setDeathState(DeathState.Alive);

                        newPet.SetFullHealth();
                        newPet.SetPower(newPet.getPowerType(), newPet.GetMaxPower(newPet.getPowerType()));

                        switch (newPet.GetEntry())
                        {
                            case CreatureIds.Doomguard:
                            case CreatureIds.Infernal:
                                newPet.SetEntry(CreatureIds.Imp);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            public override void Register()
            {
                OnEffectHitTarget.Add(new EffectHandler(HandleScript, 0, SpellEffectName.ScriptEffect));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_pet_summoned_SpellScript();
        }
    }

    [Script]
    class spell_gen_profession_research : SpellScriptLoader
    {
        public spell_gen_profession_research() : base("spell_gen_profession_research") { }

        class spell_gen_profession_research_SpellScript : SpellScript
        {
            public override bool Load()
            {
                return GetCaster().IsTypeId(TypeId.Player);
            }

            SpellCastResult CheckRequirement()
            {
                if (SkillDiscovery.HasDiscoveredAllSpells(GetSpellInfo().Id, GetCaster().ToPlayer()))
                {
                    SetCustomCastResultMessage(SpellCustomErrors.NothingToDiscover);
                    return SpellCastResult.CustomError;
                }

                return SpellCastResult.SpellCastOk;
            }

            void HandleScript(uint effIndex)
            {
                Player caster = GetCaster().ToPlayer();
                uint spellId = GetSpellInfo().Id;

                // learn random explicit discovery recipe (if any)
                uint discoveredSpellId = SkillDiscovery.GetExplicitDiscoverySpell(spellId, caster);
                if (discoveredSpellId != 0)
                    caster.LearnSpell(discoveredSpellId, false);

                caster.UpdateCraftSkill(spellId);
            }

            public override void Register()
            {
                OnCheckCast.Add(new CheckCastHandler(CheckRequirement));
                OnEffectHitTarget.Add(new EffectHandler(HandleScript, 1, SpellEffectName.ScriptEffect));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_profession_research_SpellScript();
        }
    }

    [Script]
    class spell_gen_pvp_trinket : SpellScriptLoader
    {
        public spell_gen_pvp_trinket() : base("spell_gen_pvp_trinket") { }

        class spell_gen_pvp_trinket_SpellScript : SpellScript
        {
            void TriggerAnimation()
            {
                Player caster = GetCaster().ToPlayer();

                switch (caster.GetTeam())
                {
                    case Team.Alliance:
                        caster.CastSpell(caster, SpellIds.PvpTrinketAlliance, TriggerCastFlags.FullMask);
                        break;
                    case Team.Horde:
                        caster.CastSpell(caster, SpellIds.PvpTrinketHorde, TriggerCastFlags.FullMask);
                        break;
                }
            }

            public override void Register()
            {
                AfterCast.Add(new CastHandler(TriggerAnimation));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_pvp_trinket_SpellScript();
        }
    }

    [Script]
    class spell_gen_remove_flight_auras : SpellScriptLoader
    {
        public spell_gen_remove_flight_auras() : base("spell_gen_remove_flight_auras") { }

        class spell_gen_remove_flight_auras_SpellScript : SpellScript
        {
            void HandleScript(uint effIndex)
            {
                Unit target = GetHitUnit();
                if (target)
                {
                    target.RemoveAurasByType(AuraType.Fly);
                    target.RemoveAurasByType(AuraType.ModIncreaseMountedFlightSpeed);
                }
            }

            public override void Register()
            {
                OnEffectHitTarget.Add(new EffectHandler(HandleScript, 1, SpellEffectName.ScriptEffect));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_remove_flight_auras_SpellScript();
        }
    }

    [Script]
    class spell_gen_replenishment : SpellScriptLoader
    {
        public spell_gen_replenishment() : base("spell_gen_replenishment") { }

        class spell_gen_replenishment_SpellScript : SpellScript
        {
            void RemoveInvalidTargets(List<WorldObject> targets)
            {
                // In arenas Replenishment may only affect the caster
                Player caster = GetCaster().ToPlayer();
                if (caster)
                {
                    if (caster.InArena())
                    {
                        targets.Clear();
                        targets.Add(caster);
                        return;
                    }
                }

                targets.RemoveAll(obj =>
                {
                    var target = obj.ToUnit();
                    if (target)
                        return target.getPowerType() != PowerType.Mana;

                    return true;
                });

                byte maxTargets = 10;

                if (targets.Count > maxTargets)
                {
                    targets.Sort(new PowerPctOrderPred(PowerType.Mana));
                    targets.Resize(maxTargets);
                }
            }

            public override void Register()
            {
                OnObjectAreaTargetSelect.Add(new ObjectAreaTargetSelectHandler(RemoveInvalidTargets, 255, Targets.UnitCasterAreaRaid));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_replenishment_SpellScript();
        }

        class spell_gen_replenishment_AuraScript : AuraScript
        {
            public override bool Load()
            {
                return GetUnitOwner().GetPower(PowerType.Mana) != 0;
            }

            void CalculateAmount(AuraEffect aurEff, ref int amount, ref bool canBeRecalculated)
            {
                switch (GetSpellInfo().Id)
                {
                    case SpellIds.Replenishment:
                        amount = (int)(GetUnitOwner().GetMaxPower(PowerType.Mana) * 0.002f);
                        break;
                    case SpellIds.InfiniteReplenishment:
                        amount = (int)(GetUnitOwner().GetMaxPower(PowerType.Mana) * 0.0025f);
                        break;
                    default:
                        break;
                }
            }

            public override void Register()
            {
                DoEffectCalcAmount.Add(new EffectCalcAmountHandler(CalculateAmount, 0, AuraType.PeriodicEnergize));
            }
        }

        public override AuraScript GetAuraScript()
        {
            return new spell_gen_replenishment_AuraScript();
        }
    }

    [Script]
    class spell_gen_running_wild : SpellScriptLoader
    {
        public spell_gen_running_wild() : base("spell_gen_running_wild") { }

        class spell_gen_running_wild_AuraScript : AuraScript
        {
            public override bool Validate(SpellInfo spellInfo)
            {
                if (!CliDB.CreatureDisplayInfoStorage.ContainsKey(ModelIds.RunningWild))
                    return false;
                return true;
            }

            void HandleMount(AuraEffect aurEff, AuraEffectHandleModes mode)
            {
                Unit target = GetTarget();
                PreventDefaultAction();

                target.Mount(ModelIds.RunningWild, 0, 0);

                // cast speed aura
                MountCapabilityRecord mountCapability = CliDB.MountCapabilityStorage.LookupByKey(aurEff.GetAmount());
                if (mountCapability != null)
                    target.CastSpell(target, mountCapability.SpeedModSpell, TriggerCastFlags.FullMask);
            }

            public override void Register()
            {
                OnEffectApply.Add(new EffectApplyHandler(HandleMount, 1, AuraType.Mounted, AuraEffectHandleModes.Real));
            }
        }

        class spell_gen_running_wild_SpellScript : SpellScript
        {
            public override bool Validate(SpellInfo spellInfo)
            {
                return ValidateSpellInfo(SpellIds.AlteredForm);
            }

            public override bool Load()
            {
                // Definitely not a good thing, but currently the only way to do something at cast start
                // Should be replaced as soon as possible with a new hook: BeforeCastStart
                GetCaster().CastSpell(GetCaster(), SpellIds.AlteredForm, TriggerCastFlags.FullMask);
                return false;
            }

            public override void Register()
            {
            }
        }

        public override AuraScript GetAuraScript()
        {
            return new spell_gen_running_wild_AuraScript();
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_running_wild_SpellScript();
        }
    }

    [Script]
    class spell_gen_two_forms : SpellScriptLoader
    {
        public spell_gen_two_forms() : base("spell_gen_two_forms") { }

        class spell_gen_two_forms_SpellScript : SpellScript
        {
            SpellCastResult CheckCast()
            {
                if (GetCaster().IsInCombat())
                {
                    SetCustomCastResultMessage(SpellCustomErrors.CantTransform);
                    return SpellCastResult.CustomError;
                }

                // Player cannot transform to human form if he is forced to be worgen for some reason (Darkflight)
                if (GetCaster().GetAuraEffectsByType(AuraType.WorgenAlteredForm).Count > 1)
                {
                    SetCustomCastResultMessage(SpellCustomErrors.CantTransform);
                    return SpellCastResult.CustomError;
                }

                return SpellCastResult.SpellCastOk;
            }

            void HandleTransform(uint effIndex)
            {
                Unit target = GetHitUnit();
                PreventHitDefaultEffect(effIndex);
                if (target.HasAuraType(AuraType.WorgenAlteredForm))
                    target.RemoveAurasByType(AuraType.WorgenAlteredForm);
                else    // Basepoints 1 for this aura control whether to trigger transform transition animation or not.
                    target.CastCustomSpell(SpellIds.AlteredForm, SpellValueMod.BasePoint0, 1, target, TriggerCastFlags.FullMask);
            }

            public override void Register()
            {
                OnCheckCast.Add(new CheckCastHandler(CheckCast));
                OnEffectHitTarget.Add(new EffectHandler(HandleTransform, 0, SpellEffectName.Dummy));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_two_forms_SpellScript();
        }
    }

    [Script]
    class spell_gen_darkflight : SpellScriptLoader
    {
        public spell_gen_darkflight() : base("spell_gen_darkflight") { }

        class spell_gen_darkflight_SpellScript : SpellScript
        {
            void TriggerTransform()
            {
                GetCaster().CastSpell(GetCaster(), SpellIds.AlteredForm, TriggerCastFlags.FullMask);
            }

            public override void Register()
            {
                AfterCast.Add(new CastHandler(TriggerTransform));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_darkflight_SpellScript();
        }
    }

    [Script]
    class spell_gen_seaforium_blast : SpellScriptLoader
    {
        public spell_gen_seaforium_blast() : base("spell_gen_seaforium_blast") { }

        class spell_gen_seaforium_blast_SpellScript : SpellScript
        {
            public override bool Validate(SpellInfo spellInfo)
            {
                return ValidateSpellInfo(SpellIds.PlantChargesCreditAchievement);
            }

            public override bool Load()
            {
                // OriginalCaster is always available in Spell.prepare
                return GetOriginalCaster().IsTypeId(TypeId.Player);
            }

            void AchievementCredit(uint effIndex)
            {
                // but in effect handling OriginalCaster can become null
                Unit originalCaster = GetOriginalCaster();
                if (originalCaster)
                {
                    GameObject go = GetHitGObj();
                    if (go)
                        if (go.GetGoInfo().type == GameObjectTypes.DestructibleBuilding)
                            originalCaster.CastSpell(originalCaster, SpellIds.PlantChargesCreditAchievement, true);
                }
            }

            public override void Register()
            {
                OnEffectHitTarget.Add(new EffectHandler(AchievementCredit, 1, SpellEffectName.GameObjectDamage));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_seaforium_blast_SpellScript();
        }
    }

    [Script]
    class spell_gen_spectator_cheer_trigger : SpellScriptLoader
    {
        public spell_gen_spectator_cheer_trigger() : base("spell_gen_spectator_cheer_trigger") { }

        class spell_gen_spectator_cheer_trigger_SpellScript : SpellScript
        {
            void HandleDummy(uint effIndex)
            {
                GetCaster().HandleEmoteCommand(EmoteArray[RandomHelper.URand(0, 2)]);
            }

            public override void Register()
            {
                OnEffectHitTarget.Add(new EffectHandler(HandleDummy, 0, SpellEffectName.Dummy));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_spectator_cheer_trigger_SpellScript();
        }

        static Emote[] EmoteArray = { Emote.OneshotCheer, Emote.OneshotExclamation, Emote.OneshotApplaud };
    }

    [Script]
    class spell_gen_spirit_healer_res : SpellScriptLoader
    {
        public spell_gen_spirit_healer_res() : base("spell_gen_spirit_healer_res") { }

        class spell_gen_spirit_healer_res_SpellScript : SpellScript
        {
            public override bool Load()
            {
                return GetOriginalCaster() && GetOriginalCaster().IsTypeId(TypeId.Player);
            }

            void HandleDummy(uint effIndex)
            {
                Player originalCaster = GetOriginalCaster().ToPlayer();
                Unit target = GetHitUnit();
                if (target)
                {
                    SpiritHealerConfirm spiritHealerConfirm = new SpiritHealerConfirm();
                    spiritHealerConfirm.Unit = target.GetGUID();
                    originalCaster.SendPacket(spiritHealerConfirm);
                }
            }

            public override void Register()
            {
                OnEffectHitTarget.Add(new EffectHandler(HandleDummy, 0, SpellEffectName.Dummy));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_spirit_healer_res_SpellScript();
        }
    }

    [Script("spell_gen_summon_fire_elemental", SpellIds.SummonFireElemental)]
    [Script("spell_gen_summon_earth_elemental", SpellIds.SummonEarthElemental)]
    class spell_gen_summon_elemental : SpellScriptLoader
    {
        public spell_gen_summon_elemental(string name, uint spellId) : base(name)
        {
            _spellId = spellId;
        }

        class spell_gen_summon_elemental_AuraScript : AuraScript
        {
            public spell_gen_summon_elemental_AuraScript(uint spellId)
            {
                _spellId = spellId;
            }

            public override bool Validate(SpellInfo spellInfo)
            {
                return ValidateSpellInfo(_spellId);
            }

            void AfterApply(AuraEffect aurEff, AuraEffectHandleModes mode)
            {
                if (GetCaster())
                {
                    Unit owner = GetCaster().GetOwner();
                    if (owner)
                        owner.CastSpell(owner, _spellId, true);
                }
            }

            void AfterRemove(AuraEffect aurEff, AuraEffectHandleModes mode)
            {
                if (GetCaster())
                {
                    Unit owner = GetCaster().GetOwner();
                    if (owner)
                        if (owner.IsTypeId(TypeId.Player)) /// @todo this check is maybe wrong
                            owner.ToPlayer().RemovePet(null, PetSaveMode.NotInSlot, true);
                }
            }

            public override void Register()
            {
                AfterEffectApply.Add(new EffectApplyHandler(AfterApply, 1, AuraType.Dummy, AuraEffectHandleModes.Real));
                AfterEffectRemove.Add(new EffectApplyHandler(AfterRemove, 1, AuraType.Dummy, AuraEffectHandleModes.Real));
            }

            uint _spellId;
        }

        public override AuraScript GetAuraScript()
        {
            return new spell_gen_summon_elemental_AuraScript(_spellId);
        }

        uint _spellId;
    }

    [Script]
    class spell_gen_summon_tournament_mount : SpellScriptLoader
    {
        public spell_gen_summon_tournament_mount() : base("spell_gen_summon_tournament_mount") { }

        class spell_gen_summon_tournament_mount_SpellScript : SpellScript
        {
            public override bool Validate(SpellInfo spellInfo)
            {
                return ValidateSpellInfo(SpellIds.LanceEquipped);
            }

            SpellCastResult CheckIfLanceEquiped()
            {
                if (GetCaster().IsInDisallowedMountForm())
                    GetCaster().RemoveAurasByType(AuraType.ModShapeshift);

                if (!GetCaster().HasAura(SpellIds.LanceEquipped))
                {
                    SetCustomCastResultMessage(SpellCustomErrors.MustHaveLanceEquipped);
                    return SpellCastResult.CustomError;
                }

                return SpellCastResult.SpellCastOk;
            }

            public override void Register()
            {
                OnCheckCast.Add(new CheckCastHandler(CheckIfLanceEquiped));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_summon_tournament_mount_SpellScript();
        }
    }

    [Script] // 41213, 43416, 69222, 73076 - Throw Shield
    class spell_gen_throw_shield : SpellScriptLoader
    {
        public spell_gen_throw_shield() : base("spell_gen_throw_shield") { }

        class spell_gen_throw_shield_SpellScript : SpellScript
        {
            void HandleScriptEffect(uint effIndex)
            {
                PreventHitDefaultEffect(effIndex);
                GetCaster().CastSpell(GetHitUnit(), (uint)GetEffectValue(), true);
            }

            public override void Register()
            {
                OnEffectHitTarget.Add(new EffectHandler(HandleScriptEffect, 1, SpellEffectName.ScriptEffect));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_throw_shield_SpellScript();
        }
    }

    [Script]
    class spell_gen_tournament_duel : SpellScriptLoader
    {
        public spell_gen_tournament_duel() : base("spell_gen_tournament_duel") { }

        class spell_gen_tournament_duel_SpellScript : SpellScript
        {
            public override bool Validate(SpellInfo spellInfo)
            {
                return ValidateSpellInfo(SpellIds.OnTournamentMount, SpellIds.MountedDuel);
            }

            void HandleScriptEffect(uint effIndex)
            {
                Unit rider = GetCaster().GetCharmer();
                if (rider)
                {
                    Player playerTarget = GetHitPlayer();
                    if (playerTarget)
                    {
                        if (playerTarget.HasAura(SpellIds.OnTournamentMount) && playerTarget.GetVehicleBase())
                            rider.CastSpell(playerTarget, SpellIds.MountedDuel, true);
                        return;
                    }

                    Unit unitTarget = GetHitUnit();
                    if (unitTarget)
                    {
                        if (unitTarget.GetCharmer() && unitTarget.GetCharmer().IsTypeId(TypeId.Player) && unitTarget.GetCharmer().HasAura(SpellIds.OnTournamentMount))
                            rider.CastSpell(unitTarget.GetCharmer(), SpellIds.MountedDuel, true);
                    }
                }
            }

            public override void Register()
            {
                OnEffectHitTarget.Add(new EffectHandler(HandleScriptEffect, 0, SpellEffectName.ScriptEffect));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_tournament_duel_SpellScript();
        }
    }

    [Script]
    class spell_gen_tournament_pennant : SpellScriptLoader
    {
        public spell_gen_tournament_pennant() : base("spell_gen_tournament_pennant") { }

        class spell_gen_tournament_pennant_AuraScript : AuraScript
        {
            public override bool Load()
            {
                return GetCaster() && GetCaster().IsTypeId(TypeId.Player);
            }

            void HandleApplyEffect(AuraEffect aurEff, AuraEffectHandleModes mode)
            {
                Unit caster = GetCaster();
                if (caster)
                    if (!caster.GetVehicleBase())
                        caster.RemoveAurasDueToSpell(GetId());
            }

            public override void Register()
            {
                OnEffectApply.Add(new EffectApplyHandler(HandleApplyEffect, 0, AuraType.Dummy, AuraEffectHandleModes.RealOrReapplyMask));
            }
        }

        public override AuraScript GetAuraScript()
        {
            return new spell_gen_tournament_pennant_AuraScript();
        }
    }

    [Script]
    class spell_pvp_trinket_wotf_shared_cd : SpellScriptLoader
    {
        public spell_pvp_trinket_wotf_shared_cd() : base("spell_pvp_trinket_wotf_shared_cd") { }

        class spell_pvp_trinket_wotf_shared_cd_SpellScript : SpellScript
        {
            public override bool Load()
            {
                return GetCaster().IsTypeId(TypeId.Player);
            }

            public override bool Validate(SpellInfo spellInfo)
            {
                return ValidateSpellInfo(SpellIds.WillOfTheForsakenCooldownTrigger, SpellIds.WillOfTheForsakenCooldownTriggerWotf);
            }

            void HandleScript()
            {
                // This is only needed because spells cast from spell_linked_spell are triggered by default
                // Spell.SendSpellCooldown() skips all spells with TRIGGERED_IGNORE_SPELL_AND_CATEGORY_CD
                GetCaster().GetSpellHistory().StartCooldown(GetSpellInfo(), 0, GetSpell());
            }

            public override void Register()
            {
                AfterCast.Add(new CastHandler(HandleScript));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_pvp_trinket_wotf_shared_cd_SpellScript();
        }
    }

    [Script]
    class spell_gen_turkey_marker : SpellScriptLoader
    {
        public spell_gen_turkey_marker() : base("spell_gen_turkey_marker") { }

        class spell_gen_turkey_marker_AuraScript : AuraScript
        {
            void OnApply(AuraEffect aurEff, AuraEffectHandleModes mode)
            {
                // store stack apply times, so we can pop them while they expire
                _applyTimes.Add(Time.GetMSTime());
                Unit target = GetTarget();

                // on stack 15 cast the achievement crediting spell
                if (GetStackAmount() >= 15)
                    target.CastSpell(target, SpellIds.TurkeyVengeance, true, null, aurEff, GetCasterGUID());
            }

            void OnPeriodic(AuraEffect aurEff)
            {
                if (_applyTimes.Empty())
                    return;

                // pop stack if it expired for us
                if (_applyTimes.First() + GetMaxDuration() < Time.GetMSTime())
                    ModStackAmount(-1, AuraRemoveMode.Expire);
            }

            public override void Register()
            {
                AfterEffectApply.Add(new EffectApplyHandler(OnApply, 0, AuraType.PeriodicDummy, AuraEffectHandleModes.RealOrReapplyMask));
                OnEffectPeriodic.Add(new EffectPeriodicHandler(OnPeriodic, 0, AuraType.PeriodicDummy));
            }

            List<uint> _applyTimes = new List<uint>();
        }

        public override AuraScript GetAuraScript()
        {
            return new spell_gen_turkey_marker_AuraScript();
        }
    }

    [Script]
    class spell_gen_upper_deck_create_foam_sword : SpellScriptLoader
    {
        public spell_gen_upper_deck_create_foam_sword() : base("spell_gen_upper_deck_create_foam_sword") { }

        class spell_gen_upper_deck_create_foam_sword_SpellScript : SpellScript
        {
            void HandleScript(uint effIndex)
            {
                Player player = GetHitPlayer();
                if (player)
                {
                    // player can only have one of these items
                    for (byte i = 0; i < 5; ++i)
                    {
                        if (player.HasItemCount(itemId[i], 1, true))
                            return;
                    }

                    CreateItem(effIndex, itemId[RandomHelper.URand(0, 4)]);
                }
            }

            public override void Register()
            {
                OnEffectHitTarget.Add(new EffectHandler(HandleScript, 0, SpellEffectName.ScriptEffect));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_upper_deck_create_foam_sword_SpellScript();
        }

        //                       green  pink   blue   red    yellow
        static uint[] itemId = { 45061, 45176, 45177, 45178, 45179 };
    }

    // 52723 - Vampiric Touch
    [Script] // 60501 - Vampiric Touch
    class spell_gen_vampiric_touch : SpellScriptLoader
    {
        public spell_gen_vampiric_touch() : base("spell_gen_vampiric_touch") { }

        class spell_gen_vampiric_touch_AuraScript : AuraScript
        {
            public override bool Validate(SpellInfo spellInfo)
            {
                return ValidateSpellInfo(SpellIds.VampiricTouchHeal);
            }

            void HandleProc(AuraEffect aurEff, ProcEventInfo eventInfo)
            {
                PreventDefaultAction();
                DamageInfo damageInfo = eventInfo.GetDamageInfo();
                if (damageInfo == null || damageInfo.GetDamage() == 0)
                    return;

                Unit caster = eventInfo.GetActor();
                int bp = (int)(damageInfo.GetDamage() / 2);
                caster.CastCustomSpell(SpellIds.VampiricTouchHeal, SpellValueMod.BasePoint0, bp, caster, true);
            }

            public override void Register()
            {
                OnEffectProc.Add(new EffectProcHandler(HandleProc, 0, AuraType.Dummy));
            }
        }

        public override AuraScript GetAuraScript()
        {
            return new spell_gen_vampiric_touch_AuraScript();
        }
    }

    [Script]
    class spell_gen_vehicle_scaling : SpellScriptLoader
    {
        public spell_gen_vehicle_scaling() : base("spell_gen_vehicle_scaling") { }

        class spell_gen_vehicle_scaling_AuraScript : AuraScript
        {
            public override bool Load()
            {
                return GetCaster() && GetCaster().IsTypeId(TypeId.Player);
            }

            void CalculateAmount(AuraEffect aurEff, ref int amount, ref bool canBeRecalculated)
            {
                Unit caster = GetCaster();
                float factor;
                ushort baseItemLevel;

                /// @todo Reserach coeffs for different vehicles
                switch (GetId())
                {
                    case SpellIds.GearScaling:
                        factor = 1.0f;
                        baseItemLevel = 205;
                        break;
                    default:
                        factor = 1.0f;
                        baseItemLevel = 170;
                        break;
                }

                float avgILvl = caster.ToPlayer().GetAverageItemLevel();
                if (avgILvl < baseItemLevel)
                    return;                     /// @todo Research possibility of scaling down

                amount = (int)((avgILvl - baseItemLevel) * factor);
            }

            public override void Register()
            {
                DoEffectCalcAmount.Add(new EffectCalcAmountHandler(CalculateAmount, 0, AuraType.ModHealingPct));
                DoEffectCalcAmount.Add(new EffectCalcAmountHandler(CalculateAmount, 1, AuraType.ModDamagePercentDone));
                DoEffectCalcAmount.Add(new EffectCalcAmountHandler(CalculateAmount, 2, AuraType.ModIncreaseHealthPercent));
            }
        }

        public override AuraScript GetAuraScript()
        {
            return new spell_gen_vehicle_scaling_AuraScript();
        }
    }

    [Script]
    class spell_gen_vendor_bark_trigger : SpellScriptLoader
    {
        public spell_gen_vendor_bark_trigger() : base("spell_gen_vendor_bark_trigger") { }

        class spell_gen_vendor_bark_trigger_SpellScript : SpellScript
        {
            void HandleDummy(uint effIndex)
            {
                Creature vendor = GetCaster().ToCreature();
                if (vendor)
                    if (vendor.GetEntry() == CreatureIds.AmphitheaterVendor)
                        vendor.GetAI().Talk(TextIds.SayAmphitheaterVendor);
            }

            public override void Register()
            {
                OnEffectHitTarget.Add(new EffectHandler(HandleDummy, 0, SpellEffectName.Dummy));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_vendor_bark_trigger_SpellScript();
        }
    }

    [Script]
    class spell_gen_wg_water : SpellScriptLoader
    {
        public spell_gen_wg_water() : base("spell_gen_wg_water") { }

        class spell_gen_wg_water_SpellScript : SpellScript
        {
            SpellCastResult CheckCast()
            {
                if (!GetSpellInfo().CheckTargetCreatureType(GetCaster()))
                    return SpellCastResult.DontReport;
                return SpellCastResult.SpellCastOk;
            }

            public override void Register()
            {
                OnCheckCast.Add(new CheckCastHandler(CheckCast));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_wg_water_SpellScript();
        }
    }

    [Script]
    class spell_gen_whisper_gulch_yogg_saron_whisper : SpellScriptLoader
    {
        public spell_gen_whisper_gulch_yogg_saron_whisper() : base("spell_gen_whisper_gulch_yogg_saron_whisper") { }

        class spell_gen_whisper_gulch_yogg_saron_whisper_AuraScript : AuraScript
        {
            public override bool Validate(SpellInfo spellInfo)
            {
                return ValidateSpellInfo(SpellIds.YoggSaronWhisperDummy);
            }

            void HandleEffectPeriodic(AuraEffect aurEff)
            {
                PreventDefaultAction();
                GetTarget().CastSpell((Unit)null, SpellIds.YoggSaronWhisperDummy, true);
            }

            public override void Register()
            {
                OnEffectPeriodic.Add(new EffectPeriodicHandler(HandleEffectPeriodic, 0, AuraType.PeriodicDummy));
            }
        }

        public override AuraScript GetAuraScript()
        {
            return new spell_gen_whisper_gulch_yogg_saron_whisper_AuraScript();
        }
    }

    [Script]
    class spell_gen_eject_all_passengers : SpellScriptLoader
    {
        public spell_gen_eject_all_passengers() : base("spell_gen_eject_all_passengers") { }

        class spell_gen_eject_all_passengers_SpellScript : SpellScript
        {
            void RemoveVehicleAuras()
            {
                Vehicle vehicle = GetHitUnit().GetVehicleKit();
                if (vehicle)
                    vehicle.RemoveAllPassengers();
            }

            public override void Register()
            {
                AfterHit.Add(new HitHandler(RemoveVehicleAuras));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_eject_all_passengers_SpellScript();
        }
    }

    [Script]
    class spell_gen_gm_freeze : SpellScriptLoader
    {
        public spell_gen_gm_freeze() : base("spell_gen_gm_freeze") { }

        class spell_gen_gm_freeze_AuraScript : AuraScript
        {
            public override bool Validate(SpellInfo spellInfo)
            {
                return ValidateSpellInfo(SpellIds.GmFreeze);
            }

            void OnApply(AuraEffect aurEff, AuraEffectHandleModes mode)
            {
                // Do what was done before to the target in HandleFreezeCommand
                Player player = GetTarget().ToPlayer();
                if (player)
                {
                    // stop combat + make player unattackable + duel stop + stop some spells
                    player.SetFaction(35);
                    player.CombatStop();
                    if (player.IsNonMeleeSpellCast(true))
                        player.InterruptNonMeleeSpells(true);
                    player.SetFlag(UnitFields.Flags, UnitFlags.NonAttackable);

                    // if player class = hunter || warlock remove pet if alive
                    if ((player.GetClass() == Class.Hunter) || (player.GetClass() == Class.Warlock))
                    {
                        Pet pet = player.GetPet();
                        if (pet)
                        {
                            pet.SavePetToDB(PetSaveMode.AsCurrent);
                            // not let dismiss dead pet
                            if (pet.IsAlive())
                                player.RemovePet(pet, PetSaveMode.NotInSlot);
                        }
                    }
                }
            }

            void OnRemove(AuraEffect aurEff, AuraEffectHandleModes mode)
            {
                // Do what was done before to the target in HandleUnfreezeCommand
                Player player = GetTarget().ToPlayer();
                if (player)
                {
                    // Reset player faction + allow combat + allow duels
                    player.setFactionForRace(player.GetRace());
                    player.RemoveFlag(UnitFields.Flags, UnitFlags.NonAttackable);
                    // save player
                    player.SaveToDB();
                }
            }

            public override void Register()
            {
                OnEffectApply.Add(new EffectApplyHandler(OnApply, 0, AuraType.ModStun, AuraEffectHandleModes.Real));
                OnEffectRemove.Add(new EffectApplyHandler(OnRemove, 0, AuraType.ModStun, AuraEffectHandleModes.Real));
            }
        }

        public override AuraScript GetAuraScript()
        {
            return new spell_gen_gm_freeze_AuraScript();
        }
    }

    [Script]
    class spell_gen_stand : SpellScriptLoader
    {
        public spell_gen_stand() : base("spell_gen_stand") { }

        class spell_gen_stand_SpellScript : SpellScript
        {
            void HandleScript(uint eff)
            {
                Creature target = GetHitCreature();
                if (!target)
                    return;

                target.SetStandState(UnitStandStateType.Stand);
                target.HandleEmoteCommand(Emote.StateNone);
            }

            public override void Register()
            {
                OnEffectHitTarget.Add(new EffectHandler(HandleScript, 0, SpellEffectName.ScriptEffect));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_stand_SpellScript();
        }
    }

    enum RequiredMixologySpells
    {
        Mixology = 53042,
        // Flasks
        FlaskOfTheFrostWyrm = 53755,
        FlaskOfStoneblood = 53758,
        FlaskOfEndlessRage = 53760,
        FlaskOfPureMojo = 54212,
        LesserFlaskOfResistance = 62380,
        LesserFlaskOfToughness = 53752,
        FlaskOfBlindingLight = 28521,
        FlaskOfChromaticWonder = 42735,
        FlaskOfFortification = 28518,
        FlaskOfMightyRestoration = 28519,
        FlaskOfPureDeath = 28540,
        FlaskOfRelentlessAssault = 28520,
        FlaskOfChromaticResistance = 17629,
        FlaskOfDistilledWisdom = 17627,
        FlaskOfSupremePower = 17628,
        FlaskOfTheTitans = 17626,
        // Elixirs
        ElixirOfMightyAgility = 28497,
        ElixirOfAccuracy = 60340,
        ElixirOfDeadlyStrikes = 60341,
        ElixirOfMightyDefense = 60343,
        ElixirOfExpertise = 60344,
        ElixirOfArmorPiercing = 60345,
        ElixirOfLightningSpeed = 60346,
        ElixirOfMightyFortitude = 53751,
        ElixirOfMightyMageblood = 53764,
        ElixirOfMightyStrength = 53748,
        ElixirOfMightyToughts = 60347,
        ElixirOfProtection = 53763,
        ElixirOfSpirit = 53747,
        GurusElixir = 53749,
        ShadowpowerElixir = 33721,
        WrathElixir = 53746,
        ElixirOfEmpowerment = 28514,
        ElixirOfMajorMageblood = 28509,
        ElixirOfMajorShadowPower = 28503,
        ElixirOfMajorDefense = 28502,
        FelStrengthElixir = 38954,
        ElixirOfIronskin = 39628,
        ElixirOfMajorAgility = 54494,
        ElixirOfDraenicWisdom = 39627,
        ElixirOfMajorFirepower = 28501,
        ElixirOfMajorFrostPower = 28493,
        EarthenElixir = 39626,
        ElixirOfMastery = 33726,
        ElixirOfHealingPower = 28491,
        ElixirOfMajorFortitude = 39625,
        ElixirOfMajorStrength = 28490,
        AdeptsElixir = 54452,
        OnslaughtElixir = 33720,
        MightyTrollsBloodElixir = 24361,
        GreaterArcaneElixir = 17539,
        ElixirOfTheMongoose = 17538,
        ElixirOfBruteForce = 17537,
        ElixirOfSages = 17535,
        ElixirOfSuperiorDefense = 11348,
        ElixirOfDemonslaying = 11406,
        ElixirOfGreaterFirepower = 26276,
        ElixirOfShadowPower = 11474,
        MagebloodElixir = 24363,
        ElixirOfGiants = 11405,
        ElixirOfGreaterAgility = 11334,
        ArcaneElixir = 11390,
        ElixirOfGreaterIntellect = 11396,
        ElixirOfGreaterDefense = 11349,
        ElixirOfFrostPower = 21920,
        ElixirOfAgility = 11328,
        MajorTrollsBlloodElixir = 3223,
        ElixirOfFortitude = 3593,
        ElixirOfOgresStrength = 3164,
        ElixirOfFirepower = 7844,
        ElixirOfLesserAgility = 3160,
        ElixirOfDefense = 3220,
        StrongTrollsBloodElixir = 3222,
        ElixirOfMinorAccuracy = 63729,
        ElixirOfWisdom = 3166,
        ElixirOfGianthGrowth = 8212,
        ElixirOfMinorAgility = 2374,
        ElixirOfMinorFortitude = 2378,
        WeakTrollsBloodElixir = 3219,
        ElixirOfLionsStrength = 2367,
        ElixirOfMinorDefense = 673
    };

    [Script]
    class spell_gen_mixology_bonus : SpellScriptLoader
    {
        public spell_gen_mixology_bonus() : base("spell_gen_mixology_bonus") { }

        class spell_gen_mixology_bonus_AuraScript : AuraScript
        {
            public spell_gen_mixology_bonus_AuraScript()
            {
                bonus = 0;
            }

            public override bool Validate(SpellInfo spellInfo)
            {
                return ValidateSpellInfo((uint)RequiredMixologySpells.Mixology);
            }

            public override bool Load()
            {
                return GetCaster() && GetCaster().GetTypeId() == TypeId.Player;
            }

            void SetBonusValueForEffect(uint effIndex, int value, AuraEffect aurEff)
            {
                if (aurEff.GetEffIndex() == effIndex)
                    bonus = value;
            }

            void CalculateAmount(AuraEffect aurEff, ref int amount, ref bool canBeRecalculated)
            {
                if (GetCaster().HasAura((uint)RequiredMixologySpells.Mixology) && GetCaster().HasSpell(GetSpellInfo().GetEffect(0).TriggerSpell))
                {
                    switch ((RequiredMixologySpells)GetId())
                    {
                        case RequiredMixologySpells.WeakTrollsBloodElixir:
                        case RequiredMixologySpells.MagebloodElixir:
                            bonus = amount;
                            break;
                        case RequiredMixologySpells.ElixirOfFrostPower:
                        case RequiredMixologySpells.LesserFlaskOfToughness:
                        case RequiredMixologySpells.LesserFlaskOfResistance:
                            bonus = MathFunctions.CalculatePct(amount, 80);
                            break;
                        case RequiredMixologySpells.ElixirOfMinorDefense:
                        case RequiredMixologySpells.ElixirOfLionsStrength:
                        case RequiredMixologySpells.ElixirOfMinorAgility:
                        case RequiredMixologySpells.MajorTrollsBlloodElixir:
                        case RequiredMixologySpells.ElixirOfShadowPower:
                        case RequiredMixologySpells.ElixirOfBruteForce:
                        case RequiredMixologySpells.MightyTrollsBloodElixir:
                        case RequiredMixologySpells.ElixirOfGreaterFirepower:
                        case RequiredMixologySpells.OnslaughtElixir:
                        case RequiredMixologySpells.EarthenElixir:
                        case RequiredMixologySpells.ElixirOfMajorAgility:
                        case RequiredMixologySpells.FlaskOfTheTitans:
                        case RequiredMixologySpells.FlaskOfRelentlessAssault:
                        case RequiredMixologySpells.FlaskOfStoneblood:
                        case RequiredMixologySpells.ElixirOfMinorAccuracy:
                            bonus = MathFunctions.CalculatePct(amount, 50);
                            break;
                        case RequiredMixologySpells.ElixirOfProtection:
                            bonus = 280;
                            break;
                        case RequiredMixologySpells.ElixirOfMajorDefense:
                            bonus = 200;
                            break;
                        case RequiredMixologySpells.ElixirOfGreaterDefense:
                        case RequiredMixologySpells.ElixirOfSuperiorDefense:
                            bonus = 140;
                            break;
                        case RequiredMixologySpells.ElixirOfFortitude:
                            bonus = 100;
                            break;
                        case RequiredMixologySpells.FlaskOfEndlessRage:
                            bonus = 82;
                            break;
                        case RequiredMixologySpells.ElixirOfDefense:
                            bonus = 70;
                            break;
                        case RequiredMixologySpells.ElixirOfDemonslaying:
                            bonus = 50;
                            break;
                        case RequiredMixologySpells.FlaskOfTheFrostWyrm:
                            bonus = 47;
                            break;
                        case RequiredMixologySpells.WrathElixir:
                            bonus = 32;
                            break;
                        case RequiredMixologySpells.ElixirOfMajorFrostPower:
                        case RequiredMixologySpells.ElixirOfMajorFirepower:
                        case RequiredMixologySpells.ElixirOfMajorShadowPower:
                            bonus = 29;
                            break;
                        case RequiredMixologySpells.ElixirOfMightyToughts:
                            bonus = 27;
                            break;
                        case RequiredMixologySpells.FlaskOfSupremePower:
                        case RequiredMixologySpells.FlaskOfBlindingLight:
                        case RequiredMixologySpells.FlaskOfPureDeath:
                        case RequiredMixologySpells.ShadowpowerElixir:
                            bonus = 23;
                            break;
                        case RequiredMixologySpells.ElixirOfMightyAgility:
                        case RequiredMixologySpells.FlaskOfDistilledWisdom:
                        case RequiredMixologySpells.ElixirOfSpirit:
                        case RequiredMixologySpells.ElixirOfMightyStrength:
                        case RequiredMixologySpells.FlaskOfPureMojo:
                        case RequiredMixologySpells.ElixirOfAccuracy:
                        case RequiredMixologySpells.ElixirOfDeadlyStrikes:
                        case RequiredMixologySpells.ElixirOfMightyDefense:
                        case RequiredMixologySpells.ElixirOfExpertise:
                        case RequiredMixologySpells.ElixirOfArmorPiercing:
                        case RequiredMixologySpells.ElixirOfLightningSpeed:
                            bonus = 20;
                            break;
                        case RequiredMixologySpells.FlaskOfChromaticResistance:
                            bonus = 17;
                            break;
                        case RequiredMixologySpells.ElixirOfMinorFortitude:
                        case RequiredMixologySpells.ElixirOfMajorStrength:
                            bonus = 15;
                            break;
                        case RequiredMixologySpells.FlaskOfMightyRestoration:
                            bonus = 13;
                            break;
                        case RequiredMixologySpells.ArcaneElixir:
                            bonus = 12;
                            break;
                        case RequiredMixologySpells.ElixirOfGreaterAgility:
                        case RequiredMixologySpells.ElixirOfGiants:
                            bonus = 11;
                            break;
                        case RequiredMixologySpells.ElixirOfAgility:
                        case RequiredMixologySpells.ElixirOfGreaterIntellect:
                        case RequiredMixologySpells.ElixirOfSages:
                        case RequiredMixologySpells.ElixirOfIronskin:
                        case RequiredMixologySpells.ElixirOfMightyMageblood:
                            bonus = 10;
                            break;
                        case RequiredMixologySpells.ElixirOfHealingPower:
                            bonus = 9;
                            break;
                        case RequiredMixologySpells.ElixirOfDraenicWisdom:
                        case RequiredMixologySpells.GurusElixir:
                            bonus = 8;
                            break;
                        case RequiredMixologySpells.ElixirOfFirepower:
                        case RequiredMixologySpells.ElixirOfMajorMageblood:
                        case RequiredMixologySpells.ElixirOfMastery:
                            bonus = 6;
                            break;
                        case RequiredMixologySpells.ElixirOfLesserAgility:
                        case RequiredMixologySpells.ElixirOfOgresStrength:
                        case RequiredMixologySpells.ElixirOfWisdom:
                        case RequiredMixologySpells.ElixirOfTheMongoose:
                            bonus = 5;
                            break;
                        case RequiredMixologySpells.StrongTrollsBloodElixir:
                        case RequiredMixologySpells.FlaskOfChromaticWonder:
                            bonus = 4;
                            break;
                        case RequiredMixologySpells.ElixirOfEmpowerment:
                            bonus = -10;
                            break;
                        case RequiredMixologySpells.AdeptsElixir:
                            SetBonusValueForEffect(0, 13, aurEff);
                            SetBonusValueForEffect(1, 13, aurEff);
                            SetBonusValueForEffect(2, 8, aurEff);
                            break;
                        case RequiredMixologySpells.ElixirOfMightyFortitude:
                            SetBonusValueForEffect(0, 160, aurEff);
                            break;
                        case RequiredMixologySpells.ElixirOfMajorFortitude:
                            SetBonusValueForEffect(0, 116, aurEff);
                            SetBonusValueForEffect(1, 6, aurEff);
                            break;
                        case RequiredMixologySpells.FelStrengthElixir:
                            SetBonusValueForEffect(0, 40, aurEff);
                            SetBonusValueForEffect(1, 40, aurEff);
                            break;
                        case RequiredMixologySpells.FlaskOfFortification:
                            SetBonusValueForEffect(0, 210, aurEff);
                            SetBonusValueForEffect(1, 5, aurEff);
                            break;
                        case RequiredMixologySpells.GreaterArcaneElixir:
                            SetBonusValueForEffect(0, 19, aurEff);
                            SetBonusValueForEffect(1, 19, aurEff);
                            SetBonusValueForEffect(2, 5, aurEff);
                            break;
                        case RequiredMixologySpells.ElixirOfGianthGrowth:
                            SetBonusValueForEffect(0, 5, aurEff);
                            break;
                        default:
                            Log.outError(LogFilter.Spells, "SpellId {0} couldn't be processed in spell_gen_mixology_bonus", GetId());
                            break;
                    }
                    amount += bonus;
                }
            }

            int bonus;

            public override void Register()
            {
                DoEffectCalcAmount.Add(new EffectCalcAmountHandler(CalculateAmount, SpellConst.EffectAll, AuraType.Any));
            }
        }

        public override AuraScript GetAuraScript()
        {
            return new spell_gen_mixology_bonus_AuraScript();
        }
    }

    [Script]
    class spell_gen_landmine_knockback_achievement : SpellScriptLoader
    {
        public spell_gen_landmine_knockback_achievement() : base("spell_gen_landmine_knockback_achievement") { }

        class spell_gen_landmine_knockback_achievement_SpellScript : SpellScript
        {
            void HandleScript(uint effIndex)
            {
                Player target = GetHitPlayer();
                if (target)
                {
                    Aura aura = GetHitAura();
                    if (aura == null || aura.GetStackAmount() < 10)
                        return;

                    target.CastSpell(target, SpellIds.LandmineKnockbackAchievement, true);
                }
            }

            public override void Register()
            {
                OnEffectHitTarget.Add(new EffectHandler(HandleScript, 0, SpellEffectName.ScriptEffect));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_landmine_knockback_achievement_SpellScript();
        }
    }

    [Script] // 34098 - ClearAllDebuffs
    class spell_gen_clear_debuffs : SpellScriptLoader
    {
        public spell_gen_clear_debuffs() : base("spell_gen_clear_debuffs") { }

        class spell_gen_clear_debuffs_SpellScript : SpellScript
        {
            void HandleScript(uint effIndex)
            {
                Unit target = GetHitUnit();
                if (target)
                {
                    target.RemoveOwnedAuras(aura =>
                    {
                        SpellInfo spellInfo = aura.GetSpellInfo();
                        return !spellInfo.IsPositive() && !spellInfo.IsPassive();
                    });
                }
            }

            public override void Register()
            {
                OnEffectHitTarget.Add(new EffectHandler(HandleScript, 0, SpellEffectName.ScriptEffect));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_clear_debuffs_SpellScript();
        }
    }

    [Script]
    class spell_gen_pony_mount_check : SpellScriptLoader
    {
        public spell_gen_pony_mount_check() : base("spell_gen_pony_mount_check") { }

        class spell_gen_pony_mount_check_AuraScript : AuraScript
        {
            void HandleEffectPeriodic(AuraEffect aurEff)
            {
                Unit caster = GetCaster();
                if (!caster)
                    return;

                Player owner = caster.GetOwner().ToPlayer();
                if (!owner || !owner.HasAchieved(SpellIds.AchievementPonyup))
                    return;

                if (owner.IsMounted())
                {
                    caster.Mount(SpellIds.MountPony);
                    caster.SetSpeedRate(UnitMoveType.Run, owner.GetSpeedRate(UnitMoveType.Run));
                }
                else if (caster.IsMounted())
                {
                    caster.Dismount();
                    caster.SetSpeedRate(UnitMoveType.Run, owner.GetSpeedRate(UnitMoveType.Run));
                }
            }

            public override void Register()
            {
                OnEffectPeriodic.Add(new EffectPeriodicHandler(HandleEffectPeriodic, 0, AuraType.PeriodicDummy));
            }
        }

        public override AuraScript GetAuraScript()
        {
            return new spell_gen_pony_mount_check_AuraScript();
        }
    }

    [Script] // 169869 - Transformation Sickness
    class spell_gen_decimatus_transformation_sickness : SpellScriptLoader
    {
        public spell_gen_decimatus_transformation_sickness() : base("spell_gen_decimatus_transformation_sickness") { }

        class spell_gen_decimatus_transformation_sickness_SpellScript : SpellScript
        {
            void HandleScript(uint effIndex)
            {
                Unit target = GetHitUnit();
                if (target)
                    target.SetHealth(target.CountPctFromMaxHealth(25));
            }

            public override void Register()
            {
                OnEffectHitTarget.Add(new EffectHandler(HandleScript, 1, SpellEffectName.ScriptEffect));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_decimatus_transformation_sickness_SpellScript();
        }
    }

    [Script] // 189491 - Summon Towering Infernal.
    class spell_gen_anetheron_summon_towering_infernal : SpellScriptLoader
    {
        public spell_gen_anetheron_summon_towering_infernal() : base("spell_gen_anetheron_summon_towering_infernal") { }

        class spell_gen_anetheron_summon_towering_infernal_SpellScript : SpellScript
        {
            void HandleDummy(uint effIndex)
            {
                GetCaster().CastSpell(GetHitUnit(), (uint)GetEffectValue(), true);
            }

            public override void Register()
            {
                OnEffectHitTarget.Add(new EffectHandler(HandleDummy, 0, SpellEffectName.Dummy));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_anetheron_summon_towering_infernal_SpellScript();
        }
    }

    [Script]
    class spell_gen_mark_of_kazrogal_hellfire : SpellScriptLoader
    {
        public spell_gen_mark_of_kazrogal_hellfire() : base("spell_gen_mark_of_kazrogal_hellfire") { }

        class spell_gen_mark_of_kazrogal_hellfire_SpellScript : SpellScript
        {
            void FilterTargets(List<WorldObject> targets)
            {
                targets.RemoveAll(target =>
                {
                    Unit unit = target.ToUnit();
                    if (unit)
                        return unit.getPowerType() != PowerType.Mana;
                    return false;
                });
            }

            public override void Register()
            {
                OnObjectAreaTargetSelect.Add(new ObjectAreaTargetSelectHandler(FilterTargets, 0, Targets.UnitSrcAreaEnemy));
            }
        }

        class spell_gen_mark_of_kazrogal_hellfire_AuraScript : AuraScript
        {
            public override bool Validate(SpellInfo spell)
            {
                return ValidateSpellInfo(SpellIds.MarkOfKazrogalDamageHellfire);
            }

            void OnPeriodic(AuraEffect aurEff)
            {
                Unit target = GetTarget();

                if (target.GetPower(PowerType.Mana) == 0)
                {
                    target.CastSpell(target, SpellIds.MarkOfKazrogalDamageHellfire, true, null, aurEff);
                    // Remove aura
                    SetDuration(0);
                }
            }

            public override void Register()
            {
                OnEffectPeriodic.Add(new EffectPeriodicHandler(OnPeriodic, 0, AuraType.PowerBurn));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_mark_of_kazrogal_hellfire_SpellScript();
        }

        public override AuraScript GetAuraScript()
        {
            return new spell_gen_mark_of_kazrogal_hellfire_AuraScript();
        }
    }

    [Script]
    class spell_gen_azgalor_rain_of_fire_hellfire_citadel : SpellScriptLoader
    {
        public spell_gen_azgalor_rain_of_fire_hellfire_citadel() : base("spell_gen_azgalor_rain_of_fire_hellfire_citadel") { }

        class spell_gen_azgalor_rain_of_fire_hellfire_citadel_SpellScript : SpellScript
        {
            void HandleDummy(uint effIndex)
            {
                GetCaster().CastSpell(GetHitUnit(), (uint)GetEffectValue(), true);
            }

            public override void Register()
            {
                OnEffectHitTarget.Add(new EffectHandler(HandleDummy, 0, SpellEffectName.Dummy));
            }
        }

        public override SpellScript GetSpellScript()
        {
            return new spell_gen_azgalor_rain_of_fire_hellfire_citadel_SpellScript();
        }
    }

    [Script] // 99947 - Face Rage
    class spell_gen_face_rage : SpellScriptLoader
    {
        public spell_gen_face_rage() : base("spell_gen_face_rage") { }

        class spell_gen_face_rage_AuraScript : AuraScript
        {
            public override bool Validate(SpellInfo spell)
            {
                return ValidateSpellInfo(SpellIds.FaceRage);
            }

            void OnRemove(AuraEffect effect, AuraEffectHandleModes mode)
            {
                GetTarget().RemoveAurasDueToSpell(GetSpellInfo().GetEffect(2).TriggerSpell);
            }

            public override void Register()
            {
                OnEffectRemove.Add(new EffectApplyHandler(OnRemove, 0, AuraType.ModStun, AuraEffectHandleModes.Real));
            }
        }

        public override AuraScript GetAuraScript()
        {
            return new spell_gen_face_rage_AuraScript();
        }
    }

    [Script] // 187213 - Impatient Mind
    class spell_gen_impatient_mind : SpellScriptLoader
    {
        public spell_gen_impatient_mind() : base("spell_gen_impatient_mind") { }

        class spell_gen_impatient_mind_AuraScript : AuraScript
        {
            public override bool Validate(SpellInfo spell)
            {
                return ValidateSpellInfo(SpellIds.ImpatientMind);
            }

            void OnRemove(AuraEffect effect, AuraEffectHandleModes mode)
            {
                GetTarget().RemoveAurasDueToSpell(effect.GetSpellEffectInfo().TriggerSpell);
            }

            public override void Register()
            {
                OnEffectRemove.Add(new EffectApplyHandler(OnRemove, 0, AuraType.ProcTriggerSpell, AuraEffectHandleModes.Real));
            }
        }

        public override AuraScript GetAuraScript()
        {
            return new spell_gen_impatient_mind_AuraScript();
        }
    }
}