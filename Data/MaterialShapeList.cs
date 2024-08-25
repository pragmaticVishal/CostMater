using Syncfusion.WinForms.DataGrid;
using System.Collections;
using System.Collections.Generic;

namespace CostMater.Data
{
    public class MaterialShapeItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class MaterialShapeList : IDataSourceSelector
    {
        public IEnumerable GetDataSource(object record, object dataSource)
        {
            return new List<MaterialShapeItem>()
            {
                new MaterialShapeItem() {ID=0, Name = ""},
                new MaterialShapeItem() {ID=1, Name = "Sheet"},
                new MaterialShapeItem() {ID=2, Name = "Plate"},
                new MaterialShapeItem() {ID=3, Name = "Flat"},
                new MaterialShapeItem() {ID=4, Name = "Angle"},
                new MaterialShapeItem() {ID=5, Name = "Round Bar"},
                new MaterialShapeItem() {ID=6, Name = "Round Tube"},
                new MaterialShapeItem() {ID=7, Name = "Rectangular Bar"},
                new MaterialShapeItem() {ID=8, Name = "Rectangular Tube"},
                new MaterialShapeItem() {ID=9, Name = "Square Bar"},
                new MaterialShapeItem() {ID=10, Name = "Square Tube"},
                new MaterialShapeItem() {ID=11, Name = "Triangle"},
                new MaterialShapeItem() {ID=12, Name = "Slot"},
                new MaterialShapeItem() {ID=13, Name = "Irregular Shape"},
                new MaterialShapeItem() {ID=14, Name = "Others"},
            };
        }
    }
}
