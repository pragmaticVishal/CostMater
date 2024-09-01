using CostMater.Data;
using Microsoft.DotNet.DesignTools.Protocol.Values;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace DetailsView.Data
{
    public class ComponentRepository : IComponentRepository
    {
        private readonly ObservableCollection<Component> _components = new ObservableCollection<Component>();

        public void Add(Component component)
        {
            _components.Add(component);
        }

        public Component GetById(int id)
        {
            return _components.FirstOrDefault(c => c.ComponentID == id);
        }

        public static Component CreateComponent(int id)
        {
            Component component = new Component() { ComponentID = id, MaterialTypeID = 0, MaterialID = 0 };

            component.LstProcess = new ObservableCollection<Process>
            {
                new Process()
                {
                    ComponentID = id,
                    ProcessID = 1,
                    ProcessTypeID = 0,
                    ToolTypeID = 0,
                    ToolSurfaceID = 0,
                    MachiningCostPerHour = 300,
                    Component = component,
                }
            };

            component.LstOneTimeOperationDetail = new ObservableCollection<OneTimeOperationDetail>
            {
                new OneTimeOperationDetail()
                {
                    ComponentID = id,
                    OnetimeOpDetailID = 1,
                    OneTimeOpItemSelectedID = 0,
                    Component = component,
                }
            };


            component.LstLaserAndBendingDetail = new ObservableCollection<LaserAndBendingDetail>
            {
                new LaserAndBendingDetail()
                {
                    ComponentID = id,
                    LaserAndBendingDetailID = 1,
                    MaterialShapeSelectedID = 0,
                    Component = component,
                }
            };

            return component;
        }

        public ObservableCollection<Component> GetAll()
        {
            if(_components.Count == 0)
            {
                _components.Add(CreateComponent(1));
            }

            return _components;
        }

        public void Update(Component component)
        {
            var existingComponent = GetById(component.ComponentID);
            if (existingComponent != null)
            {
                // Update properties
                //existingComponent.Name = component.Name;
                // Add other properties as needed
            }
        }

        public void Delete(int id)
        {
            var component = GetById(id);
            if (component != null)
            {
                _components.Remove(component);
            }
        }
    }
}
