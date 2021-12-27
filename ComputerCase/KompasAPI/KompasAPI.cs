using System;
using System.Runtime.InteropServices;
using ComputerCase;
using Kompas6API5;
using Kompas6Constants3D;

namespace KompasAPI
{
    public class KompasAPI : IBuilderProgramAPI
    {
        private KompasObject _kompasObject;
        private ksDocument3D _document3D;
        private ksPart _part;
        private ksEntity _plan;
        private ksDocument2D _document2D;
        private ksSketchDefinition _sketchDefinition;
        private ksEntity _sketch;

        public KompasAPI()
        {
            
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

        public void CreateCircle(double diameter, double x, double y)
        {
            throw new System.NotImplementedException();
        }

        public void CreateRectangle(double startDotX, double startDotY, double endDotX, double endDotY)
        {
            _kompasObject = OpenKompas();
            _document3D = (ksDocument3D)_kompasObject.Document3D();
            _document3D.Create();
            _document2D = (ksDocument2D)_kompasObject.Document2D();
            _part = (ksPart)_document3D.GetPart((int)Part_Type.pTop_Part);
            // 1-интерфейс на плоскость XOY
            _plan = (ksEntity)_part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
            _sketch = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);
            _sketchDefinition = (ksSketchDefinition)_sketch.GetDefinition();
            _sketchDefinition.SetPlane(_plan);
            _sketch.Create();

            _document2D = (ksDocument2D)_sketchDefinition.BeginEdit();

            _document2D.ksLineSeg(startDotX, startDotY, endDotX, startDotY, 1);
            _document2D.ksLineSeg(startDotX, startDotY, startDotX, endDotY, 1);
            _document2D.ksLineSeg(startDotX, endDotX, endDotX, endDotY, 1);
            _document2D.ksLineSeg(endDotX, endDotY, endDotX, startDotY, 1);

            _sketchDefinition.EndEdit();
        }

        public void ExtrudeCutCircle(double depth)
        {
            throw new System.NotImplementedException();
        }

        public void ExtrudeRectangle(double depth)
        {
            throw new System.NotImplementedException();
        }
    }
}