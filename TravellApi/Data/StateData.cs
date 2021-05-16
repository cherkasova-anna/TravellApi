using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellApi.Models;

namespace TravellApi.Data
{
    public class StateData
    {
        public static StateDto FirstState()
        {
            return new StateDto(0, "Какова ваша цель?", true);
        }

        public static List<StateDto> AllStates()
        {
            List<StateDto> states = new List<StateDto>();
            states.Add(new StateDto(0, "Какова ваша цель?", true));
            return states;

        }
    }
}
