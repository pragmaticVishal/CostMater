using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ObservableCollection<Component> GetAll()
        {
            if(_components.Count == 0)
            {
                _components.Add(new Component() { ComponentID = 1, MaterialTypeID = 0, MaterialID = 0});
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
