using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Plotnic_2Dll
{
    /// <summary>
    /// Класс представялет заказ
    /// </summary>
    public class Order:Item
    {
        /// <summary>
        /// Заказаные изделия
        /// </summary>
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();
    }
}
