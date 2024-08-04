using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DetailsView.Data
{
    public interface IComponentRepository
    {
        // Define methods for CRUD operations
        void Add(Component component);
        Component GetById(int id);
        ObservableCollection<Component> GetAll();
        void Update(Component component);
        void Delete(int id);
    }
}
