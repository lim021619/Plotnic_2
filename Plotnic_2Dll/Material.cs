using System;
using System.Collections.Generic;
using System.Text;

namespace Plotnic_2Dll
{
    /// <summary>
    /// Каласс представляет материал
    /// </summary>
    public class Material:Item
    {
        /// <summary>
        /// Событие вызывается при изменения формафактора объекта
        /// </summary>
        event Action OnChangeFormFactor;
        private string breed = "Сосна";
        private string formFactor;
        private FormsFators formsFators;

        /// <summary>
        /// Тип материала. По умолчанию указано как "дерево"
        /// </summary>
        public string Type { get; set; } = "Дерево";
        /// <summary>
        /// Порода материала. По умолчанию указана "Сосна".
        /// </summary>
        public string Breed { get => breed; set { breed = value; OnpropertyChange(nameof(Breed)); } }

        /// <summary>
        /// Свойство предсталяющее в каком виде находится материл
        /// </summary>
        protected FormsFators FormsFators { get => formsFators; set { formsFators = value; OnChangeFormFactor?.Invoke(); }  }
        /// <summary>
        /// Свойство отражает название формафактора.
        /// </summary>
        public string FormFactor { get => formFactor; set { formFactor = value; OnpropertyChange(nameof(FormFactor)); } }
        public Material()
        {
            Noty = "Цена указана за 3 (три) метра.";
            OnChangeFormFactor += Material_OnChangeFormFactor;
        }

        private void Material_OnChangeFormFactor()
        {
            switch (formsFators)
            {
                       case FormsFators.Board: FormFactor = "Доска"; break;
                       case FormsFators.Timber: FormFactor = "Брус"; break;
                       case FormsFators.Slab: FormFactor = "Слэб"; break;
                       default: FormFactor = "Не указано"; break;
            }
        }

        /// <summary>
        /// Обработчик события цены. В данном случае Равняет себестоимость и тоговую цену.
        /// </summary>
        protected override void Item_OnPriceChanged()
        {
            if(CostPrice > 0)
            Price = CostPrice;
            else Price = 0;

            base.Item_OnPriceChanged();
        }
    }
}
