using DetailsView.Data;
using System.Collections.Generic;
using System.Linq;

namespace DetailsView
{
    public class MaterialTypeDetailsRepository : IMaterialTypeDetailsRepository
    {
        private readonly List<MaterialTypeDetails> _materialTypeDetailsList = new List<MaterialTypeDetails>();

        public MaterialTypeDetailsRepository()
        {
            _materialTypeDetailsList = new List<MaterialTypeDetails>
            {
                new MaterialTypeDetails { MaterialTypeID = 0, MaterialTypeName = "" },
                new MaterialTypeDetails { MaterialTypeID = 1, MaterialTypeName = "Sheet" },
                new MaterialTypeDetails { MaterialTypeID = 2, MaterialTypeName = "Plate" },
                new MaterialTypeDetails { MaterialTypeID = 3, MaterialTypeName = "Flat" },
                new MaterialTypeDetails { MaterialTypeID = 4, MaterialTypeName = "Angle" },
                new MaterialTypeDetails { MaterialTypeID = 5, MaterialTypeName = "Round Bar" },
                new MaterialTypeDetails { MaterialTypeID = 6, MaterialTypeName = "Round Tube" },
                new MaterialTypeDetails { MaterialTypeID = 7, MaterialTypeName = "Rectangular Bar" },
                new MaterialTypeDetails { MaterialTypeID = 8, MaterialTypeName = "Rectangular Tube" },
                new MaterialTypeDetails { MaterialTypeID = 9, MaterialTypeName = "Square Bar" },
                new MaterialTypeDetails { MaterialTypeID = 10, MaterialTypeName = "Square Tube" },
            };
        }

        public void Add(MaterialTypeDetails materialTypeDetails)
        {
            _materialTypeDetailsList.Add(materialTypeDetails);
        }

        public MaterialTypeDetails GetById(int id)
        {
            return _materialTypeDetailsList.FirstOrDefault(m => m.MaterialTypeID == id);
        }

        public IEnumerable<MaterialTypeDetails> GetAll()
        {
            return _materialTypeDetailsList;
        }

        public void Update(MaterialTypeDetails materialTypeDetails)
        {
            var existingMaterialTypeDetails = GetById(materialTypeDetails.MaterialTypeID);
            if (existingMaterialTypeDetails != null)
            {
                existingMaterialTypeDetails.MaterialTypeName = materialTypeDetails.MaterialTypeName;
                // Add other properties as needed
            }
        }

        public void Delete(int id)
        {
            var materialTypeDetails = GetById(id);
            if (materialTypeDetails != null)
            {
                _materialTypeDetailsList.Remove(materialTypeDetails);
            }
        }
    }
}