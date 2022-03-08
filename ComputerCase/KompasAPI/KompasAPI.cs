using System;
using System.Runtime.InteropServices;
using ComputerCase;
using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;

namespace KompasAPI
{
    public class KompasAPI : IBuilderProgramAPI
    {
        private KompasObject _kompasObject;
        private ksDocument3D _document3D;
        private ksPart _part;
        private const double CaseThickness = 1;

        public KompasAPI()
        {
            
        }

        public void CreateBottom(double length, double width)
        {
            _kompasObject = OpenKompas();
            _document3D = (ksDocument3D)_kompasObject.Document3D();
            _document3D.Create();
            _part = (ksPart)_document3D.GetPart((int)Part_Type.pTop_Part);
            var sketch = CreateSketch(Obj3dType.o3d_planeXOY);
            var rectangleParameters = GetRectangleParameters(0, 0, length, width);
            var documents2d = (Document2D)sketch.BeginEdit();
            documents2d.ksRectangle(rectangleParameters);
            sketch.EndEdit();
            Extrude(CaseThickness,sketch);
        }

        public void CreateSides(double length, double width, double height, double fansDiameter,double fansCount)
        {
            //задняя стенка
            CreatePlate(0, 0, CaseThickness, width, height, Obj3dType.o3d_planeXOY);
            //боковая стенка
            CreatePlate(0, 1, length-1, CaseThickness, height, Obj3dType.o3d_planeXOY);
            //передняя стенка
            CreatePlate(0, length, CaseThickness, width, height, Obj3dType.o3d_planeXOY);
        }

        public void CreteRoof(double length, double width, double upperFansDiameter)
        {
            throw new NotImplementedException();
        }

        private void CreatePlate(double startX, double startY, double length, double width, double height,
            Obj3dType planeType)
        {
            var sketch = CreateSketch(planeType);
            var rectangleParameters = GetRectangleParameters(startX, startY, length, width);
            var documents2d = (Document2D)sketch.BeginEdit();
            documents2d.ksRectangle(rectangleParameters);
            sketch.EndEdit();
            Extrude(height,sketch);
        }

        /// <summary>
        /// Создать эскиз
        /// </summary>
        /// <param name="planeType"></param>
        /// <param name="offset">Величина смещения</param>
        /// <returns></returns>
        private ksSketchDefinition CreateSketch(Obj3dType planeType,double offset = 0)
        {
            var plan = (ksEntity)_part.GetDefaultEntity((short)planeType);
            var sketch = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);
            var sketchDefinition = (ksSketchDefinition)sketch.GetDefinition();
            sketchDefinition.SetPlane(plan);
            if (offset != 0)
            {
                var offsetEntity = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_planeOffset);
                var offsetDef = (ksPlaneOffsetDefinition)offsetEntity
                    .GetDefinition(); 
                offsetDef.SetPlane(plan);
                offsetDef.offset = offset;
                offsetDef.direction = false;
                offsetEntity.Create();
                sketchDefinition.SetPlane(offsetEntity);
            }
            sketch.Create();
            return sketchDefinition;
        }

        /// <summary>
        /// Вырезать указаный эскиз
        /// </summary>
        /// <param name="depth"></param>
        /// <param name="sketch"></param>
        /// <param name="side"></param>
        private void Cut(double depth,ksSketchDefinition sketch, bool side = true)
        {
            var cutExtrusionEntity = (ksEntity)_part.NewEntity((short)ksObj3dTypeEnum.o3d_cutExtrusion);
            var cutExtrusionDef = (ksCutExtrusionDefinition)cutExtrusionEntity.GetDefinition();

            cutExtrusionDef.SetSideParam(side, (short)End_Type.etBlind, depth);
            cutExtrusionDef.directionType = side ? (short)Direction_Type.dtNormal : (short)Direction_Type.dtReverse;
            cutExtrusionDef.cut = true;
            cutExtrusionDef.SetSketch(sketch);

            cutExtrusionEntity.Create();
        }

        /// <summary>
        /// Выдавить указаный эскиз
        /// </summary>
        /// <param name="depth"></param>
        /// <param name="sketch"></param>
        /// <param name="side"></param>
        private void Extrude(double depth, ksSketchDefinition sketch, bool side = true)
        {
            var extrusionEntity = (ksEntity)_part.NewEntity(
                (short)ksObj3dTypeEnum.o3d_bossExtrusion);
            var extrusionDef = (ksBossExtrusionDefinition)extrusionEntity
                .GetDefinition();

            extrusionDef.SetSideParam(side, (short)End_Type.etBlind, depth);
            extrusionDef.directionType = side ? (short)Direction_Type.dtNormal : (short)Direction_Type.dtReverse;
            extrusionDef.SetSketch(sketch);
            extrusionEntity.Create();
        }
        
        /// <summary>
        /// Получить параметры для создания прямоугольника
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        private ksRectangleParam GetRectangleParameters(double x, double y,
            double height, double width)
        {
            var rectangleParam =
                (ksRectangleParam)_kompasObject.GetParamStruct
                    ((short)StructType2DEnum.ko_RectangleParam);
            rectangleParam.x = x;
            rectangleParam.y = y;
            rectangleParam.height = height;
            rectangleParam.width = width;
            rectangleParam.style = 1;
            return rectangleParam;
        }
        
        /// <summary>
        /// Открытие Компас
        /// </summary>
        /// <returns>Возвращает указатель на Компас</returns>
        private KompasObject OpenKompas()
        {
            if (!GetActiveKompass(out var kompas))
            {
                CreateActiveKompas(out kompas);
            }

            kompas.Visible = true;
            kompas.ActivateControllerAPI();
            return kompas;
        }
        
        /// <summary>
        /// Открытие Компас.
        /// </summary>
        /// <param name="kompasObject">Объект Компас</param>
        /// <returns>Возвращает указатель на Компас</returns>
        private bool CreateActiveKompas(out KompasObject kompasObject)
        {
            try
            {
                Type type = Type.GetTypeFromProgID("KOMPAS.Application.5");
                kompasObject = (KompasObject)Activator.CreateInstance(type);
                return true;
            }
            catch (COMException)
            {
                throw new COMException("Failed to open Kompas");
            }
        }

        /// <summary>
        /// Получение открытого Компаса.
        /// </summary>
        /// <param name="kompasObject">Объект Компаса.</param>
        /// <returns>Возвращает указатель на Компас</returns>
        private bool GetActiveKompass(out KompasObject kompasObject)
        {
            try
            {
                kompasObject = (KompasObject)Marshal.GetActiveObject("KOMPAS.Application.5");
                return true;
            }
            catch (COMException)
            {
                kompasObject = null;
                return false;
            }
        }
    }
}