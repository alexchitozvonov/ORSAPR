using System;
using System.Runtime.InteropServices;
using Kompas6API5;

namespace TrafficConeBuilder
{
    /// <summary>
    /// Представляет методы и свойства для управления подключением к приложению
    /// </summary>
    public class KompasConnector
    {
        /// <summary>
        /// Абстракция над объектом приложения
        /// </summary>
        public KompasApplication Application { get; private set; }

        /// <summary>
        /// Открыто ли приложение
        /// </summary>
        public bool IsOpen { get; private set; }

        /// <summary>
        /// Открыть компас
        /// </summary>
        /// <returns>абстракция над объектом приложения</returns>
        public KompasApplication Open()
        {
            if (IsOpen)
            {
                throw new InvalidOperationException("Приложение уже запущено");
            }

            IsOpen = true;

            var type = Type.GetTypeFromProgID("KOMPAS.Application.5");
            var kompasObject = (KompasObject)Activator.CreateInstance(type);

            if (kompasObject == null)
            {
                throw new ArgumentNullException(
                    "Произошла ошибка при подключении к приложению Компас");
            }

            kompasObject.Visible = true;
            kompasObject.ActivateControllerAPI();

            return Application = new KompasApplication(kompasObject);
        }

        /// <summary>
        /// Закрыть компас
        /// </summary>
        public void Close()
        {
            if (!IsOpen)
            {
                throw new InvalidOperationException("Приложение не запущено");
            }

            try
            {
                Application.Kompas.Quit();
            }
            catch (COMException exception)
            {
                //Сработает в случае если компас был закрыт вручную
            }
            finally
            {
                IsOpen = false;
                Application = null;
            }

        }
    }
}