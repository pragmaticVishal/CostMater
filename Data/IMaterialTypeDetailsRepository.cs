using DetailsView.Data;
using System.Collections.Generic;

namespace DetailsView
{
    public interface IMaterialTypeDetailsRepository
    {
        void Add(MaterialTypeDetails materialTypeDetails);
        MaterialTypeDetails GetById(int id);
        IEnumerable<MaterialTypeDetails> GetAll();
        void Update(MaterialTypeDetails materialTypeDetails);
        void Delete(int id);
    }
}