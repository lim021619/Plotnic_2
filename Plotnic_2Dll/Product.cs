using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Plotnic_2Dll
{
    /// <summary>
    /// Класс представляющий готовое изделие
    /// </summary>
    public class Product : Item
    {
              
        private string color;
        
        /// <summary>
        /// Цвет
        /// </summary>
        public string Color { get => color; set { color = value; OnpropertyChange(nameof(Color)); } }
        /// <summary>
        /// Компоненты готового изделия
        /// </summary>
        public ObservableCollection<Component> Components { get; set; } = new ObservableCollection<Component>();

        /// <summary>
        /// Родительский объект.(Связь один ко многим).
        /// </summary>
        public Order Order { get; set; } = new Order();
        /// <summary>
        /// Индентификационный номер родительского объекта.(Связь один ко многим).
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Получить количество компонентов.
        /// </summary>
        /// <returns>Возвращает кол-во компонентов</returns>
        public int? GetNumberComponents() => Components?.Count;

    }
}
