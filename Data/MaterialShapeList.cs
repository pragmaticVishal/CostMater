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
                new MaterialShapeItem() {ID=2, Name = "Angle"},
                new MaterialShapeItem() {ID=3, Name = "Round"},
                new MaterialShapeItem() {ID=4, Name = "Cylindrical"},
                new MaterialShapeItem() {ID=5, Name = "Rectangular"},
                new MaterialShapeItem() {ID=6, Name = "Square"},
                new MaterialShapeItem() {ID=7, Name = "Triangle"},
                new MaterialShapeItem() {ID=8, Name = "Slot"},
                new MaterialShapeItem() {ID=9, Name = "Irregular Polygon"},
                new MaterialShapeItem() {ID=10, Name = "Others"},
                new MaterialShapeItem() {ID=11, Name = "Trapezoid"},
                new MaterialShapeItem() {ID=12, Name = "Pentagon"},
                new MaterialShapeItem() {ID=13, Name = "Hexagon"},
                new MaterialShapeItem() {ID=14, Name = "Octagon"},
                new MaterialShapeItem() {ID=15, Name = "Ellipsis or Oval"},
            };
        }
    }
}
