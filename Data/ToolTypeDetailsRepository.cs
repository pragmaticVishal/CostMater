using DetailsView.Data;
using System.Collections.Generic;
using System.Linq;

namespace DetailsView
{
    public class ToolTypeDetailsRepository : IToolTypeDetailsRepository
    {
        private readonly List<ToolTypeDetails> _toolTypeDetailsList = new List<ToolTypeDetails>();

        public ToolTypeDetailsRepository()
        {
            _toolTypeDetailsList = new List<ToolTypeDetails>
            {
                new ToolTypeDetails { ToolTypeID = 0, ToolTypeName = string.Empty },
                new ToolTypeDetails { ToolTypeID = 1, ToolTypeName = "HSS" },
                new ToolTypeDetails { ToolTypeID = 2, ToolTypeName = "Carbide" },
                new ToolTypeDetails { ToolTypeID = 3, ToolTypeName = "Stellite" }
            };
        }

        public void Add(ToolTypeDetails toolTypeDetails)
        {
            _toolTypeDetailsList.Add(toolTypeDetails);
        }

        public void Delete(int id)
        {
            var toolTypeDetails = GetById(id);
            if (toolTypeDetails != null)
            {
                _toolTypeDetailsList.Remove(toolTypeDetails);
            }
        }

        public IEnumerable<ToolTypeDetails> GetAll()
        {
            return _toolTypeDetailsList;
        }

        public ToolTypeDetails GetById(int id)
        {
            return _toolTypeDetailsList.FirstOrDefault(p => p.ToolTypeID == id);
        }

        public void Update(ToolTypeDetails toolTypeDetails)
        {
            var existingToolTypeDetails = GetById(toolTypeDetails.ToolTypeID);
            if (existingToolTypeDetails != null)
            {
                existingToolTypeDetails.ToolTypeName = toolTypeDetails.ToolTypeName;
                // Add other properties as needed
            }
        }
    }
}
