using System;
using System.Collections.Generic;
using System.Linq;

namespace Menu
{
    public class MenuMaster
    {
      
        private List<string> menuFood;
        private int countFoodPage; //Блюда на лист

        public MenuMaster(List<string> menuFood, int countFoodPage)
        {
            if (menuFood == null || menuFood.Count == 0)
            {
                throw new ArgumentException("Коллекция меню List<string> menuItems - пустая.\n Коллекция == 0 || ==null.");
            }

            else if (countFoodPage <= 0)
            {
                throw new ArgumentException("Количество элементов на странице должно быть положительным целым числом. ");
            }

            this.menuFood = menuFood;
            this.countFoodPage = countFoodPage;
        }

        private void ValidatePageNumber(int pageNumber)
        {
            if (pageNumber <= 0 || pageNumber > GetTotalPagesCount())
            {
                throw new ArgumentException("Неверный номер страницы.");
            }
        }
        
        /*  
           Методы
           ▪️ Общее количество блюд;
           ▪️ Количество страниц;
           ▪️ Количество блюд на указанной странице;
           ▪️ Блюда указанной страницы;
           ▪️ Список первых блюд каждой страницы;
        */

        /// <summary>
        /// Общее количество блюд меню
        /// </summary>
        /// <returns> int - Общее кол-во блюд </returns>
        public int GetTotalCountFood()
        {
            return menuFood.Count;
        }


        /// <summary>
        /// Общее количество страниц в меню
        /// </summary>
        /// <returns> int - Общее кол-во страниц </returns>
        public int GetTotalPagesCount()
        {
            return (int)Math.Ceiling((double)menuFood.Count / countFoodPage);
        }

        /// <summary>
        /// Количество блюд на странице int pageNumber.  
        /// </summary>
        /// <returns> int - Кол-во блюд на странице </returns>
        public int GetCountFoodOnPage(int pageNumber)
        {
            ValidatePageNumber(pageNumber);

            int startIndex = (pageNumber - 1) * countFoodPage;
            int foodCount = Math.Min(countFoodPage, menuFood.Count - startIndex);
            return foodCount;
        }
        
        /// <summary>
        /// Коллекция блюд на странице int pageNumber 
        /// </summary>
        /// <returns> int - Коллекция блюд на странице </returns>
        public List<string> GetFoodOnPage(int pageNumber)
        {
            ValidatePageNumber(pageNumber);

            int startIndex = (pageNumber - 1) * countFoodPage;
            int itemsCount = Math.Min(countFoodPage, menuFood.Count - startIndex);
            return menuFood.GetRange(startIndex, itemsCount);
        }

        /// <summary>
        /// Коллекция первых блюд
        /// </summary>
        /// <returns> list - Коллекция первых блюд на странице </returns>
        public List<string> GetFirstFoodOnAllPages()
        {
            List<string> firstFoodList = new List<string>();

            for (int page = 1; page <= GetTotalPagesCount(); page++)
            {
                List<string> foodOnPage = GetFoodOnPage(page);
                if (foodOnPage.Count > 0)
                {
                    firstFoodList.Add(foodOnPage[0]);
                }
            }

            return firstFoodList;
        }
    }
}