using System;
using System.Runtime.InteropServices;
using ComputerCase;
using Inventor;

namespace InventorAPI
{
    //TODO: XML
    /// <summary>
    /// Класс, осуществляющий построение корпуса в программе Inventor
    /// </summary>
    public class InventorAPI : IBuilderProgramAPI
    {
        /// <summary>
        /// Ссылка на работу с документацией АПИ.
        /// </summary>
        private PartDocument _partDoc;

        /// <summary>
        /// Ссылка на приложение Inventor.
        /// </summary>
        private Application _invApp;

        /// <summary>
        /// Описание документа.
        /// </summary>
        private PartComponentDefinition _partDefinition;

        /// <summary>
        /// Геометрия приложения.
        /// </summary>
        private TransientGeometry _transientGeometry;

        /// <summary>
        /// Толщина корпуса
        /// </summary>
        private const double CASE_THICKNESS = 1;

        /// <summary>
        /// Кол-во миллиметров в одном сантиметре
        /// </summary>
        private const double CENTIMETER = 10;
        
        /// <inheritdoc/>
        public void OpenAPI()
        {
            _invApp = null;
            try
            {
                _invApp = (Application)Marshal.GetActiveObject("Inventor.Application");
            }
            catch (COMException)
            {
                try
                {
                    //Если не получилось перехватить приложение - выкинется исключение на то,
                    //что такого активного приложения нет. Попробуем создать приложение вручную.
                    var invAppType = Type.GetTypeFromProgID("Inventor.Application");

                    _invApp = (Application)Activator.CreateInstance(invAppType);
                    _invApp.Visible = true;
                }
                catch (Exception)
                {
                    throw new ApplicationException(@"Не получилось запустить Inventor.");
                }
            }

            // В открытом приложении создаем документ
            _partDoc = (PartDocument)_invApp.Documents.Add
            (DocumentTypeEnum.kPartDocumentObject,
                _invApp.FileManager.GetTemplateFile
                (DocumentTypeEnum.kPartDocumentObject,
                    SystemOfMeasureEnum.kMetricSystemOfMeasure));

            // Описание документа
            _partDefinition = _partDoc.ComponentDefinition;
            // Инициализация метода геометрии
            _transientGeometry = _invApp.TransientGeometry;
        }

        /// <inheritdoc/>
        public void CreateBottom(double length, double width)
        {
            CreatePlate(0,0,length,width,1,2);
        }
        
        //TODO: RSDN
        /// <inheritdoc/>
        public void CreateSides(double length, double width, double height, 
            double fansDiameter, int fansCount)
        {
            //задняя стенка
            CreatePlate(0, 0, CASE_THICKNESS, width, height, 2);
            //боковая стенка
            CreatePlate(0, 0, length-1, CASE_THICKNESS, height, 2);
            //передняя стенка
            CreatePlate(length-1, 0, CASE_THICKNESS, width, height, 2);
            CreateFansHoles(width,fansDiameter,fansCount,15,
                1,-length,false);
        }

        //TODO: RSDN
        /// <inheritdoc/>
        public void CreteRoof(double length, double width, double height,
            double upperFansDiameter, int fansCount)
        {
            CreatePlate(0,0,length,width,CASE_THICKNESS,2,height);
            CreateFansHoles(width,upperFansDiameter, fansCount, 5, 
                2,height,false);
        }
        
        /// <summary>
        /// Создает новый эскиз на рабочей плоскости.
        /// </summary>
        /// <param name="n">1 - ZY; 2 - ZX; 3 - XY.</param>
        /// <param name="offset">Расстояние от поверхности.</param>
        /// <returns>Новый эскиз.</returns>
        private PlanarSketch CreateSketch(int n, double offset = 0)
        {
            var mainPlane = _partDefinition.WorkPlanes[n];
            var offsetPlane = _partDefinition.WorkPlanes.AddByPlaneAndOffset(
                mainPlane, offset/CENTIMETER);
            offsetPlane.Visible = false;
            var sketch = _partDefinition.Sketches.Add(offsetPlane);
            return sketch;
        }

        //TODO: RSDN
        /// <summary>
        /// Создать прямоугольную стенку корпуса
        /// </summary>
        /// <param name="startX">Начальная точка прямоугольника</param>
        /// <param name="startY">Конечная точка прямоугольника</param>
        /// <param name="length">Длина прямоугольника</param>
        /// <param name="width">Щирина прямоугольника</param>
        /// <param name="thickness">Толщина прямоугольника</param>
        /// <param name="n">1 - ZY; 2 - ZX; 3 - XY.</param>
        /// <param name="offset">сдвиг плоскости</param>
        private void CreatePlate(double startX, double startY, double length,
            double width, double thickness, int n, double offset = 0)
        {
            var sketch = CreateSketch(n,offset);
            var point1 = _transientGeometry.CreatePoint2d
                (startX/CENTIMETER, startY/CENTIMETER);
            var point2 = _transientGeometry.CreatePoint2d
                ((startX+length)/CENTIMETER, (startY+width)/CENTIMETER);
            sketch.SketchLines.AddAsTwoPointRectangle(point1, point2);
            Extrude(sketch,thickness,PartFeatureOperationEnum.kJoinOperation);
        }

        /// <summary>
        /// Выдавливание.
        /// </summary>
        /// <param name="sketch">Эскиз.</param>
        /// <param name="distance">Значение, на которое происходит выдавливание.</param>
        /// <param name="operationType">Тип операции</param>
        private void Extrude(PlanarSketch sketch, double distance,PartFeatureOperationEnum operationType)
        {
            sketch.Visible = false;
            var sketchProfile = sketch.Profiles.AddForSolid();
            var extrudeDef =
                _partDefinition.Features.ExtrudeFeatures
                    .CreateExtrudeDefinition(sketchProfile, operationType);
            extrudeDef.SetDistanceExtent(distance/CENTIMETER,
                PartFeatureExtentDirectionEnum.kPositiveExtentDirection);
            var extrude = _partDefinition.Features.ExtrudeFeatures.Add(extrudeDef);
            var objectCollection = _invApp.TransientObjects.CreateObjectCollection();
            objectCollection.Add(extrude);
        }
        
        //TODO: RSDN
        /// <summary>
        /// Создать отверстия под вентиляторы
        /// </summary>
        /// <param name="width">Ширина корпуса</param>
        /// <param name="diameter">Диаметр отверстия</param>
        /// <param name="count">Кол-во отверстий</param>
        /// <param name="indent">Отсутп между вентиляторами</param>
        /// <param name="planeType">Плоскость, в которой будет строиться отверстие</param>
        /// <param name="offset">Свдиг плоскости</param>
        /// <param name="isReversed">Инвертировать ли Y(в зависимости от
        /// того, в каком направлении растет ось Y)</param>
        private void CreateFansHoles(double width,double diameter, int count, double indent,
            int planeType,double offset = 0,bool isReversed = true)
        {
            var centerX = isReversed
                ? -(indent+diameter / 2) / CENTIMETER 
                : (indent+diameter / 2) / CENTIMETER;
            var centerY = width / 2 / CENTIMETER;
            var sketch = CreateSketch(planeType,offset);
            for (var i = 0; i < count; i++)
            {
                var point = _transientGeometry.CreatePoint2d
                    (centerX, centerY);
                sketch.SketchCircles.AddByCenterRadius(point, diameter / 2/CENTIMETER);
                centerX -= isReversed 
                    ? (indent + diameter)/CENTIMETER 
                    : -(indent+diameter)/CENTIMETER;
            }
            Extrude(sketch,1,PartFeatureOperationEnum.kCutOperation);
        }
    }
}