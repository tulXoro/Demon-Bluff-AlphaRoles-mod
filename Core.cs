global using Il2Cpp;
using Il2CppDissolveExample;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppSystem.IO;
using MelonLoader;
using System;
using UnityEngine;
using static Il2Cpp.Interop;


using static Il2CppSystem.Array;

[assembly: MelonInfo(typeof(AlphaRoles.Core), "AlphaRoles", "0.1.0", "tulxoro", null)]
[assembly: MelonGame("UmiArt", "Demon Bluff")]

namespace AlphaRoles
{
    public class Core : MelonMod
    {
        public override void OnInitializeMelon()
        {
            // NOTHING FOR NOW
        }

        public override void OnLateInitializeMelon()
        {
            LoggerInstance.Msg("Attempting Late init...");

            GameData gameData = Il2Cpp.ProjectContext.Instance.gameData;

            // only two roles that are implemented and usable in the game...
            CharacterData saintData = null;
            CharacterData mutantData = null;

            foreach (CharacterData character in gameData.allCharacterData)
            {
                
                switch(character.characterId)
                {
                    case "Saint_61372493":
                        saintData = character;
                        break;
                    case "Mutant_84675843":
                        mutantData = character;
                        break;
            
                }

            }

            AscensionsData advancedAscension = ProjectContext.Instance.gameData.advancedAscension;
            foreach (CustomScriptData scriptData in advancedAscension.possibleScriptsData)
            {
                ScriptInfo script = scriptData.scriptInfo;
                addRole(script.startingTownsfolks, saintData);
                addRole(script.startingOutsiders, mutantData);
                

            }

        }
        public void addRole(Il2CppSystem.Collections.Generic.List<CharacterData> list, CharacterData data)
        {
            if (list.Contains(data))
            {
                return;
            }
            list.Add(data);
        }

    }
}