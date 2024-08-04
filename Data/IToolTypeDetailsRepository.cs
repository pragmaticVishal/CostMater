using DetailsView.Data;
using System.Collections.Generic;

namespace DetailsView
{
    public interface IToolTypeDetailsRepository
    {
        void Add(ToolTypeDetails toolTypeDetails);
        ToolTypeDetails GetById(int id);
        IEnumerable<ToolTypeDetails> GetAll();
        void Update(ToolTypeDetails toolTypeDetails);
        void Delete(int id);
    }
}