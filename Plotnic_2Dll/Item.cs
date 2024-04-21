using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Plotnic_2Dll
{
    /// <summary>
    /// Базовый класс для всех элеметов будущего изделия.
    /// </summary>
    public class Item : INotifyPropertyChanged
    {
        /// <summary>
        /// Событие вызывается когда меняется цена
        /// </summary>
        protected event Action OnPriceChanged;
        /// <summary>
        /// Событие вызыввается когда меняется процент скидки
        /// </summary>
        protected event Action OnDiscount;
        

        public event PropertyChangedEventHandler PropertyChanged;

        private string name;
        private decimal price;
        private string noty;
        private decimal costPrice;
        private int procentWorking;
        private int procent_difficulty_Of_Work;
        private int procentDiscount;
        private decimal minPrice;
        private decimal discont;

        public void OnpropertyChange(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public int Id { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public string Name   { get => name; set { name = value; OnpropertyChange(nameof(Name)); } }
        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { get => price; set { price = value; OnPriceChanged?.Invoke(); } }
        /// <summary>
        /// Себестоимость
        /// </summary>
        public decimal CostPrice { get => costPrice; set { costPrice = value; MinPrice = value; OnpropertyChange(nameof(CostPrice)); } }
        /// <summary>
        /// Заметка
        /// </summary>
        public string Noty { get => noty; set { noty = value;OnpropertyChange(nameof(Noty)); } }

        /// <summary>
        /// Наценка Процент за работу
        /// </summary>
        public int ProcentWorking { get => procentWorking; set { procentWorking = value; OnpropertyChange(nameof(ProcentWorking)); } }
        
        /// <summary>
        /// Наценка в связи со сложностью работы
        /// </summary>
        public int Procent_Difficulty_Of_Work { get => procent_difficulty_Of_Work; set { procent_difficulty_Of_Work = value; OnpropertyChange(nameof(Procent_Difficulty_Of_Work)); } }
        /// <summary>
        /// Процент скидки
        /// </summary>
        public int ProcentDiscount { get => procentDiscount; set { procentDiscount = value; OnpropertyChange(nameof(ProcentDiscount)); OnDiscount?.Invoke(); } }
        /// <summary>
        /// Скидка
        /// </summary>
        public decimal Discont { get => discont; set { discont = value; OnpropertyChange(nameof(Discont)); } }
       /// <summary>
       /// Минимальная стоимсть
       /// </summary>
        public decimal MinPrice { get => minPrice; set { minPrice = value; OnpropertyChange(nameof(MinPrice)); } }

        public Item()
        {
            OnPriceChanged += Item_OnPriceChanged;
            OnDiscount += Item_OnDiscount;
        }

        /// <summary>
        /// Метод обрабатываюий событие изменение проецена скидки. Задаёт скидку от цены в свойство Discount.
        /// </summary>
        protected virtual void Item_OnDiscount()
        {
            Discont = CalculationProcentInSum(Price, ProcentDiscount);
        }

        protected virtual void Item_OnPriceChanged()
        {
            OnpropertyChange(nameof(Price));
        }
        /// <summary>
        /// Метод сохраняет данные
        /// </summary>
        public virtual void Save(DbContext db)
        {

        }
        /// <summary>
        /// Метод удаляет данные
        /// </summary>
        public virtual void Remove(DbContext db)
        {
            
        }
        /// <summary>
        /// Метод сохраняет изменения в данных
        /// </summary>
        public virtual void Change(DbContext db)
        {

        }

        /// <summary>
        /// Метод высчитывает минмальный процент скидки. 
        /// </summary>
        /// <returns>Минимальный процент скидки</returns>
        public virtual int PriceOfDiscountCalculation()
        {
            decimal price = this.price;
            decimal discount= discont;
            int pDiscount = procentDiscount;

            while (!ChekMInPriceIsPrice(price, discount))
            {
                pDiscount -= 1;
                discount= CalculationProcentInSum(price, pDiscount);
            }
            
            return pDiscount;
        }

        /// <summary>
        /// Метод проверяющий итоговую цена. Итоговая цена не должна быть ниже минимальной цены с учётом всех скидок.
        /// </summary>
        /// <param name="price">Итоговая цена</param>
        /// <param name="discount">Скидка</param>
        /// <returns>Истина если итоговая цена выше миимальной стоимости, лож если итоговая цена ниже минимальной стоимости</returns>
        public bool ChekMInPriceIsPrice(decimal price, decimal discount)
        {
            price -= discount;

            if (price <= MinPrice)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Метод высчитывает процент из числа и возвращает полученное число в типе decimal.
        /// </summary>
        /// <param name="sum">Число из которого будет высчитываться процент</param>
        /// <param name="procent">Процент</param>
        /// <returns>Процент от sum</returns>
        protected decimal CalculationProcentInSum(decimal sum, int procent)
        {
            return Math.Round((decimal)(sum * procent / 100));
        }
    }
}
