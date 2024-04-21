using System;
using System.Collections.Generic;
using System.Text;

namespace Plotnic_2Dll
{   /// <summary>
    /// Класс представляет фурнитуру
    /// </summary>
    public class Furniture:Component
    {
        private string model;
        private string brand;

        /// <summary>
        /// Название модели
        /// </summary>
        public string Model { get => model; set { model = value; OnpropertyChange(nameof(Model)); } }
        /// <summary>
        /// Название Марки
        /// </summary>
        public string Brand { get => brand; set { brand = value; OnpropertyChange(nameof(Brand)); } }
    }
}
