using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailsView.Data
{
    public class ToolSurfaceDetailsRepository : IToolSurfaceDetailsRepository
    {
        private readonly List<ToolSurfaceDetails> _toolSurfaceDetailsList = new List<ToolSurfaceDetails>();

        public ToolSurfaceDetailsRepository()
        {
            _toolSurfaceDetailsList = new List<ToolSurfaceDetails>
            {
                new ToolSurfaceDetails { ToolSurfaceID = 0, ToolSurfaceName = string.Empty },
                new ToolSurfaceDetails { ToolSurfaceID = 1, ToolSurfaceName = "Rough" },
                new ToolSurfaceDetails { ToolSurfaceID = 2, ToolSurfaceName = "Finish" }
            };
        }

        public void Add(ToolSurfaceDetails toolSurfaceDetails)
        {
            _toolSurfaceDetailsList.Add(toolSurfaceDetails);
        }

        public void Delete(int id)
        {
            var toolTypeDetails = GetById(id);
            if (toolTypeDetails != null)
            {
                _toolSurfaceDetailsList.Remove(toolTypeDetails);
            }
        }

        public IEnumerable<ToolSurfaceDetails> GetAll()
        {
            return _toolSurfaceDetailsList;
        }

        public ToolSurfaceDetails GetById(int id)
        {
            return _toolSurfaceDetailsList.FirstOrDefault(p => p.ToolSurfaceID == id);
        }

        public void Update(ToolSurfaceDetails toolSurfaceDetails)
        {
            var existingToolSurfaceTypeDetails = GetById(toolSurfaceDetails.ToolSurfaceID);
            if (existingToolSurfaceTypeDetails != null)
            {
                existingToolSurfaceTypeDetails.ToolSurfaceName = toolSurfaceDetails.ToolSurfaceName;
                // Add other properties as needed
            }
        }
    }
}
