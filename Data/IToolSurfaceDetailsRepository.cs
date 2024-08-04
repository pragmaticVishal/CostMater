using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailsView.Data
{
    public interface IToolSurfaceDetailsRepository
    {
        void Add(ToolSurfaceDetails toolSurfaceDetails);
        ToolSurfaceDetails GetById(int id);
        IEnumerable<ToolSurfaceDetails> GetAll();
        void Update(ToolSurfaceDetails toolSurfaceDetails);
        void Delete(int id);
    }
}
