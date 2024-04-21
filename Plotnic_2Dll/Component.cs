using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plotnic_2Dll
{
    /// <summary>
    /// Класс преставляет собой компонент
    /// </summary>
    public class Component:Item
    {
        private double weight;
        private double height;
        private double thinckness;

        /// <summary>
        /// Ширина
        /// </summary>
        public double Weight { get => weight; set { weight = value; OnpropertyChange(nameof(Weight)); } }
        /// <summary>
        /// Длина
        /// </summary>
        public double Height { get => height; set { height = value; OnpropertyChange(nameof(Height)); } }   
        /// <summary>
        /// Толщина
        /// </summary>
        public double Thinckness { get => thinckness; set { thinckness = value; OnpropertyChange(nameof(Thinckness)); } }

        public Product Product { get; set; } = new Product();
        public int ProductId { get; set; }

        
    }
}
