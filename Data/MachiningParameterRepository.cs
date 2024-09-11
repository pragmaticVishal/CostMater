using DetailsView.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CostMater.Data
{
    public static class MachiningParameterRepository
    {
        public static List<MachiningParameter> _lstMachiningParam;

        static MachiningParameterRepository()
        {
            if(_lstMachiningParam == null)
            {
                _lstMachiningParam = new List<MachiningParameter>();
                _lstMachiningParam = Populate();
            }
        }
        private static List<MachiningParameter> Populate()
        {
            List<MachiningParameter> lstMachiningParam = new List<MachiningParameter>();

            #region Mild Steel
            lstMachiningParam.Add(new MachiningParameter()
            {
                MachiningParameterId = 1,
                MaterialID = 4,
                MaterialName = "Mild Steel",
                ProcessTypeID = 1,
                ProcessTypeName = "Turning",
                ToolTypeID = 1,
                ToolTypeName = "HSS",
                ToolSurfaceID = 1,
                ToolSurfaceName = "Roughing",
                CuttingSpeed = 20,
                FeedRate = 0.3m,
                DepthOfCutEachPass = 2,
                DrillSize = 0,
                ThreadPitch = 0,
                MachiningCostPerHour = 300,
            });

            lstMachiningParam.Add(new MachiningParameter()
            {
                MachiningParameterId = 2,
                MaterialID = 4,
                MaterialName = "Mild Steel",
                ProcessTypeID = 1,
                ProcessTypeName = "Turning",
                ToolTypeID = 1,
                ToolTypeName = "HSS",
                ToolSurfaceID = 2,
                ToolSurfaceName = "Finishing",
                CuttingSpeed = 30,
                FeedRate = 0.1m,
                DepthOfCutEachPass = 0.5m,
                DrillSize = 0,
                ThreadPitch = 0,
                MachiningCostPerHour = 300,
            });

            lstMachiningParam.Add(new MachiningParameter()
            {
                MachiningParameterId = 3,
                MaterialID = 4,
                MaterialName = "Mild Steel",
                ProcessTypeID = 1,
                ProcessTypeName = "Turning",
                ToolTypeID = 2,
                ToolTypeName = "Carbide",
                ToolSurfaceID = 1,
                ToolSurfaceName = "Roughing",
                CuttingSpeed = 80,
                FeedRate = 0.4m,
                DepthOfCutEachPass = 3,
                DrillSize = 0,
                ThreadPitch = 0,
                MachiningCostPerHour = 300,
            });

            lstMachiningParam.Add(new MachiningParameter()
            {
                MachiningParameterId = 4,
                MaterialID = 4,
                MaterialName = "Mild Steel",
                ProcessTypeID = 1,
                ProcessTypeName = "Turning",
                ToolTypeID = 2,
                ToolTypeName = "Carbide",
                ToolSurfaceID = 2,
                ToolSurfaceName = "Finishing",
                CuttingSpeed = 100,
                FeedRate = 0.1m,
                DepthOfCutEachPass = 1,
                DrillSize = 0,
                ThreadPitch = 0,
                MachiningCostPerHour = 300,
            });

            lstMachiningParam.Add(new MachiningParameter()
            {
                MachiningParameterId = 5,
                MaterialID = 4,
                MaterialName = "Mild Steel",
                ProcessTypeID = 1,
                ProcessTypeName = "Turning",
                ToolTypeID = 3,
                ToolTypeName = "Stellite",
                ToolSurfaceID = 1,
                ToolSurfaceName = "Roughing",
                CuttingSpeed = 90,
                FeedRate = 0.35m,
                DepthOfCutEachPass = 2.5m,
                DrillSize = 0,
                ThreadPitch = 0,
                MachiningCostPerHour = 300,
            });

            lstMachiningParam.Add(new MachiningParameter()
            {
                MachiningParameterId = 6,
                MaterialID = 4,
                MaterialName = "Mild Steel",
                ProcessTypeID = 1,
                ProcessTypeName = "Turning",
                ToolTypeID = 3,
                ToolTypeName = "Stellite",
                ToolSurfaceID = 2,
                ToolSurfaceName = "Finishing",
                CuttingSpeed = 110,
                FeedRate = 0.15m,
                DepthOfCutEachPass = 1,
                DrillSize = 0,
                ThreadPitch = 0,
                MachiningCostPerHour = 300,
            });

            lstMachiningParam.Add(new MachiningParameter()
            {
                MachiningParameterId = 7,
                MaterialID = 4,
                MaterialName = "Mild Steel",
                ProcessTypeID = 5,
                ProcessTypeName = "Drilling",
                ToolTypeID = 1,
                ToolTypeName = "HSS",
                ToolSurfaceID = 0,
                ToolSurfaceName = "",
                CuttingSpeed = 20,
                FeedRate = 0.1m,
                DepthOfCutEachPass = 0,
                DrillSize = 3,
                ThreadPitch = 0,
                MachiningCostPerHour = 300,
            });

            lstMachiningParam.Add(new MachiningParameter()
            {
                MachiningParameterId = 8,
                MaterialID = 4,
                MaterialName = "Mild Steel",
                ProcessTypeID = 5,
                ProcessTypeName = "Drilling",
                ToolTypeID = 2,
                ToolTypeName = "Carbide",
                ToolSurfaceID = 0,
                ToolSurfaceName = "",
                CuttingSpeed = 30,
                FeedRate = 0.2m,
                DepthOfCutEachPass = 0,
                DrillSize = 3,
                ThreadPitch = 0,
                MachiningCostPerHour = 300,
            });

            lstMachiningParam.Add(new MachiningParameter()
            {
                MachiningParameterId = 9,
                MaterialID = 4,
                MaterialName = "Mild Steel",
                ProcessTypeID = 6,
                ProcessTypeName = "Threading",
                ToolTypeID = 1,
                ToolTypeName = "HSS",
                ToolSurfaceID = 0,
                ToolSurfaceName = "",
                CuttingSpeed = 10,
                FeedRate = 1,
                DepthOfCutEachPass = 0,
                DrillSize = 0,
                ThreadPitch = 1,
                MachiningCostPerHour = 300,
            });

            lstMachiningParam.Add(new MachiningParameter()
            {
                MachiningParameterId = 10,
                MaterialID = 4,
                MaterialName = "Mild Steel",
                ProcessTypeID = 6,
                ProcessTypeName = "Threading",
                ToolTypeID = 2,
                ToolTypeName = "Carbide",
                ToolSurfaceID = 0,
                ToolSurfaceName = "",
                CuttingSpeed = 10,
                FeedRate = 1,
                DepthOfCutEachPass = 0,
                DrillSize = 0,
                ThreadPitch = 1,
                MachiningCostPerHour = 300,
            });
            #endregion

            #region Stainless Steel
            lstMachiningParam.Add(new MachiningParameter()
            {
                MachiningParameterId = 11,
                MaterialID = 1,
                MaterialName = "Stainless Steel",
                ProcessTypeID = 1,
                ProcessTypeName = "Turning",
                ToolTypeID = 1,
                ToolTypeName = "HSS",
                ToolSurfaceID = 1,
                ToolSurfaceName = "Roughing",
                CuttingSpeed = 15,
                FeedRate = 0.2m,
                DepthOfCutEachPass = 1,
                DrillSize = 0,
                ThreadPitch = 0,
                MachiningCostPerHour = 300,
            });

            lstMachiningParam.Add(new MachiningParameter()
            {
                MachiningParameterId = 12,
                MaterialID = 1,
                MaterialName = "Stainless Steel",
                ProcessTypeID = 1,
                ProcessTypeName = "Turning",
                ToolTypeID = 1,
                ToolTypeName = "HSS",
                ToolSurfaceID = 2,
                ToolSurfaceName = "Finishing",
                CuttingSpeed = 20,
                FeedRate = 0.05m,
                DepthOfCutEachPass = 0.5m,
                DrillSize = 0,
                ThreadPitch = 0,
                MachiningCostPerHour = 300,
            });

            lstMachiningParam.Add(new MachiningParameter()
            {
                MachiningParameterId = 13,
                MaterialID = 1,
                MaterialName = "Stainless Steel",
                ProcessTypeID = 1,
                ProcessTypeName = "Turning",
                ToolTypeID = 2,
                ToolTypeName = "Carbide",
                ToolSurfaceID = 1,
                ToolSurfaceName = "Roughing",
                CuttingSpeed = 50,
                FeedRate = 0.3m,
                DepthOfCutEachPass = 2,
                DrillSize = 0,
                ThreadPitch = 0,
                MachiningCostPerHour = 300,
            });

            lstMachiningParam.Add(new MachiningParameter()
            {
                MachiningParameterId = 14,
                MaterialID = 1,
                MaterialName = "Stainless Steel",
                ProcessTypeID = 1,
                ProcessTypeName = "Turning",
                ToolTypeID = 2,
                ToolTypeName = "Carbide",
                ToolSurfaceID = 2,
                ToolSurfaceName = "Finishing",
                CuttingSpeed = 70,
                FeedRate = 0.1m,
                DepthOfCutEachPass = 0.5m,
                DrillSize = 0,
                ThreadPitch = 0,
                MachiningCostPerHour = 300,
            });

            lstMachiningParam.Add(new MachiningParameter()
            {
                MachiningParameterId = 15,
                MaterialID = 1,
                MaterialName = "Stainless Steel",
                ProcessTypeID = 1,
                ProcessTypeName = "Turning",
                ToolTypeID = 3,
                ToolTypeName = "Stellite",
                ToolSurfaceID = 1,
                ToolSurfaceName = "Roughing",
                CuttingSpeed = 60,
                FeedRate = 0.25m,
                DepthOfCutEachPass = 1.5m,
                DrillSize = 0,
                ThreadPitch = 0,
                MachiningCostPerHour = 300,
            });

            lstMachiningParam.Add(new MachiningParameter()
            {
                MachiningParameterId = 16,
                MaterialID = 1,
                MaterialName = "Stainless Steel",
                ProcessTypeID = 1,
                ProcessTypeName = "Turning",
                ToolTypeID = 3,
                ToolTypeName = "Stellite",
                ToolSurfaceID = 2,
                ToolSurfaceName = "Finishing",
                CuttingSpeed = 80,
                FeedRate = 0.1m,
                DepthOfCutEachPass = 0.5m,
                DrillSize = 0,
                ThreadPitch = 0,
                MachiningCostPerHour = 300,
            });

            lstMachiningParam.Add(new MachiningParameter()
            {
                MachiningParameterId = 17,
                MaterialID = 1,
                MaterialName = "Stainless Steel",
                ProcessTypeID = 5,
                ProcessTypeName = "Drilling",
                ToolTypeID = 1,
                ToolTypeName = "HSS",
                ToolSurfaceID = 0,
                ToolSurfaceName = "",
                CuttingSpeed = 12,
                FeedRate = 0.1m,
                DepthOfCutEachPass = 0,
                DrillSize = 2,
                ThreadPitch = 0,
                MachiningCostPerHour = 300,
            });

            lstMachiningParam.Add(new MachiningParameter()
            {
                MachiningParameterId = 18,
                MaterialID = 1,
                MaterialName = "Stainless Steel",
                ProcessTypeID = 5,
                ProcessTypeName = "Drilling",
                ToolTypeID = 2,
                ToolTypeName = "Carbide",
                ToolSurfaceID = 0,
                ToolSurfaceName = "",
                CuttingSpeed = 18,
                FeedRate = 0.15m,
                DepthOfCutEachPass = 0,
                DrillSize = 2,
                ThreadPitch = 0,
                MachiningCostPerHour = 300,
            });

            lstMachiningParam.Add(new MachiningParameter()
            {
                MachiningParameterId = 19,
                MaterialID = 1,
                MaterialName = "Stainless Steel",
                ProcessTypeID = 6,
                ProcessTypeName = "Threading",
                ToolTypeID = 1,
                ToolTypeName = "HSS",
                ToolSurfaceID = 0,
                ToolSurfaceName = "",
                CuttingSpeed = 8,
                FeedRate = 0.75m,
                DepthOfCutEachPass = 0,
                DrillSize = 0,
                ThreadPitch = 0.75m,
                MachiningCostPerHour = 300,
            });

            lstMachiningParam.Add(new MachiningParameter()
            {
                MachiningParameterId = 20,
                MaterialID = 1,
                MaterialName = "Stainless Steel",
                ProcessTypeID = 6,
                ProcessTypeName = "Threading",
                ToolTypeID = 2,
                ToolTypeName = "Carbide",
                ToolSurfaceID = 0,
                ToolSurfaceName = "",
                CuttingSpeed = 15,
                FeedRate = 0.75m,
                DepthOfCutEachPass = 0,
                DrillSize = 0,
                ThreadPitch = 0.75m,
                MachiningCostPerHour = 300,
            });
            #endregion

            #region Aluminium
            lstMachiningParam.Add(new MachiningParameter()
            {
                MachiningParameterId = 21,
                MaterialID = 5,
                MaterialName = "Aluminium",
                ProcessTypeID = 1,
                ProcessTypeName = "Turning",
                ToolTypeID = 1,
                ToolTypeName = "HSS",
                ToolSurfaceID = 1,
                ToolSurfaceName = "Roughing",
                CuttingSpeed = 250,
                FeedRate = 0.4m,
                DepthOfCutEachPass = 3,
                DrillSize = 0,
                ThreadPitch = 0,
                MachiningCostPerHour = 300,
            });

            lstMachiningParam.Add(new MachiningParameter()
            {
                MachiningParameterId = 22,
                MaterialID = 5,
                MaterialName = "Aluminium",
                ProcessTypeID = 1,
                ProcessTypeName = "Turning",
                ToolTypeID = 1,
                ToolTypeName = "HSS",
                ToolSurfaceID = 2,
                ToolSurfaceName = "Finishing",
                CuttingSpeed = 300,
                FeedRate = 0.2m,
                DepthOfCutEachPass = 1,
                DrillSize = 0,
                ThreadPitch = 0,
                MachiningCostPerHour = 300,
            });

            lstMachiningParam.Add(new MachiningParameter()
            {
                MachiningParameterId = 23,
                MaterialID = 5,
                MaterialName = "Aluminium",
                ProcessTypeID = 1,
                ProcessTypeName = "Turning",
                ToolTypeID = 2,
                ToolTypeName = "Carbide",
                ToolSurfaceID = 1,
                ToolSurfaceName = "Roughing",
                CuttingSpeed = 500,
                FeedRate = 0.5m,
                DepthOfCutEachPass = 4,
                DrillSize = 0,
                ThreadPitch = 0,
                MachiningCostPerHour = 300,
            });

            lstMachiningParam.Add(new MachiningParameter()
            {
                MachiningParameterId = 24,
                MaterialID = 5,
                MaterialName = "Aluminium",
                ProcessTypeID = 1,
                ProcessTypeName = "Turning",
                ToolTypeID = 2,
                ToolTypeName = "Carbide",
                ToolSurfaceID = 2,
                ToolSurfaceName = "Finishing",
                CuttingSpeed = 700,
                FeedRate = 0.3m,
                DepthOfCutEachPass = 2,
                DrillSize = 0,
                ThreadPitch = 0,
                MachiningCostPerHour = 300,
            });

            lstMachiningParam.Add(new MachiningParameter()
            {
                MachiningParameterId = 25,
                MaterialID = 5,
                MaterialName = "Aluminium",
                ProcessTypeID = 1,
                ProcessTypeName = "Turning",
                ToolTypeID = 3,
                ToolTypeName = "Stellite",
                ToolSurfaceID = 1,
                ToolSurfaceName = "Roughing",
                CuttingSpeed = 450,
                FeedRate = 0.5m,
                DepthOfCutEachPass = 4,
                DrillSize = 0,
                ThreadPitch = 0,
                MachiningCostPerHour = 300,
            });

            lstMachiningParam.Add(new MachiningParameter()
            {
                MachiningParameterId = 26,
                MaterialID = 5,
                MaterialName = "Aluminium",
                ProcessTypeID = 1,
                ProcessTypeName = "Turning",
                ToolTypeID = 3,
                ToolTypeName = "Stellite",
                ToolSurfaceID = 2,
                ToolSurfaceName = "Finishing",
                CuttingSpeed = 600,
                FeedRate = 0.25m,
                DepthOfCutEachPass = 2,
                DrillSize = 0,
                ThreadPitch = 0,
                MachiningCostPerHour = 300,
            });

            lstMachiningParam.Add(new MachiningParameter()
            {
                MachiningParameterId = 27,
                MaterialID = 5,
                MaterialName = "Aluminium",
                ProcessTypeID = 5,
                ProcessTypeName = "Drilling",
                ToolTypeID = 1,
                ToolTypeName = "HSS",
                ToolSurfaceID = 0,
                ToolSurfaceName = "",
                CuttingSpeed = 250,
                FeedRate = 0.2m,
                DepthOfCutEachPass = 0,
                DrillSize = 2,
                ThreadPitch = 0,
                MachiningCostPerHour = 300,
            });

            lstMachiningParam.Add(new MachiningParameter()
            {
                MachiningParameterId = 28,
                MaterialID = 5,
                MaterialName = "Aluminium",
                ProcessTypeID = 5,
                ProcessTypeName = "Drilling",
                ToolTypeID = 2,
                ToolTypeName = "Carbide",
                ToolSurfaceID = 0,
                ToolSurfaceName = "",
                CuttingSpeed = 300,
                FeedRate = 0.3m,
                DepthOfCutEachPass = 0,
                DrillSize = 2,
                ThreadPitch = 0,
                MachiningCostPerHour = 300,
            });

            lstMachiningParam.Add(new MachiningParameter()
            {
                MachiningParameterId = 29,
                MaterialID = 5,
                MaterialName = "Aluminium",
                ProcessTypeID = 6,
                ProcessTypeName = "Threading",
                ToolTypeID = 1,
                ToolTypeName = "HSS",
                ToolSurfaceID = 0,
                ToolSurfaceName = "",
                CuttingSpeed = 50,
                FeedRate = 1.5m,
                DepthOfCutEachPass = 0,
                DrillSize = 0,
                ThreadPitch = 1.5m,
                MachiningCostPerHour = 300,
            });

            lstMachiningParam.Add(new MachiningParameter()
            {
                MachiningParameterId = 30,
                MaterialID = 5,
                MaterialName = "Aluminium",
                ProcessTypeID = 6,
                ProcessTypeName = "Threading",
                ToolTypeID = 2,
                ToolTypeName = "Carbide",
                ToolSurfaceID = 0,
                ToolSurfaceName = "",
                CuttingSpeed = 100,
                FeedRate = 1.5m,
                DepthOfCutEachPass = 0,
                DrillSize = 0,
                ThreadPitch = 1.5m,
                MachiningCostPerHour = 300,
            });
            #endregion

            return lstMachiningParam;
        }

        public static List<MachiningParameter> GetAll()
        {
            return _lstMachiningParam;
        }

        public static MachiningParameter GetMachiningParameter(Process machiningOperation)
        {
            MachiningParameter machiningParameter = null;
            List<int> lstTurningOpsId = new List<int>() { 1, 2, 3, 4 };
            List<int> lstSSMaterialId = new List<int>() { 1, 2, 3 };
            int materialId = lstSSMaterialId.Contains(machiningOperation.Component.MaterialID) ? 1 : machiningOperation.Component.MaterialID;
            int processTypeId = lstTurningOpsId.Contains(machiningOperation.ProcessTypeID) ? 1 : machiningOperation.ProcessTypeID;
            int toolsurfaceId = machiningOperation.ToolSurfaceID;
            int tooltypeId = machiningOperation.ToolTypeID;

            machiningParameter = _lstMachiningParam.Find(x => (x.MaterialID == materialId && x.ProcessTypeID == processTypeId && x.ToolTypeID == tooltypeId
            && x.ToolSurfaceID == toolsurfaceId));

            if(machiningParameter == null)
            {
                machiningParameter = new MachiningParameter();
            }

            return machiningParameter;
        }
    }
}
