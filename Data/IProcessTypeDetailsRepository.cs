using DetailsView.Data;
using System.Collections.Generic;

namespace DetailsView
{
    public interface IProcessTypeDetailsRepository
    {
        void Add(ProcessTypeDetails processTypeDetails);
        ProcessTypeDetails GetById(int id);
        IEnumerable<ProcessTypeDetails> GetAll();
        void Update(ProcessTypeDetails processTypeDetails);
        void Delete(int id);
    }
}
