using SocomTrainingPlatform.Models;
using SocomTrainingPlatform.Models.SiteModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocomTrainingPlatform.BuisnessLogic
{
    public class SiteSearchLogic
    {
        public readonly SocomTrainingPlatformContext _context;

        public SiteSearchLogic(SocomTrainingPlatformContext Context)
        {
            _context = Context;
        }

        public List<StateSelectView> GetStateCity()
        {
            var locations = _context.Locations.ToList();
            List<string> cityCollector = new();
            List<string> stateCollector = new();
            var newStateList = new List<StateSelectView>();

            foreach(var loc in locations)
            {
                StateSelectView tempState = new();
                CitySelectView tempCity = new();

                if (newStateList.Count == 0)
                {
                    tempState = new StateSelectView()
                    {
                        State = loc.State,
                        Id = loc.State,
                        Citys = new List<CitySelectView>() { new CitySelectView() { City = loc.City, Id = loc.City, StateId = loc.State } }
                    };

                    newStateList.Add(tempState);
                }
                if (newStateList.FirstOrDefault(s => s.State == loc.State) == null)
                {
                    tempState = new StateSelectView()
                    {
                        State = loc.State,
                        Id = loc.State,
                        Citys = new List<CitySelectView>() { new CitySelectView() { City = loc.City, Id = loc.City, StateId = loc.State } }
                    };

                    newStateList.Add(tempState);
                }
                if(stateCollector.Contains(loc.State) == true && cityCollector.Contains(loc.City) == false)
                {
                    newStateList.FirstOrDefault(s => s.State == loc.State).Citys.Add(new CitySelectView() { City = loc.City, Id = loc.City, StateId = loc.State });
                }

                cityCollector.Add(loc.City);
                stateCollector.Add(loc.State);
            }

            return newStateList.OrderBy(s => s.Id).ToList();

        }

    }
}
