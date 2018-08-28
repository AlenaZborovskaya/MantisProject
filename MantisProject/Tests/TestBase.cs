using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;



namespace MantisProject
{
    public class TestBase
    {
        public static bool PERFORM_LONG_UI_CHECKS = true;
        protected ApplicationManager app;


        [OneTimeSetUp]

        public void SetupApplicationManager() //метод для инициализации: драйвера, помощников
        {
            //app = new ApplicationManager();//конструируем менеджер, создается ссылка на applicationmanager

            app = ApplicationManager.GetInstance(); // будет инициализироваться заранее тестовым фрейморком, а 

        }

        public static Random rnd = new Random();//делаем генератор случайных чисел

        public static string GenerateRandomString(int max)
        {

            //при помощи этого генератора делаем случайное число в диапазоне от 0 до максимального
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            //генерируем случайные символы
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 65)));//преобразование случаного числа в символ
            }
            return builder.ToString();
        }
    }
}