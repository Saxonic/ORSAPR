using System;
using System.Runtime.InteropServices;
using ComputerCase;
using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;

namespace KompasAPI
{
    /// <summary>
    /// Класс, реализующий построение корпуса, используя API компаса
    /// </summary>
    public class KompasAPI : IBuilderProgramAPI
    {
        /// <summary>
        /// Объект интерфейса API КОМПАС-3D
        /// </summary>
        private KompasObject _kompasObject;
        
        /// <summary>
        /// Компонент сборки
        /// </summary>
        private ksPart _part;
        
        /// <summary>
        /// Толщина корпуса
        /// </summary>
        private const double CaseThickness = 1;

        //TODO: XML
        public KompasAPI()
        {
        }

        //TODO: XML
        public void OpenAPI()
        {
            _kompasObject = OpenKompas();
            var document3D = (ksDocument3D)_kompasObject.Document3D();
            document3D.Create();
            _part = (ksPart)document3D.GetPart((int)Part_Type.pTop_Part);
        }

        /// <summary>
        /// Создать днище корпуса
        /// </summary>
        /// <param name="length">Длина корпуса</param>
        /// <param name="width">Ширина корпуса</param>
        public void CreateBottom(double length, double width)
        {
            var sketch = CreateSketch(Obj3dType.o3d_planeXOY);
            var rectangleParameters = GetRectangleParameters(0, 0, length, width);
            var documents2d = (Document2D)sketch.BeginEdit();
            documents2d.ksRectangle(rectangleParameters);
            sketch.EndEdit();
            Extrude(CaseThickness,sketch);
        }

        /// <summary>
        /// Создать стенки корпуса
        /// </summary>
        /// <param name="length">Длина корпуса</param>
        /// <param name="width">Ширина корпуса</param>
        /// <param name="height">Высота корпуса</param>
        /// <param name="fansDiameter">Диаметр отверствий под верхние вентиляторы</param>
        /// <param name="fansCount">Кол-во верхних вентиляторов</param>
        public void CreateSides(double length, double width, double height, double fansDiameter,int fansCount)
        {
            //задняя стенка
            CreatePlate(0, 0, CaseThickness, width, height, Obj3dType.o3d_planeXOY);
            //боковая стенка
            CreatePlate(0, 1, length-1, CaseThickness, height, Obj3dType.o3d_planeXOY);
            //передняя стенка
            CreatePlate(0, length, CaseThickness, width, height, Obj3dType.o3d_planeXOY);
            CreateFansHoles(width,fansDiameter,fansCount,15,Obj3dType.o3d_planeXOZ,-length);
        }

        /// <summary>
        /// Создать крышу
        /// </summary>
        /// <param name="length">Длина корпуса</param>
        /// <param name="width">Ширина корпуса</param>
        /// <param name="height">Высота корпуса</param>
        /// <param name="upperFansDiameter">Диаметр отверствий под передние вентиляторы</param>
        /// <param name="fansCount">>Кол-во передних вентиляторов</param>
        public void CreteRoof(double length, double width,double height, double upperFansDiameter,int fansCount)
        {
            CreatePlate(0,0,length,width,CaseThickness,Obj3dType.o3d_planeXOY,-height);
            CreateFansHoles(width,upperFansDiameter, fansCount, 5, Obj3dType.o3d_planeXOY,-height,false);
        }

        /// <summary>
        /// Создать прямоугольную стенку корпуса
        /// </summary>
        /// <param name="startX">Начальная точка прямоугольника</param>
        /// <param name="startY">Конечная точка прямоугольника</param>
        /// <param name="length">Длина прямоугольника</param>
        /// <param name="width">Щирина прямоугольника</param>
        /// <param name="thickness">Толщина прямоугольника</param>
        /// <param name="planeType">Плоскость, в которой будет строиться стенка</param>
        /// <param name="offset">сдвиг плоскости</param>
        private void CreatePlate(double startX, double startY, double length, double width, double thickness,
            Obj3dType planeType, double offset = 0)
        {
            var sketch = CreateSketch(planeType,offset);
            var rectangleParameters = GetRectangleParameters(startX, startY, length, width);
            var documents2d = (Document2D)sketch.BeginEdit();
            documents2d.ksRectangle(rectangleParameters);
            sketch.EndEdit();
            Extrude(thickness,sketch);
        }

        /// <summary>
        /// Создать отверстия под вентиляторы
        /// </summary>
        /// <param name="width">Ширина корпуса</param>
        /// <param name="diameter">Диаметр отверстия</param>
        /// <param name="count">Кол-во отверстий</param>
        /// <param name="indent">Отсутп между вентиляторами</param>
        /// <param name="planeType">Плоскость, в которой будет строиться отверстие</param>
        /// <param name="offset">Свдиг плоскости</param>
        /// <param name="isReversed">Инвертировать ли Y(в зависимости от того, в каком направлении растет ось Y)</param>
        private void CreateFansHoles(double width,double diameter, int count, double indent,
            Obj3dType planeType,double offset = 0,bool isReversed = true)
        {
            var centerY = isReversed? -(indent+diameter/2) : indent+diameter/2;
            var centerX = width / 2;
            var sketch = CreateSketch(planeType,offset);
            var document2d = (Document2D)sketch.BeginEdit();
            for (var i = 0; i < count; i++)
            {
                document2d.ksCircle(centerX, centerY, diameter/2, 1);
                centerY -= isReversed ? indent + diameter : -(indent+diameter);
            }
            sketch.EndEdit();
            Cut(1,sketch);
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
        private void Cut(double depth,ksSketchDefinition sketch, bool side = false)
        {
            var cutExtrusionEntity = (ksEntity)_part.NewEntity((short)ksObj3dTypeEnum.o3d_cutExtrusion);
            var cutExtrusionDef = (ksCutExtrusionDefinition)cutExtrusionEntity.GetDefinition();

            cutExtrusionDef.SetSideParam(side, (short)End_Type.etBlind, depth);
            cutExtrusionDef.directionType = side 
                ? (short)Direction_Type.dtNormal 
                : (short)Direction_Type.dtReverse;
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