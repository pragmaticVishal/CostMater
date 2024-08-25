using DetailsView.Data;
using System.Collections.Generic;
using System.Linq;

namespace DetailsView
{
    public class ProcessTypeDetailsRepository : IProcessTypeDetailsRepository
    {
        private readonly List<ProcessTypeDetails> _processTypeDetailsList = new List<ProcessTypeDetails>();

        public ProcessTypeDetailsRepository()
        {
            _processTypeDetailsList = new List<ProcessTypeDetails>
            {
                new ProcessTypeDetails { ProcessTypeID = 0, ProcessTypeName = string.Empty },
                new ProcessTypeDetails { ProcessTypeID = 1, ProcessTypeName = "Step Turning" },
                new ProcessTypeDetails { ProcessTypeID = 2, ProcessTypeName = "Face Turning" },
                new ProcessTypeDetails { ProcessTypeID = 3, ProcessTypeName = "ID Turning" },
                new ProcessTypeDetails { ProcessTypeID = 4, ProcessTypeName = "OD Turning" },
                new ProcessTypeDetails { ProcessTypeID = 5, ProcessTypeName = "Drilling" },
                new ProcessTypeDetails { ProcessTypeID = 6, ProcessTypeName = "Threading" },
            };
        }

        public void Add(ProcessTypeDetails processTypeDetails)
        {
            _processTypeDetailsList.Add(processTypeDetails);
        }

        public ProcessTypeDetails GetById(int id)
        {
            return _processTypeDetailsList.FirstOrDefault(p => p.ProcessTypeID == id);
        }

        public IEnumerable<ProcessTypeDetails> GetAll()
        {
            return _processTypeDetailsList;
        }

        public void Update(ProcessTypeDetails processTypeDetails)
        {
            var existingProcessTypeDetails = GetById(processTypeDetails.ProcessTypeID);
            if (existingProcessTypeDetails != null)
            {
                existingProcessTypeDetails.ProcessTypeName = processTypeDetails.ProcessTypeName;
                // Add other properties as needed
            }
        }

        public void Delete(int id)
        {
            var processTypeDetails = GetById(id);
            if (processTypeDetails != null)
            {
                _processTypeDetailsList.Remove(processTypeDetails);
            }
        }
    }
}
