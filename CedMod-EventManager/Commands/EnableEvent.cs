﻿using System;
using System.Collections.Generic;
using System.Linq;
using CedMod.QuerySystem;
using CedMod.QuerySystem.WS;
using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using MEC;
using Newtonsoft.Json;

namespace CedMod.EventManager.Commands
{
    public class EnableEvent : ICommand, IUsageProvider
    {
        public string Command { get; } = "enable";

        public string[] Aliases { get; } = new string[]
        {
        };

        public string Description { get; } = "Enables the specified event, if Force is true the server will restart the round immediately";

        public string[] Usage { get; } = new string[]
        {
            "%eventprefix%",
            "%force%"
        };

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender,
            out string response)
        {
            if (arguments.Count < 2)
            {
                response = "To execute this command provide at least 2 arguments!\nUsage: " + this.DisplayCommandUsage();
                return false;
            }
            IEvent @event = EventManager.Singleton.AvailableEvents.FirstOrDefault(ev => ev.EventPrefix == arguments.At(0));
            bool force = Convert.ToBoolean(arguments.At(1));
            if (@event == null)
            {
                response = "Event does not exist";
                return false;
            }
            if (sender.IsPanelUser())
            {
                if (!sender.CheckPermission(PlayerPermissions.FacilityManagement))
                {
                    response = "No permission";
                    return false;
                }
            }
            else
            {
                response = "";
                if (!sender.CheckPermission("cedmod.events.enable"))
                {
                    response = "No permission";
                    return false;
                }
            }
            EventManager.Singleton.nextEvent = @event;
            if (force)
            {
                Map.Broadcast(5, $"EventManager: {@event.EventName} is being enabled.\nRound will restart in 3 seconds");
                Timing.CallDelayed(3, () =>
                {
                    Round.Restart(false, false);
                });
            }
            else
            {
                Map.Broadcast(10, $"EventManager: {@event.EventName} is being enabled for next round");
            }
            response = "Success";
            return true;
        }
    }
}