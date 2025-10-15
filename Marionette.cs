using Il2Cpp;
using Il2CppFIMSpace.Basics;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using UnityEngine;
using static Il2CppSystem.Globalization.CultureInfo;
using static MelonLoader.MelonLaunchOptions;


public class Marionette : Il2Cpp.Minion
{

    public Marionette(IntPtr ptr) : base(ptr) { }


    public override string Description
    {
        get => "[I sit next to a Demon]";
    }

    public override Il2Cpp.ActedInfo GetInfo(Il2Cpp.Character charRef)
    {
        return new Il2Cpp.ActedInfo("Sitting next to a demon...");
    }

    public override void Act(Il2Cpp.ETriggerPhase trigger, Il2Cpp.Character charRef)
    {

        if (trigger != Il2Cpp.ETriggerPhase.Start) return; 


        SitNextToDemon(charRef);
    }

 
    public void SitNextToDemon(Il2Cpp.Character charRef)
    {


        List<Il2Cpp.Character> demons = 
            new List<Il2Cpp.Character>(Il2Cpp.Gameplay.CurrentCharacters);
        
        demons = Il2Cpp.Characters.Instance.FilterCharacterType(demons, Il2Cpp.ECharacterType.Demon);

        if (demons.Count <= 0) return;

        Il2Cpp.Character pickedDemon = demons[UnityEngine.Random.Range(0, demons.Count)];
        
        System.Collections.Generic.List<Il2Cpp.Character> adjacentCharacters = 
            Il2Cpp.Characters.Instance.GetAdjacentAliveCharacters(pickedDemon);
        
        if (adjacentCharacters.Count <= 0) return; 

        Il2Cpp.Character pickedAdjacentCharacter = adjacentCharacters[UnityEngine.Random.Range(0, adjacentCharacters.Count)];
        Il2Cpp.CharacterData pickedData = pickedAdjacentCharacter.dataRef;
        
        pickedAdjacentCharacter.InitWithNoReset(charRef.dataRef);
        charRef.InitWithNoReset(pickedData);
    }
}